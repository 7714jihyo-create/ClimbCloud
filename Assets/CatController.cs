using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 580.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    float threshold = 0.2f; //가속도 한계

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator=GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("고양이 Collision 모드");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("고양이 trigger 모드");
        SceneManager.LoadScene("ClearScene");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("jump");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
                        //힘을 가함
        }

        int key = 0;

        if (Input.acceleration.x > this.threshold)
        {
            key = 1;
        }
        if (Input.acceleration.x < -this.threshold)
        {
            key = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }

        float speedx=Mathf.Abs(this.rigid2D.velocity.x);

        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
  
        
    }


}
