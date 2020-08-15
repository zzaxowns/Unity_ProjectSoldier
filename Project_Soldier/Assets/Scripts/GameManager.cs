using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //===================== 파티클 시스템 오브젝트 풀링====================
    public ParticleSystem gunShootParticle_Prefab; // 총 파티클 이펙트 프리팹
    private ParticleSystem gunShootParticle; // 총 파티클 이펙트
    public GameObject gunShootParticlePos; // 총 파티클 이펙트 나오는 위치
    //=====================공중지원 시스템 //=============================
    public GameObject airSupport_Prefab;
    private GameObject airSupport;
    public GameObject airSupportSpawanPos;
    //======================총알 날아가는 ============================
    public GameObject bullet;
    public GameObject firePos;
    public GameObject[] bullets = new GameObject[5];


    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null) // 싱글톤 
        {
            instance = this; // 할당이 안되어 있다면 할당시켜라
        }
        else if (instance != this) {
            Destroy(this.gameObject); // 만약 할당이 되어있는데 이 객체가 아니라면 해제시켜라 
        }

        //DontDestroyOnLoad(this.gameObject); // 다른 씬으로 넘어가더라도 이 오브젝트는 유지해라!
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {   // 총알 할당 및 비활성화
            bullets[i] = Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
            bullets[i].SetActive(false);
        }

        gunShootParticle = Instantiate(gunShootParticle_Prefab, gunShootParticlePos.transform.position, gunShootParticlePos.transform.rotation);
        airSupport = Instantiate(airSupport_Prefab, airSupportSpawanPos.transform.position, airSupportSpawanPos.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ShootPaticleOn() {
        gunShootParticle.transform.position = gunShootParticlePos.transform.position;
        gunShootParticle.transform.rotation = gunShootParticlePos.transform.rotation;

        gunShootParticle.gameObject.SetActive(true);
        //Debug.Log("ShootParicleOn! 함수 사용");
    }

    public void AirSupportOn() {
        
        airSupport.transform.position = airSupportSpawanPos.transform.position;
        airSupport.transform.rotation = airSupportSpawanPos.transform.rotation;

        airSupport.SetActive(true);
       
    }

    public void fireBullet()
    {
        for (int i = 0; i < 5; i++)
        {
            if (bullets[i].activeSelf == false)
            {
                bullets[i].transform.position = firePos.transform.position;
                bullets[i].transform.rotation = firePos.transform.rotation;
                bullets[i].SetActive(true);
                break;
            }
        }
    }

}
