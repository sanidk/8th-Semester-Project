using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class BallManager : MonoBehaviour
{
    public GameObject realtimeGameObject;
    Realtime realtime;
    RealtimeComponent rc;

    public int ballCount = 50;
    GameObject[] ballsArrayPlayer1;
    GameObject[] ballsArrayPlayer2;

    public GameObject ballPrefab;

    public GameObject floorPlayer1;
    public GameObject floorPlayer2;

    public GameObject spawnAreaPlayer1;
    public GameObject spawnAreaPlayer2;
    Collider spawnAreaColliderPlayer1;
    Collider spawnAreaColliderPlayer2;

    public GameObject playerObjectPlayer1;
    public GameObject playerObjectPlayer2;
    Collider playerColliderPlayer1;
    Collider playerColliderPlayer2;



    float spawnInterval;
    int maxConcurrentSpawns;

    bool instantiateBalls = true;
    bool spawnBalls = false;
    float startTime;
    float spawnTime = 5;




    float agentDensity = 0.1f;



    void Start()
    {
        realtime = realtimeGameObject.GetComponent<Realtime>();
        rc = GetComponent<RealtimeComponent>();
        startTime = Time.time;
    }

    private void Awake()
    {
        spawnAreaColliderPlayer1 = spawnAreaPlayer1.GetComponent<Collider>();
        spawnAreaColliderPlayer2 = spawnAreaPlayer2.GetComponent<Collider>();
    }

    void Update()
    {
        if (!realtime.connected) return;
        //remember is owned locally self check!
        //server check

        if (instantiateBalls)
        {
            InstantiateBalls();
            instantiateBalls = false;
            spawnBalls = true;


        }

        //if (spawnBalls)
        //{
        //    for (int i = 0; i < ballsArrayPlayer1.Length; i++)
        //    {

        //        float x = Random.Range(spawnAreaColliderPlayer1.bounds.center.x - spawnAreaColliderPlayer1.bounds.size.x * 0.5f,
        //            spawnAreaColliderPlayer1.bounds.center.x + spawnAreaColliderPlayer1.bounds.size.x * 0.5f);

        //        float y = Random.Range(spawnAreaColliderPlayer1.bounds.center.y - spawnAreaColliderPlayer1.bounds.size.y * 0.5f,
        //            spawnAreaColliderPlayer1.bounds.center.y + spawnAreaColliderPlayer1.bounds.size.y * 0.5f);

        //        float z = Random.Range(spawnAreaColliderPlayer1.bounds.center.z - spawnAreaColliderPlayer1.bounds.size.z * 0.5f,
        //            spawnAreaColliderPlayer1.bounds.center.z + spawnAreaColliderPlayer1.bounds.size.z * 0.5f);

        //        ballsArrayPlayer1[i].transform.position = new Vector3(x, y, z);

        //    }
        //    spawnBalls = false;
        //}

        
    }

    void InstantiateBalls()
    {
        ballsArrayPlayer1 = new GameObject[ballCount];
        ballsArrayPlayer2 = new GameObject[ballCount];

        Vector3 floor1 = floorPlayer1.transform.position;
        Vector3 floor2 = floorPlayer2.transform.position;



        for (int i = 0; i < ballsArrayPlayer1.Length; i++)
        {

            ballsArrayPlayer1[i] = Realtime.Instantiate("Ball_Prefab", new Vector3(floor1.x, floor1.y-2, floor1.z), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = true,
                preventOwnershipTakeover = true,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });

            ballsArrayPlayer1[i] = Realtime.Instantiate("Ball_Prefab", new Vector3(floor2.x, floor2.y - 2, floor2.z), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = true,
                preventOwnershipTakeover = true,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });

        }
    }

    /*
     public int amountOfAgents = 200;
    public GameObject agentPrefab;
    float agentDensity = 0.1f;
    static List<GameObject> agents = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountOfAgents; i++)
        {
            GameObject newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitSphere * amountOfAgents * agentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
            
                );
            newAgent.name = "Agent" + i;
            agents.Add(newAgent);
        }
    } 
     */


}
