using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailMovment : MonoBehaviour
{
    AudioSource audio;
    Rigidbody rb;
    float speed=1.5f;
    bool enter;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enter = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!enter)
        {
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            // transform.forward.z = 0; ;
            speed = 0;
            enter = true;
            Debug.Log("ghcccccccccccc");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (enter)
        {
            //rb.isKinematic = false;

            // transform.forward.z = 0; ;
            speed = 1.5f;
            Debug.Log("exit");
        }
    }
  
    void Update()
    {

        rb.velocity = transform.forward * speed;
        Debug.Log(  transform.forward*speed);

        //audio.Play();
    }
}
