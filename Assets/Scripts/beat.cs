using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat : MonoBehaviour
{
    public GameObject ligthsphere;
     public GameObject game;
    public GameObject parent;
    public Material green;
    public Material red;
    public GameObject obj = null ;
    
      GameObject fish;
    // Use this for initialization
    void Start()
    {
        BoxCollider box = game.GetComponent<BoxCollider>();
        fish = GameObject.FindGameObjectWithTag("fish");
        
        //ToggleTag();
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(this.tag);
    }
     void  OnTriggerEnter(Collider collision)
    {  
        if (collision.gameObject.tag == "underwater")

        {
            // ToggleTag();
            this.tag = "waypoint";

        }
    if (collision.gameObject.tag == "fish")
    {
        if (transform.childCount == 0 && collision.gameObject.transform.parent!=parent.transform)
        {
                Debug.Log("ksjksj");
            collision.gameObject.transform.SetParent(this.transform);
            collision.gameObject.GetComponent<Aimove>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
           // this.GetComponent<Rigidbody>().isKinematic = true;
            obj= collision.gameObject;
                ligthsphere.GetComponent<Renderer>().material = green;
               // Debug.Log(obj);

        }
      
        
    }
        GameObject  fff= mGetFish();
    }
    public GameObject mGetFish()
    {
       // Debug.Log(obj);
        return obj;

    }
    private void OnTriggerExit(Collider other)
    {
        // ToggleTag();
        // 
        tag = "Untagged";
        ligthsphere.GetComponent<Renderer>().material = red;
    }
    void ToggleTag()
    {
        if (tag == "Untagged")
            tag = "waypoint";
        else
            tag = "Untagged";
        Debug.Log("Tag changed");
    }
}