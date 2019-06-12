using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col : MonoBehaviour
{

    public int speed;
    // Use this for initialization
    void Start()
    {
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
      //  this.transform.position -= -this.transform.forward * Time.deltaTime * 5 * speed;
    }
    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "land")
        {
            Debug.Log("enter");
            speed = 0;
        }
    }
    public int getspeed()
    {
        return speed;
    }
    void OnTriggerExit(Collider other)
    {
        speed = 1;
    }
}
