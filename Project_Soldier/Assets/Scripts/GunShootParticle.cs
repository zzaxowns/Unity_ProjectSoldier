using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootParticle : MonoBehaviour
{

    private float gunParticleLife; // 파티클이 사용되는 시간

    // Update is called once per frame
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        gunParticleLife -= Time.deltaTime;

        if (gunParticleLife < 0)
        {
            gunParticleLife = 0.3f;
            this.gameObject.SetActive(false);
            //Debug.Log("총 파티클 비활성화");
        }
    }

    private void OnEnable() // 활성화를 할 때 자동으로 호출되는 함수 /OnDisable() 얘는 반대
    {
        gunParticleLife = 0.3f;
        //Debug.Log("총 파티클 시작");
    }


}

