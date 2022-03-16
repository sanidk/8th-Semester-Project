using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AgentSpawner : MonoBehaviour
{

    public int amountOfAgents = 50;
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
                new Vector3(-2, 1, 0) + Random.insideUnitSphere,
                Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)),
                transform
                );
            newAgent.name = "Agent" + i;
            agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
