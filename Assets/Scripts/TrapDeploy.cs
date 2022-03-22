using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDeploy : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public Material floorMat;
    public Material warningMat;
    GameObject tempTrap;
    public GameObject spikes;

    public int nextTrap = 10;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        floorMat = Resources.Load<Material>("Floor");
        warningMat = Resources.Load<Material>("PulseMat");
        spikes = Resources.Load("SpearTrap") as GameObject;

        
    }

    // Update is called once per frame
    void Update()
    {   

        if (Time.time > nextTrap)
        {
            spawnTrap();
            nextTrap += 10;
        }

    }

    public void spawnTrap()
    {
        this.GetComponentInParent<MeshRenderer>().material = warningMat;
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
        gameObject.GetComponentInParent<MeshRenderer>().material = floorMat;
        yield return new WaitForSecondsRealtime(2);
        Destroy(tempTrap);
    }
}
