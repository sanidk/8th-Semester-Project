using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class GridManager : MonoBehaviour
{
    //REALTIME
    public GameObject realtimeGameObject;
    Realtime realtime;
    RealtimeComponent rc;


    //GRID
    public bool gridGraphicToggle;
    Vector3[] spawnzonesArray;
    public bool[] spawnzonesInUseArray;
    public GameObject cubePrefab;
    public GameObject ballPrefab;
    Vector3 gridStart;
    int gridSize;

    int gridResolution = 8;
    float gridLength = 2;
    public static float gridSpacing;

    //TRAP
    public GameObject trapCubePrefab;
    public List<GameObject> trapCubeList;
    public TrapDeploy trapDeploy;

    int trapGridResolution = 2;
    float trapGridSpacing;
    int trapGridSize;

    int nextTrap = 0; 

    public int trapNameDesignator = 0;

    //SPAWNING
    Vector3 instantiatePosition = new Vector3(0, -100, 0);
    bool instantiateBalls = true;
    public bool spawnBalls = false;
    public int ballsAmount = 10;
    int ballsAmountMax = 50;
    GameObject[] ballsArray;
    





    // Start is called before the first frame update
    void Start()
    {
        realtime = realtimeGameObject.GetComponent<Realtime>();
        rc = GetComponent<RealtimeComponent>();

        ballsArray = new GameObject[ballsAmountMax];

        gridSize = (int)Mathf.Pow(gridResolution, 3);
        spawnzonesArray = new Vector3[gridSize];
        spawnzonesInUseArray = new bool[gridSize];

        gridStart = transform.position;
        int index = 0;

        // Trap grid

        trapCubePrefab = Resources.Load("trapCube") as GameObject;

        trapCubeList = new List<GameObject>();
        trapDeploy = GetComponent<TrapDeploy>();

        trapGridSpacing = gridLength / trapGridResolution;
        trapGridSize = (int)Mathf.Pow(trapGridResolution, 2);

        for (int i = 0; i < trapGridResolution; i++) {
            for (int j = 0; j < trapGridResolution; j++) {

                float xpos = gridStart.x + (trapGridSpacing / 2) + (i * trapGridSpacing);
                float zpos = gridStart.z + (trapGridSpacing / 2) + (j * trapGridSpacing);

                trapCubeList.Add(Instantiate(trapCubePrefab, new Vector3(xpos, -0.03f, zpos), transform.rotation));
            }
        }
        
        foreach(GameObject trapCube in trapCubeList) {
            trapCube.name = "Trap" + trapNameDesignator;
            trapCube.AddComponent<TrapDeploy>();
            trapCube.transform.SetParent(gameObject.transform);
            trapNameDesignator++;
            
        }

        // Trap grid end

        for (int x = 0; x < gridResolution; x++)
        {
            for (int y = 0; y < gridResolution; y++)
            {
                for (int z = 0; z < gridResolution; z++)
                {
                    gridSpacing = gridLength / gridResolution;

                    float xpos = gridStart.x + (gridSpacing / 2) + (x * gridSpacing);
                    float ypos = gridStart.y + (gridSpacing / 2) + (y * gridSpacing);
                    float zpos = gridStart.z + (gridSpacing / 2) + (z * gridSpacing);

                    spawnzonesArray[index] = new Vector3(xpos, ypos, zpos);
                    index++;
                    
                    if (gridGraphicToggle)
                    {
                        GameObject cube = Instantiate(cubePrefab, new Vector3(xpos, ypos, zpos), transform.rotation);
                        cube.transform.localScale = new Vector3(gridSpacing, gridSpacing, gridSpacing);
                    }

                }
            }
        }

    }

    void InstantiateBalls()
    {
        for (int i = 0; i < ballsAmountMax; i++)
        {

            ballsArray[i] = Realtime.Instantiate("Ball_Prefab", instantiatePosition, transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = true,
                preventOwnershipTakeover = true,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });

            ballsArray[i].transform.SetParent(gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!realtime.connected) return;
        if (!GameManagerLogic.isServer) return;

        if (instantiateBalls)
        {
            InstantiateBalls();
            instantiateBalls = false;
            //spawnBalls = true;
        }

        if (spawnBalls)
        {
            for (int i = 0; i < ballsAmount; i++)
            {
                GameObject ball = ballsArray[i];
                

                if (!ball.GetComponent<BallBehaviour>().isBallActive)
                {
                    //int gridNumber = GetAvailableGridPosition();
                    int gridNumber = Random.Range(0, spawnzonesArray.Length-1);
                    Vector3 pos = spawnzonesArray[gridNumber];
                    //SetSpawnzonesInUseArray(gridNumber, true);
                    //ball.GetComponent<BallBehaviour>().isBallActive = true;
                    StartCoroutine(ball.GetComponent<BallBehaviour>().SpawnBall(gridNumber, pos));
                    
                    
                }
            }

        }

        // For testing traps
        //if (Time.time > nextTrap) {
        //    sendTrap(2);
        //    nextTrap += 10;
        //}
        

    }
    //int GetAvailableGridPosition()
    //{
    //    int gridNumber = Random.Range(0, spawnzonesArray.Length);
    //    return gridNumber;
    //}

    public void sendTrap(int trapNumber)
    {
        trapCubeList[trapNumber].GetComponent<TrapDeploy>().spawnTrap();
    }

    /*
    public void sendTrap(int playerNum, int trapNumber) {
    
    
    }
    */

    int GetAvailableGridPosition()
    {
        Vector3 pos;
        int gridNumber = 0;
        bool foundAvailablePosition = false;

        while (!foundAvailablePosition)
        {
            gridNumber = Random.Range(0, spawnzonesArray.Length-1);

            if (spawnzonesInUseArray[gridNumber] == false)
            {
                foundAvailablePosition = true;
                spawnzonesInUseArray[gridNumber] = true;

            }

        }

        return gridNumber;
    }

    public bool[] GetSpawnzonesInUseArray()
    {
        return spawnzonesInUseArray;
    }

    public void SetSpawnzonesInUseArray(int gridNumber, bool val)
    {
        spawnzonesInUseArray[gridNumber] = val;
    }
}
