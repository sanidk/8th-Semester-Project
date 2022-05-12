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
    GameObject tempWarning;
    GameObject smallTempTrap;
    public GameObject spikes;
    public GameObject pendulum;
    public GameObject laser;

    public Material warningRed;
    public Material warningYellow;
    public Material warningGreen;
    public Material warningBlue;

    public GameObject[] bullets;
    float zOffset = -3f;

    public AudioSource audioSource;
    public AudioClip warningSound;
    public AudioClip spearTrapSound;
    public AudioClip maceAndFistSound;

    int selectedTrap;
    Quaternion spawnRotation = Quaternion.Euler(0,0,90);

    // Start is called before the first frame update
    void Start()
    {
        //gridManager = GetComponent<GridManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        floorMat = Resources.Load<Material>("Floor");
        warningMat = Resources.Load<Material>("ForceField");
        laserChargeMat = Resources.Load<Material>("LaserCharge");
        laserDischargeMat = Resources.Load<Material>("LaserDischarge");
        spikes = Resources.Load("SpearTrap") as GameObject;
        pendulum = Resources.Load("MaceTrapPivot") as GameObject;
        laser = Resources.Load("Laser") as GameObject; 

        bullets = new GameObject[3]; 

        warningRed = Resources.Load<Material>("ForceFieldRed");
        warningYellow = Resources.Load<Material>("ForceFieldYellow");
        warningGreen = Resources.Load<Material>("ForceFieldGreen");
        warningBlue = Resources.Load<Material>("ForceFieldBlue");

        audioSource = GetComponentInChildren<AudioSource>();
        warningSound = Resources.Load("alarm") as AudioClip;
        spearTrapSound = Resources.Load("spearTrapSound") as AudioClip;
        maceAndFistSound = Resources.Load("maceAndFistTrapSound") as AudioClip;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
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
    */

    public void spawnTrap(int typeOfTrap)
    {
        
        selectedTrap = typeOfTrap;
        
        if (selectedTrap == 0) {
            tempWarning = Realtime.Instantiate("SmallWarningObj", new Vector3(transform.position.x, transform.position.y + 0.45f, transform.position.z), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            for (int i = 0; i < 4; i++) {
                tempWarning.transform.GetChild(i).GetComponent<MeshRenderer>().material = warningRed;
                tempWarning.transform.GetChild(i).Rotate(0,0,90);
            }
        } else if (selectedTrap == 2) {
            tempWarning = Realtime.Instantiate("SmallWarningObj", new Vector3(transform.position.x, transform.position.y + 0.45f, transform.position.z), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            for (int i = 0; i < 4; i++) {
                tempWarning.transform.GetChild(i).GetComponent<MeshRenderer>().material = warningGreen;
                tempWarning.transform.GetChild(i).Rotate(0,0,270);
            }

        } else if (selectedTrap == 1) {
            if (this.name == "Trap0" || this.name == "Trap1") {
                tempWarning = Realtime.Instantiate("BigWarningObj", new Vector3(transform.position.x + 0.5f, transform.position.y + 0.25f, transform.position.z), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            for (int i = 0; i < 6; i++) {
                tempWarning.transform.GetChild(i).GetComponent<MeshRenderer>().material = warningYellow;
            }
        } else if (this.name == "Trap2" || this.name == "Trap3") {
                tempWarning = Realtime.Instantiate("BigWarningObj", new Vector3(transform.position.x - 0.5f, transform.position.y + 0.25f, transform.position.z), transform.rotation, new Realtime.InstantiateOptions
                {
                    ownedByClient = false,
                    preventOwnershipTakeover = false,
                    destroyWhenOwnerLeaves = false,
                    destroyWhenLastClientLeaves = true
                });
            for (int i = 0; i < 6; i++) {
                tempWarning.transform.GetChild(i).GetComponent<MeshRenderer>().material = warningYellow;
            }
        }
        } else if (selectedTrap == 3) {
            if (this.name == "Trap0" || this.name == "Trap1") {
                tempWarning = Realtime.Instantiate("BigWarningObj", new Vector3(transform.position.x + 0.425f, transform.position.y + 0.25f, transform.position.z), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            for (int i = 0; i < 6; i++) {
                tempWarning.transform.GetChild(i).GetComponent<MeshRenderer>().material = warningBlue;
            }
        } else if (this.name == "Trap2" || this.name == "Trap3") {
            tempWarning = Realtime.Instantiate("BigWarningObj", new Vector3(transform.position.x - 0.425f, transform.position.y + 0.25f, transform.position.z), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            for (int i = 0; i < 6; i++) {
                tempWarning.transform.GetChild(i).GetComponent<MeshRenderer>().material = warningBlue;
            }
        }
        }

        //tempWarning.GetComponentsInChildren<MeshRenderer>();
        
        
        
        /*
        if (selectedTrap == 3 && gameObject.transform.root.name == "RoomPlayer2") {
            tempWarning.transform.rotation = Quaternion.Euler(0,0,180);
        }
        */
        
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
        } else if (typeOfTrap == 1 && this.name == "Trap0" || typeOfTrap == 1 && this.name == "Trap1" ) {
            tempTrap = Realtime.Instantiate("MaceTrapPivot", new Vector3(transform.position.x + 0.50f, transform.position.y + 4.5f, transform.position.z), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            tempTrap.transform.rotation *= spawnRotation;
        } else if (typeOfTrap == 1 && this.name == "Trap2" || typeOfTrap == 1 && this.name == "Trap3") {
            tempTrap = Realtime.Instantiate("MaceTrapPivot", new Vector3(transform.position.x - 0.50f, transform.position.y + 4.5f, transform.position.z), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            tempTrap.transform.rotation *= spawnRotation;
        } else if (typeOfTrap == 2) {
            tempTrap = Realtime.Instantiate("FistTrap", new Vector3(transform.position.x + 1.15f, transform.position.y + 4, transform.position.z), Quaternion.Euler(0,0,270), new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
        } else if (typeOfTrap == 3 && this.name == "Trap0" && gameObject.transform.root.name == "RoomPlayer2") {
            tempTrap = Realtime.Instantiate("BulletTrap", new Vector3(transform.position.x - 1.5f, transform.position.y + 0.55f, transform.position.z), Quaternion.Euler(0,0,90), new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            placeBullets(tempTrap.transform);
        } else if (typeOfTrap == 3 && this.name == "Trap1" && gameObject.transform.root.name == "RoomPlayer2") {
            tempTrap = Realtime.Instantiate("BulletTrap", new Vector3(transform.position.x - 1.5f, transform.position.y + 0.55f, transform.position.z), Quaternion.Euler(0,0,90), new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            placeBullets(tempTrap.transform);
        } else if (typeOfTrap == 3 && this.name == "Trap2" && gameObject.transform.root.name == "RoomPlayer2") {
            tempTrap = Realtime.Instantiate("BulletTrap", new Vector3(transform.position.x - 2.5f, transform.position.y + 0.55f, transform.position.z), Quaternion.Euler(0,0,90), new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            placeBullets(tempTrap.transform);
        } else if (typeOfTrap == 3 && this.name == "Trap3" && gameObject.transform.root.name == "RoomPlayer2") {
            tempTrap = Realtime.Instantiate("BulletTrap", new Vector3(transform.position.x - 2.5f, transform.position.y + 0.55f, transform.position.z), Quaternion.Euler(0,0,90), new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            placeBullets(tempTrap.transform);
        } else if (typeOfTrap == 3 && this.name == "Trap0" && gameObject.transform.root.name == "RoomPlayer1") {
            tempTrap = Realtime.Instantiate("BulletTrap", new Vector3(transform.position.x + 2.5f, transform.position.y + 0.55f, transform.position.z), Quaternion.Euler(180,180,90), new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            placeBullets(tempTrap.transform);
        } else if (typeOfTrap == 3 && this.name == "Trap1" && gameObject.transform.root.name == "RoomPlayer1") {
            tempTrap = Realtime.Instantiate("BulletTrap", new Vector3(transform.position.x + 2.5f, transform.position.y + 0.55f, transform.position.z), Quaternion.Euler(180,180,90), new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            placeBullets(tempTrap.transform);
        } else if (typeOfTrap == 3 && this.name == "Trap2" && gameObject.transform.root.name == "RoomPlayer1") {
            tempTrap = Realtime.Instantiate("BulletTrap", new Vector3(transform.position.x + 1.5f, transform.position.y + 0.55f, transform.position.z), Quaternion.Euler(180,180,90), new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            placeBullets(tempTrap.transform);
        } else if (typeOfTrap == 3 && this.name == "Trap3" && gameObject.transform.root.name == "RoomPlayer1") {
            tempTrap = Realtime.Instantiate("BulletTrap", new Vector3(transform.position.x + 1.5f, transform.position.y + 0.55f, transform.position.z), Quaternion.Euler(180,180,90), new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            placeBullets(tempTrap.transform);
        }
        
        Debug.Log("Root is: " + gameObject.transform.root);
        Debug.Log("Trap is: " + gameObject.name);
        // Play sound of trap getting ready (build up)
        StartCoroutine(WaitAndTriggerTrap(tempWarning, tempTrap));
        // Play sound of trap triggering (snap)
    }

    IEnumerator WaitAndTriggerTrap(GameObject tempWarning, GameObject tempTrap)
    {
        yield return new WaitForSecondsRealtime(5);
        if (selectedTrap == 0) {
            tempTrap.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            tempTrap.GetComponent<Collider>().enabled = true;
            audioSource = tempTrap.GetComponent<AudioSource>();
            audioSource.PlayOneShot(spearTrapSound, 0.5f);
            yield return new WaitForSecondsRealtime(2);
        } else if (selectedTrap == 1) {
            tempTrap.transform.GetChild(0).gameObject.AddComponent<PendulumMovement>();
            audioSource = tempTrap.GetComponent<AudioSource>();
            audioSource.PlayOneShot(maceAndFistSound, 0.5f);
            yield return new WaitForSecondsRealtime(1.5f);
        } else if (selectedTrap == 2) {
            tempTrap.GetComponent<Rigidbody>().useGravity = true;
            tempTrap.GetComponent<Rigidbody>().isKinematic = false;
            audioSource = tempTrap.GetComponent<AudioSource>();
            audioSource.PlayOneShot(maceAndFistSound, 0.5f);
            yield return new WaitForSecondsRealtime(2);
        } else if (selectedTrap == 3) {
            for (int i = 0; i < 3; i++) {  
                bullets[i].GetComponent<Rigidbody>().isKinematic = false;
                yield return new WaitForSecondsRealtime(1);
            }
            yield return new WaitForSecondsRealtime(1.5f);
        }

        Realtime.Destroy(tempWarning);
        Realtime.Destroy(tempTrap);
    }

    /*
    IEnumerator WaitAndTriggerSmallTrap() {
        yield return new WaitForSecondsRealtime(5);
        smallTempTrap.GetComponent<MeshRenderer>().material = laserDischargeMat;
        yield return new WaitForSecondsRealtime(2);
        Realtime.Destroy(smallTempTrap);
    }
    */

    public void placeBullets(Transform bulletParent) {
        for (int i = 0; i < 3; i++) {
            float randomFloat = Random.Range(-0.5f, 3f);
            if (gameObject.transform.root.name == "RoomPlayer1") {
                bullets[i] = Realtime.Instantiate("TheBullet", new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0,0,90), new Realtime.InstantiateOptions
                {
                    ownedByClient = false,
                    preventOwnershipTakeover = false,
                    destroyWhenOwnerLeaves = false,
                    destroyWhenLastClientLeaves = true
                });
            } else if (gameObject.transform.root.name == "RoomPlayer2") {
                bullets[i] = Realtime.Instantiate("TheBullet", new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0,0,-90), new Realtime.InstantiateOptions
                {
                    ownedByClient = false,
                    preventOwnershipTakeover = false,
                    destroyWhenOwnerLeaves = false,
                    destroyWhenLastClientLeaves = true
                });
            }
            bullets[i].transform.SetParent(bulletParent);
            bullets[i].transform.localPosition = new Vector3(randomFloat,0,zOffset);
            bullets[i].AddComponent<BulletBehaviour>();
            zOffset += 3f;
        }
    }
}
