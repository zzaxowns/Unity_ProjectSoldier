using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBomb : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem explosion;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plane") {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
            
        }
    }
}
