using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("구름 Collision 모드");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("구름 trigger 모드");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
