using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : MonoBehaviour
{
    // Start is called before the first frame update
    enum GunShootState { 
        Idle,
        Shoot
    };

    GunShootState state;
    public Animator handgunAni;

    private bool aimType; // 정조준이냐 아니냐 true: 정조준/ false: 일반

    ////===================== 파티클 시스템 오브젝트 풀링====================
    //public ParticleSystem gunShootParticle; // 총 파티클 이펙트
    //public GameObject gunShootParticlePos; // 총 파티클 이펙트 나오는 위치

    //======================레이캐스팅=============================
    public Transform ray_Origin; // Ray 시작 위치 정보값

    public float ray_Len = 70.0f; // Ray의 길이

    public RaycastHit hit; // Ray를 이용해 피격을 입은 객체의 정보를 담는 변수

    Ray ray; // 사용할 Ray 변수 

    //=====================총 재발사 딜레이==========================
    private float shootDelay;

    void Start()
    {
        state = GunShootState.Idle;
        handgunAni = GetComponent<Animator>();
      
        aimType = false;
    
        ray = new Ray(); // Ray 초기화 

        shootDelay = 0.0f; // 총 재발사 딜레이 초기화
    }

    // Update is called once per frame
    void Update()
    {
        checkShooting();
        Debug.DrawRay(ray.origin, ray.direction * ray_Len, Color.red);// Ray를 그려보면서 위치 확인 
    }


    void checkShooting() { // 권총을 쏠 때 사용되는 함수

        ray.origin = ray_Origin.position;// Ray의 시작 위치값을 넣는다.
        ray.direction = ray_Origin.forward; // Ray에 방향값을 넣는다

        if (Input.GetMouseButtonDown(0) && state == GunShootState.Idle) // 마우스 왼쪽 클릭을 했을 경우
        {
            //총 쏠 때의 파티클
            GameManager.instance.ShootPaticleOn();
            //GameManager.instance.fireBullet();

            handgunAni.SetBool("isShoot", true); //총 쏘는 애니메이션 변수 true
            //Debug.Log(handgunAni.GetBool("isShoot"));

            state = GunShootState.Shoot;
            //Debug.Log("현재 HandGun 상태" + state);

            if (Physics.Raycast(ray, out hit)) // Ray에 충돌한 객체가 있다면 (Raycast는 반환값이 bool입니다.)
            {                                  // hit은 충돌한 객체의 Info값을 받아주는 변수 
                if (hit.collider.tag == "Enemy") // 충돌한 객체의 collider의 테크값이 Enemy일 경우
                {
                    // SoldierAnimaion 스크립트 변수를 만들어서 충돌한 hit 객체의 스크립트를 받아온다
                    SoldierAnimaion hit_soileranimaion = hit.transform.GetComponent<SoldierAnimaion>();

                    if (hit_soileranimaion != null) // 만약 받아온 값이 NULL이 아니라면 (오류를 거르기 위함)
                    {
                        hit_soileranimaion.Soldier_Hit(); // 스크립트에 있는 Soldier_Hit() 함수를 사용해라
                    }

                }
            }
        }
        else if(state == GunShootState.Shoot) {

            shootDelay -= Time.deltaTime;

            state = GunShootState.Idle;

            handgunAni.SetBool("isShoot", false); // 총 쏘는 애니메이션 변수 false

            if (shootDelay < 0)
            {
                shootDelay = 0.7f;
                state = GunShootState.Idle;

                handgunAni.SetBool("isShoot", false); // 총 쏘는 애니메이션 변수 false
            }
        }

    }
}
