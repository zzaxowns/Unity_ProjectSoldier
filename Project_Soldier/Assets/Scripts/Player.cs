using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update


    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        call_AirSupport();
    }


    void call_AirSupport() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            // 공중지원 콜

            GameManager.instance.AirSupportOn();
        }
    }
}
