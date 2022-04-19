using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class TrapDeploy : MonoBehaviour
{
    GridManager gridManager;
    MeshRenderer meshRenderer;
    public Material floorMat;
    public Material warningMat;
    GameObject tempTrap;
    public GameObject spikes;
    public GameObject pendulum;

    int selectedTrap;
    Quaternion spawnRotation = Quaternion.Euler(0,0,90);

    // Start is called before the first frame update
    void Start()
    {
        gridManager = GetComponent<GridManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        floorMat = Resources.Load<Material>("Lit");
        warningMat = Resources.Load<Material>("PulseMat");
        spikes = Resources.Load("SpearTrap") as GameObject;
        pendulum = Resources.Load("PendulumTrap") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void spawnTrap(int typeOfTrap)
    {
        selectedTrap = typeOfTrap;
        if (selectedTrap == 0) {
            this.GetComponentInParent<MeshRenderer>().material = warningMat;
        } else if (selectedTrap == 1) {
            if (this.name == "Trap0") {
                this.GetComponentInParent<MeshRenderer>().material = warningMat;
                this.transform.parent.Find("Trap2").GetComponentInParent<MeshRenderer>().material = warningMat;
            } else if (this.name == "Trap2") {
                this.GetComponentInParent<MeshRenderer>().material = warningMat;
                this.transform.parent.Find("Trap0").GetComponentInParent<MeshRenderer>().material = warningMat;
            }
            if (this.name == "Trap1") {
                this.GetComponentInParent<MeshRenderer>().material = warningMat;
                this.transform.parent.Find("Trap3").GetComponentInParent<MeshRenderer>().material = warningMat;
            } else if (this.name == "Trap3") {
                this.GetComponentInParent<MeshRenderer>().material = warningMat;
                this.transform.parent.Find("Trap1").GetComponentInParent<MeshRenderer>().material = warningMat;
            }
        }

        if (typeOfTrap == 0) {
            tempTrap = Instantiate(spikes, new Vector3(transform.position.x, transform.position.y - 0.35f, transform.position.z), transform.rotation);
        } else if (typeOfTrap == 1 && this.name == "Trap0" || this.name == "Trap1" ) {
            tempTrap = Instantiate(pendulum, new Vector3(transform.position.x + 0.50f, transform.position.y + 1.25f, transform.position.z), transform.rotation);
            tempTrap.transform.rotation *= spawnRotation;
        } else if (typeOfTrap == 1 && this.name == "Trap2" || this.name == "Trap3") {
            tempTrap = Instantiate(pendulum, new Vector3(transform.position.x - 0.50f, transform.position.y + 1.25f, transform.position.z), transform.rotation);
            tempTrap.transform.rotation *= spawnRotation;
        }

        // Play sound of trap getting ready (build up)
        StartCoroutine(WaitAndTriggerTrap());
        // Play sound of trap triggering (snap)
    }

    IEnumerator WaitAndTriggerTrap()
    {
        yield return new WaitForSecondsRealtime(5);
        if (selectedTrap == 0) {
            tempTrap.transform.position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
            yield return new WaitForSecondsRealtime(2);
        } else if (selectedTrap == 1) {
            tempTrap.transform.GetChild(0).gameObject.AddComponent<PendulumMovement>();
            yield return new WaitForSecondsRealtime(6);
        }

        this.transform.parent.Find("Trap0").GetComponentInParent<MeshRenderer>().material = floorMat;
        this.transform.parent.Find("Trap1").GetComponentInParent<MeshRenderer>().material = floorMat;
        this.transform.parent.Find("Trap2").GetComponentInParent<MeshRenderer>().material = floorMat;
        this.transform.parent.Find("Trap3").GetComponentInParent<MeshRenderer>().material = floorMat;

        Destroy(tempTrap);
        
    }
}

