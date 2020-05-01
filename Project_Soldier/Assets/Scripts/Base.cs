using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    // Start is called before the first frame update
    //===========================HP바 베이스 ===============================
    public Slider hpBar; // 사용할 Slider를 저장해놓을 UI 변수

    private float baseMaxHp = 100; // 기본 HP
    private float curHp = 100; // 현재 HP
    //=====================================================================

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 테스트용 : Space바를 누르면 
        {
            curHp -= 10; // 현재 체력에서 -10이 된다.
        }
        UpdateHp();
    }

    private void UpdateHp()
    {   //hp바의 값에 현재 체력값을 업데이트 시켜준다.
        hpBar.value = Mathf.Lerp(hpBar.value, (float)curHp / (float)baseMaxHp, Time.deltaTime * 10);
    }
}
