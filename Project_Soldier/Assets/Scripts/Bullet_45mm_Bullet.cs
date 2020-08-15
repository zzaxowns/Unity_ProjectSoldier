using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_45mm_Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float bulletSpeed;
    private float bullet_Life_Time ;

    void Start()
    {
        bullet_Life_Time = 0.5f;
        bulletSpeed = 0.5f; // 총알 라이프타임
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed); // 총알의 위치 이동
        bullet_Life_Time -= Time.deltaTime; // 총알 라이프타임 (1초)

        if (bullet_Life_Time < 0) {
            this.gameObject.SetActive(false); // 라이프 타임이 1초가 지나면 비활성화
            bullet_Life_Time = 0.5f; // 라이프 타임 초기화
        }
    }
}
