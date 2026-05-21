# Climb cloud
## 🐱 고양이 구름 점프 게임

유니티(Unity) 2D 환경에서 개발한 캐주얼 플랫폼 점프 게임입니다. 고양이 캐릭터를 조작하여 구름 발판을 딛고 올라가 최종 목적지인 깃발에 도달하는 것을 목표로 합니다. 모바일 기기의 가속도 센서(기본 틸트 조작)와 PC 키보드 입력을 모두 지원하도록 설계되었습니다.

<br>

## 🎮 주요 기능 (Key Features)

* **멀티 플랫폼 입력 처리**: PC 키보드(`←`, `→` 방향키) 조작은 물론, 모바일 환경을 고려한 가속도 센서(`Input.acceleration`) 기반의 틸트(Tilt) 조작을 동시에 지원합니다.
* **속도 제한 및 가속 제어**: 물리 엔진(`Rigidbody2D`)의 `AddForce`를 활용해 부드러운 움직임을 구현했으며, 최대 이동 속도(`maxWalkSpeed`)를 제한하여 안정적인 조작감을 제공합니다.
* **동적 애니메이션 속도 조절**: 고양이의 현재 수평 이동 속도(`velocity.x`)에 비례하여 걷기 애니메이션 재생 속도를 동적으로 변경함으로써 시각적 자연스러움을 높였습니다.
* **안전한 점프 제어**: 수직 속도(`velocity.y == 0`)를 체크하여 공중 연속 점프(무한 점프)를 방지하는 기초적인 지면 검사 로직이 포함되어 있습니다.
* **게임 루프 관리**: 고양이가 화면 아래(`y < -10`)로 추락하면 게임 오버로 간주하여 스테이지를 재시작(`GameScene`)하고, 깃발(Trigger 영역)에 닿으면 스테이지 클리어 씬(`ClearScene`)으로 전환됩니다.

<br>

## 🛠️ 기술 스택 (Tech Stack)

* **Engine**: Unity 2022.x (또는 본인이 사용한 버전)
* **Language**: C#
* **Physics**: Rigidbody 2D, Collider 2D (Box/Circle)
* **Graphics**: 2D Sprite, Animator (Mecanim System)

<br>

## 📄 핵심 코드 설명 (Core Script)

### `CatController.cs`
고양이 캐릭터의 이동, 점프, 애니메이션 제어 및 충돌에 따른 씬 전환을 담당하는 메인 컨트롤러 스립트입니다.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    
    [Header("Movement Settings")]
    [SerializeField] float jumpForce = 580.0f;
    [SerializeField] float walkForce = 30.0f;
    [SerializeField] float maxWalkSpeed = 2.0f;

    [Header("Mobile Settings")]
    [SerializeField] float threshold = 0.2f; // 스마트폰 기울기 인식 임계값

    void Start()
    {
        this.rigid2D = GetComponent
