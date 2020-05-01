using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierManager : MonoBehaviour
{
    // Start is called before the first frame update

    //================================군인 오브젝트 스폰 관련 변수들 ==============================
    public GameObject soldierObject; // 군인 오브젝트를 넣을 변수
    public float soldier_Max_Num = 15; // 군인 오브젝트 최대 개수

    List<GameObject> soldiers = null; // 리스트 만들고 null로 초기화

    public float spawnTime;
    private float timer;

    //===========================================================================================

    void Start()
    {
        // ======================= 군인 오브젝트 리스트 초기화

        soldiers = new List<GameObject>(); // 할당시킴

        for (int i = 0; i < soldier_Max_Num; i++)
        {
            GameObject obj = Instantiate(soldierObject); //obj에 군인 오브젝트를 넣고
            soldiers.Add(obj); // GameObject 변수를 갖는 리스트에 넣는다.
            soldiers[i].SetActive(false); // 모든 군인 오브젝트들의 상태를 false로 초기화 한다. 
        }

        //===================================

        spawnTime = 3.0f; // 스폰되는 간격 시간 
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) {
            SpawnSolder();
            timer = spawnTime;
        }
    }

    public void SpawnSolder() {
        for (int i = 0; i < soldier_Max_Num; i++)
        {
            if (soldiers[i].activeInHierarchy == false)
            {
                float randomX = Random.Range(-4.0f, 4.0f);
                Vector3 spawnPos = this.gameObject.transform.position;
                spawnPos.x += randomX;

                soldiers[i].transform.position = spawnPos;
                soldiers[i].transform.rotation = this.gameObject.transform.rotation;
                //Debug.Log(i + "번째 총알 첫 위치" + bullets[i].transform.position);
                soldiers[i].SetActive(true);
                break;
            }
        }

    }
}
