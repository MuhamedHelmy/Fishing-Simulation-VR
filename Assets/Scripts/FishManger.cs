using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AIObjects
{
    public string AiGroubNames { get { return m_aiGroupName; } }
    public GameObject objprephape { get { return m_objprephap; } }
    public int MaxAi { get { return m_max; }}
    public int spawnRate { get { return m_rate; }}
    public int spawnAmount { get { return m_amount;} }
    public bool randomsizeState { get { return m_randomState; } }
    public bool enableSpawn { get { return m_enablespown; } }


    [Header("Ai Group State")]
    [SerializeField]

    private string m_aiGroupName;
        [SerializeField]
   private GameObject m_objprephap;
            [SerializeField]
  [Range(0,40)]
    private int m_max;
       [SerializeField]
  [Range(0,20)]
    private int m_rate;
       [SerializeField]
  [Range(0,20)]
    private int m_amount;
    [Header("Settings")]
      [SerializeField]
       private bool m_randomState;
      [SerializeField]
      private bool m_enablespown;
   public    AIObjects(string name, GameObject prephap, int maxAi, int spawnrate, int spawnamount, bool randomstate)
       {
           this.m_aiGroupName = name;
           this.m_objprephap = prephap;
           this.m_max = maxAi;
           this.m_rate = spawnrate;
           this.m_amount = spawnamount;
           this.m_randomState = randomstate;

       }
  public  void setvalues(int maxAi, int spawnrate, int spawnamount)
   {
       this.m_max = maxAi;
       this.m_rate = spawnrate;
       this.m_amount = spawnamount;
   }
}

public class FishManger : MonoBehaviour {

	// Use this for initialization
    public List<Transform> waypoints = new List<Transform>();   //we used list because we dont know how many waypoints
    public float SpownerTimer { get { return m_spownertimer; } }
    public Vector3 spawnArea { get { return m_spawonArea; } }
     [Header("Global Statues")]
    [Range(0,600)]
    [SerializeField]
    private float m_spownertimer;
   
    [SerializeField]
   private  Color m_spawoncolor= new Color(1.000f,0.000f,0.300f);

        [SerializeField]
    private Vector3 m_spawonArea = new Vector3(-31.35f, -0.9f, -40.76f);

    [Header("AI groub Settings")]
    public AIObjects[] aiobject = new AIObjects[5];
	void Start () {
        getwaypoints();
        RandomizeGroup();
        Aigroub();
        InvokeRepeating("spawnNPc", 0.5f, SpownerTimer);
       // InvokeRepeating("getwaypoints", 0.5f, SpownerTimer);
	}
	
	// Update is called once per frame
	void Update () {

        waypoints.Clear();
        getwaypoints();

	}
    void spawnNPc()
    {
        for (int i = 0; i < aiobject.Length; i++)
        {
            if (aiobject[i].enableSpawn && aiobject[i].objprephape != null)
            {
                GameObject tempGroub = GameObject.Find(aiobject[i].AiGroubNames);
                if (tempGroub.GetComponentInChildren<Transform>().childCount < aiobject[i].MaxAi)
                {
                    for (int y = 0; y < Random.Range(0, aiobject[i].spawnAmount); y++)
                    {
                        Quaternion randomRotation = Quaternion.Euler(Random.Range(-20, 20), Random.Range(0, 360), 0);
                        GameObject tempspawn;
                        tempspawn = Instantiate(aiobject[i].objprephape, RandomPosition(), randomRotation);
                        tempspawn.transform.parent = tempGroub.transform;
                        tempspawn.AddComponent<Aimove>();
                    }
                }
            }
        
        }
    }
    public Vector3 RandomPosition()
    {
        Vector3 randomposition = new Vector3(
            Random.Range(0, spawnArea.x),
             Random.Range(0, spawnArea.y),
              Random.Range(0, spawnArea.z));
        randomposition = transform.TransformPoint(randomposition );
        return randomposition;
    }
    void OnDrawGizmosSelected()
    {

        Gizmos.color = m_spawoncolor;
        Gizmos.DrawCube(transform.position, spawnArea);
    }
    public Vector3 Randomwaypoint()
    {
        int RandomRp = Random.Range(0, (waypoints.Count));
        Vector3 randomwaypoints = waypoints[RandomRp].transform.position;
        return randomwaypoints;
    }
    void RandomizeGroup()
    {
        for(int i=0;i<aiobject.Length;i++)
        {
            if(aiobject[i].randomsizeState)
            {
               // aiobject[i].MaxAi = Random.Range(0, 30);
         //   aiobject[i] =new AIObjects(aiobject[i].AiGroubNames, aiobject[i].objprephape, Random.Range(0, 30), Random.Range(0, 20), Random.Range(0, 10), aiobject[i].randomsizeState);
                aiobject[i].setvalues(Random.Range(1, 30), Random.Range(1, 20), Random.Range(2, 10));
            
            }
        }

    }
    void Aigroub()
    {
        for (int i = 0; i < aiobject.Length; i++)
        {
                 GameObject spawn;
                 if (aiobject[i].AiGroubNames != null)
                 {
                     spawn = new GameObject(aiobject[i].AiGroubNames);
                     spawn.transform.parent = this.gameObject.transform;
                 }
            
        }
    }
    void getwaypoints()
    {
        Transform[] wplist = this.transform.GetComponentsInChildren<Transform>();//GetComponentsInChildren<Transform>();
       // this.transform.GetComponents<Tr
        for (int i = 0; i < wplist.Length; i++)
        {
            if (wplist[i].tag == "waypoint" )
            {
                waypoints.Add(wplist[i]);

              //  Debug.Log(wplist[i]);

            }
          
        }

    }
}
