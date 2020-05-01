using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVD : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator sVDAnimator;

    void Start()
    {
        sVDAnimator = GetComponent<Animator>();
        sVDAnimator.SetBool("isAimming", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            sVDAnimator.SetBool("isAimming", true);
            Debug.Log("에이밍!");
        }
        else if(Input.GetMouseButtonUp(1)){
            sVDAnimator.SetBool("isAimming", false);
        }
    }
}
