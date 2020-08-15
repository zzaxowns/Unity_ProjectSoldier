using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFPS : MonoBehaviour
{
    // Start is called before the first frame update

    public float camSpeed = 1.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveLookAt();
    }

    void MoveLookAt() {
        yaw += camSpeed * Input.GetAxis("Mouse X");
        pitch += camSpeed * Input.GetAxis("Mouse Y");

        yaw = Mathf.Clamp(yaw, -225f, -90.0f);
        pitch = Mathf.Clamp(pitch, -30f, 10f);

        transform.eulerAngles = new Vector3(-pitch, yaw, 0.0f);
    }
}
