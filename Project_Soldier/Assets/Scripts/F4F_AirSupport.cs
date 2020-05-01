using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F4F_AirSupport : MonoBehaviour
{
    // Start is called before the first frame update

    Transform startPos;
    public ParticleSystem airSupport;

    public float flyTime;
    //List<ParticleSystem> airSupports = new List<ParticleSystem>();

    //private int airSupportsCount;

    private void OnEnable()
    {
        flyTime = 4.0f;
    }
    void Start()
    {

        //airSupportsCount = 10;

        //for (int i = 0; i < airSupportsCount; i++)
        //{
        //    airSupports.Add(Instantiate(airSupport));
        //    airSupports[i].gameObject.SetActive(false);
        //}
        this.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (flyTime < 0)
        {
            this.gameObject.SetActive(false);
        }
        
        flyTime -= Time.deltaTime;
    }

    //public void shootBullet()
    //{
    //    for (int i = 0; i < airSupportsCount; i++)
    //    {
    //        //여기서 총 쏘는 모션 만들어야함
    //        airSupports[i].gameObject.SetActive(true);
    //        Debug.Log(i + "번째 airSupports 생성");
    //    }
    //}

}
