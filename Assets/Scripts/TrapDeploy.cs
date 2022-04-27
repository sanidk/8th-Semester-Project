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
    public Material laserChargeMat;
    public Material laserDischargeMat; 
    GameObject tempTrap;
    GameObject smallTempTrap;
    public GameObject spikes;
    public GameObject pendulum;
    public GameObject laser;

    int selectedTrap;
    Quaternion spawnRotation = Quaternion.Euler(0,0,90);

    // Start is called before the first frame update
    void Start()
    {
        //gridManager = GetComponent<GridManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        floorMat = Resources.Load<Material>("Floor");
        warningMat = Resources.Load<Material>("PulseMat");
        laserChargeMat = Resources.Load<Material>("LaserCharge");
        laserDischargeMat = Resources.Load<Material>("LaserDischarge");
        spikes = Resources.Load("SpearTrap") as GameObject;
        pendulum = Resources.Load("MaceTrapPivot") as GameObject;
        laser = Resources.Load("Laser") as GameObject; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnSmallTrap() {
        smallTempTrap = Realtime.Instantiate("Laser", new Vector3(transform.position.x, transform.position.y + 0.35f, transform.position.z), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });

        StartCoroutine(WaitAndTriggerSmallTrap());
    }

    public void spawnTrap(int typeOfTrap)
    {
        
        selectedTrap = typeOfTrap;
        /*
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
        */

        if (typeOfTrap == 0) {
            tempTrap = Realtime.Instantiate("SpearTrap", new Vector3(transform.position.x, transform.position.y - 0.35f, transform.position.z), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
        } else if (typeOfTrap == 1 && this.name == "Trap0" || this.name == "Trap1" ) {
            tempTrap = Realtime.Instantiate("MaceTrapPivot", new Vector3(transform.position.x + 0.50f, transform.position.y + 4.5f, transform.position.z), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            tempTrap.transform.rotation *= spawnRotation;
        } else if (typeOfTrap == 1 && this.name == "Trap2" || this.name == "Trap3") {
            tempTrap = Realtime.Instantiate("MaceTrapPivot", new Vector3(transform.position.x - 0.50f, transform.position.y + 4.5f, transform.position.z), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
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
            yield return new WaitForSecondsRealtime(1.5f);
        }

        Realtime.Destroy(tempTrap);
    }

    IEnumerator WaitAndTriggerSmallTrap() {
        yield return new WaitForSecondsRealtime(5);
        smallTempTrap.GetComponent<MeshRenderer>().material = laserDischargeMat;
        yield return new WaitForSecondsRealtime(2);
        Realtime.Destroy(smallTempTrap);
    }
}
