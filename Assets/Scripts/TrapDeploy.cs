using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDeploy : MonoBehaviour
{
    public Material floorMat;
    public Material warningMat;

    public bool didNotDeploy = true;
    public GameObject spikes;
    GameObject tempTrap;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (didNotDeploy)
        {
            spawnTrap();
        }
        didNotDeploy = false;
        
    }

    void spawnTrap()
    {
        this.GetComponent<MeshRenderer>().material = warningMat;
        // conditional logic
        tempTrap = Instantiate(spikes, new Vector3(transform.position.x, transform.position.y - 0.35f, transform.position.z), transform.rotation);
        // Play sound of trap getting ready (build up)
        StartCoroutine(WaitAndTriggerTrap());
        // Play sound of trap triggering (snap)


    }

    IEnumerator WaitAndTriggerTrap()
    {
        yield return new WaitForSecondsRealtime(5);
        tempTrap.transform.position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
        Debug.Log("Trap deployed");
        this.GetComponent<MeshRenderer>().material = floorMat;
    }

}
