using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Grapthrow : MonoBehaviour
{

    public SteamVR_Input_Sources handType;
    public beat vBeat;
    [SteamVR_DefaultAction("GrabPinch")]
    public SteamVR_Action_Boolean grab;
    [SteamVR_DefaultAction("GrabGrip")]
    public SteamVR_Action_Boolean grip;
    public Camera cam;
    Rigidbody grabedBody;
   public  musicforRadio music;
    public GameObject obj;
    public GameObject boatfor;
    private bool isplay;
    public GameObject gam;
    LayerMask mask;
    SteamVR_Behaviour_Pose handPose;
    public col co;
    int speed;


    // Use this for initialization
    void Start()
    {
       // vBeat = GetComponent<beat>();
        mask = LayerMask.GetMask("rock");
       // speed = co.speed;
        handPose = GetComponentInParent<SteamVR_Behaviour_Pose>();
        isplay = false;
       //gam.GetComponent<Rigidbody>();
       // obj = GameObject.FindGameObjectWithTag("boat");
        PlayerPrefs.SetInt("handleft", 0);
        PlayerPrefs.SetInt("handright", 0);
        
        // audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grab.GetStateDown(handType))
        {
            Debug.Log("Grabed");

            var colliders = Physics.OverlapSphere(transform.position, 0.05f, mask);

            if (colliders.Length == 0) return;

            var rb = colliders[0].GetComponent<Rigidbody>();
            if (!rb) return;

            else
            {
                grabedBody = rb;
                if (grabedBody.gameObject.tag == "radio")
                {  if (isplay==false)
                       music.playaudio();
                     if (isplay)
                     {
                         music.stopAudio();
                     }
                }

                if (grabedBody.gameObject.tag == "fish" || grabedBody.gameObject.tag == "box" || grabedBody.gameObject.tag == "rock" || grabedBody.gameObject.tag == "pole")
                {
                    grabedBody.transform.SetParent(this.transform);
                    grabedBody.useGravity = false;
                    grabedBody.isKinematic = true;
                }
               

                else
                    Debug.Log("nothing happened");

            }
        }
       
        if (grab.GetStateUp(handType))
        {


            PlayerPrefs.SetInt("handright", 0);
            PlayerPrefs.SetInt("handleft", 0);
            Debug.Log("Released");

            if (!grabedBody) return;

            if (grabedBody.gameObject.tag == "fish" || grabedBody.gameObject.tag == "box" || grabedBody.gameObject.tag == "rock" )
            {
                grabedBody.transform.SetParent(obj.transform);
                grabedBody.useGravity = true;
                grabedBody.isKinematic = false;
            
                grabedBody.velocity = handPose.GetVelocity();
                grabedBody.angularVelocity = handPose.GetAngularVelocity();


            }
            else if (grabedBody.gameObject.tag == "pole")
            {

                grabedBody.transform.SetParent(obj.transform);
                grabedBody.useGravity = true;
                grabedBody.isKinematic = false;
                grabedBody.velocity = handPose.GetVelocity();
                grabedBody.angularVelocity = handPose.GetAngularVelocity();
                //gam.GetComponent<Rigidbody>().isKinematic = false;
                //gam.GetComponent<Rigidbody>().useGravity = true;
                //gam.transform.SetParent(obj.transform);
            }
            else if (grabedBody.gameObject.tag == "radio")
            {  if(isplay==false)

                isplay = true;
            else if (isplay == true)
            {
                isplay = false;
            }
            }
            else if (grabedBody.gameObject.tag == "padel" && grabedBody.gameObject.tag == "padel1")
            {
                //audio.Pause();
            }
            grabedBody = null;
        }
        
        if (grip.GetStateDown(handType))
        {
            if (vBeat.mGetFish() != null)
            {
                GameObject bu;
                bu=vBeat.mGetFish();
                Debug.Log(bu);
              //  bu.transform.SetParent(null);
                bu.GetComponent<Rigidbody>().useGravity = true;
                bu.GetComponent<Rigidbody>().isKinematic = false;
                bu.transform.SetParent(obj.transform);
            }
            /*
            if (obj != null)
            {
                obj.transform.SetParent(null);
                obj.GetComponent<Rigidbody>().useGravity = true;
                obj.GetComponent<Rigidbody>().isKinematic = false;
            }*/

    }
        if (grab.GetState(handType))

        {
            //Debug.Log("Grabed");

            var colliders = Physics.OverlapSphere(transform.position, 0.05f, mask);

            if (colliders.Length == 0) return;

            var rb = colliders[0].GetComponent<Rigidbody>();
            if (!rb) return;
            else
            {
                grabedBody = rb;


                if (grabedBody.gameObject.tag == "padel")//right
                    if (grabedBody.gameObject.tag == "padel")//right
                    {
                        PlayerPrefs.SetInt("handright", 1);
                        PlayerPrefs.Save();
                        if (PlayerPrefs.GetInt("handleft") != 1 && PlayerPrefs.GetInt("handright") == 1)
                        {
                            obj.transform.Rotate(Vector3.up * Time.deltaTime * -15);
                            cam.transform.Rotate(Vector3.up * Time.deltaTime * -15);

                        }//test speed/////////////*******/////////


                    }
                if (grabedBody.gameObject.tag == "padel1")//left
                {
                    PlayerPrefs.SetInt("handleft", 1);
                    PlayerPrefs.Save();
                    if (PlayerPrefs.GetInt("handleft") == 1 && PlayerPrefs.GetInt("handright") != 1)
                    {
                        obj.transform.Rotate(Vector3.up * Time.deltaTime * 15);
                        cam.transform.Rotate(Vector3.up * Time.deltaTime * 15);
                    }
                }
                if (PlayerPrefs.GetInt("handleft") == 1 && PlayerPrefs.GetInt("handright") == 1)
                {
                    //obj.transform.position += transform.forward * Time.deltaTime * 15;
                    Debug.Log(speed);
                    boatfor.transform.position += obj.transform.forward * Time.deltaTime * 5 * co.speed ;
                    


                }
                
            }
            }

        }



          

  
}

