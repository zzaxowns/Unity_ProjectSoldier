using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SoldierState{
    run,
    shoot,
    death
    };

public class SoldierAnimaion : MonoBehaviour
{

    public SoldierState state = SoldierState.shoot;

    public Animator soldierAni;

    private float speed = 2;

    float Random_dist; // 군인 오브젝트 수평으로 이동 위치 랜덤값

    //=====================군인 오브젝트의 HP바======================
    public Slider hpBar;
    public GameObject SoldierObectHpPos;

    private float MaxHp = 2;
    private float curHp = 2;


    // Start is called before the first frame update
    void Start()
    {
        soldierAni = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimationUpdate();
        UpdateHp();
    }

    void AnimationUpdate()
    {

        if (curHp < 0) { // 애니메이션 시작과 동시에 솔저의 hp 확인
            state = SoldierState.death;
        }

        if (state == SoldierState.run)
        {
            Vector3 pos = transform.position;

            pos.z += speed * Time.deltaTime;
            //Debug.Log("현재 스테이트" + state);

            if (pos.z > -2.0f + Random_dist)
            {
                soldierAni.SetBool("isShooting", true);
                state = SoldierState.shoot;
                //Debug.Log("현재 스테이트" + state);
            }

            transform.position = pos;// 오브젝트 움직일 때 캐릭터 좌표 갱신해주는 코드
        }else if (state == SoldierState.shoot)
        {
           // base 캠프가 데미지 입는 형태로 만들어야한다.

        }else if (state == SoldierState.death)
        {
            DeathAni();
        }

    }

    void DeathAni()
    {

        if (transform.rotation.x < -0.5)
        {
            
            this.gameObject.SetActive(false); //죽는 애니메이션이 끝나면 비활성화
            //curHp = 2; // HP 초기화
            state = SoldierState.run;
        }
        else 
        {
            float downAngel = 5.0f;
            Quaternion downSpeed = transform.rotation;
            downSpeed.x -= (float)(Math.PI * Time.deltaTime / downAngel);
            transform.rotation = downSpeed;
        }

    }

    public void Soldier_Hit() { // 레이캐스팅을 통해서 피격했을 때 호출되는 함수 

        curHp--;
    }

    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.CompareTag("Bullet")) {
    //        curHp--;
    //    }
    //}

    private void UpdateHp() {
       
  
    }

    private void OnEnable()
    {
        Random_dist = UnityEngine.Random.Range(0.0f, 2.0f);
        curHp = 2;
        state = SoldierState.run;
    }
}