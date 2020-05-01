using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBompExplosion : MonoBehaviour
{
    // Start is called before the first frame update\

    public float Timer;

    void Start()
    {
        Timer = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer < 0) {
            Destroy(this.gameObject);
        }

        Timer -= Time.deltaTime;
    }
}
