using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimove : MonoBehaviour {


    private FishManger m_fishmanger;
    private bool m_hastarget = false;
    private bool m_isTurning;
    private Vector3 m_waypoint;
    private Vector3 lastwaypoint;
    private float speed;
    //private Animator m_animator;
    private Collider m_coolider;
    private RaycastHit m_raycast;
    //private Animation[] m_aimation;

	// Use this for initialization
	void Start () {
        m_fishmanger = transform.parent.GetComponentInParent<FishManger>();
       // m_fishmanger = transform.GetComponent<FishManger>();
       //m_animator = GetComponent<Animator>();
       // m_aimation= GetComponents<Animation>();

        lastwaypoint = new Vector3(0, 0, 0);
        setupnfc();
    }
    void setupnfc(){
      float  scale = Random.Range(0, 0.3f);
      transform.localScale += new Vector3(scale*0.2f , scale*0.2F, scale*0.2f);

		
	}
	
	// Update is called once per frame
	void Update () {
        if(!m_hastarget)
        {
            m_hastarget = canfindtarget();

        }
        else
        {   
            RotateNFC(m_waypoint, speed);
            transform.position = Vector3.MoveTowards(transform.position, m_waypoint, speed * Time.deltaTime);
            if (transform.position == m_waypoint)
            {
                m_hastarget = false;

            }
        }
       

	}
    Vector3 getRandomWaypoint(bool isRandom)
    {
        if (isRandom)
        {
            return m_fishmanger.RandomPosition();
        }
        else
        {
            return m_fishmanger.Randomwaypoint();
        }
    }
    bool canfindtarget(float start = 1f, float end = 7f)
        
    {
        m_waypoint = m_fishmanger.Randomwaypoint();
        if (lastwaypoint == m_waypoint)
        {
            m_waypoint = m_fishmanger.Randomwaypoint();

              return false;
        }

        else
        {
            lastwaypoint = m_waypoint;
        //    Debug.Log(lastwaypoint);
            speed = Random.Range(start, end);
           //m_animator.speed = speed;
           //for (int i = 0; i < m_aimation.Length; i++)
           //{
           //    m_aimation[i].Play();
           //}
           //    //    m_animation.Play();
               return true;

        }
    }
    void RotateNFC(Vector3 way, float current)
    {
        float turnspeed = current * Random.Range(1, 3);
        Vector3 lookat = way - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookat), turnspeed * Time.deltaTime);
    }
}
