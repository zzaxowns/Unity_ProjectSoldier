using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemySpawnner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] Anemy;
    //public int AnemyTypeNum;

    private float SpawnTimer;

    void Start()
    {
        //AnemyTypeNum = 10;
        // Anemy = new GameObject[];
        SpawnTimer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnAnemy();
    }

    void SpawnAnemy() {

        //float randomX = UnityEngine.Random.Range(-5.0f, 5.0f);

        SpawnTimer -= Time.deltaTime;

        if (SpawnTimer < 0)
        {
            float randomX = UnityEngine.Random.Range(-5.0f, 5.0f);
            Vector3 pos = transform.position;

            pos.x += randomX;

            Instantiate(Anemy[0], pos, transform.rotation); // 군인 객체 생성
            SpawnTimer = 5.0f; // 스폰 타이머 초기화
        }
        
    }

}
