using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class BallBehaviour : MonoBehaviour
{
    //public int playerOwnership;
    GameObject gameManager;
    public GameObject gridManager;
    public int playerNumber;

    ModifierSync modifierSync;

    Vector3 startPos;
    Vector3 minPos;
    Vector3 maxPos;
    float cubeSize;
    public Vector3 currentPos;
    Vector3 instantiatePosition = new Vector3(0, -100, 0);
    public Vector3 dir;
    float randomDirectionAmount = 0.5f;
    
    public float speed = .05f;
    public int gridPosition;

    bool isBallSpawned;
    public bool isBallActive = false;

    public static float cooldown = 3;

    Vector3 OppositePosition;
    Quaternion OppositeRotation;

    public Material bombMat;
    public Material mineMat;
    public Material oneColorMat;
    public Material sizeSpeedMat;
    public Material randomizeColorMat;
    public Material shieldMat;

    public GameObject overlayObject;

    bool isPowerup;
    bool isBomb;
    bool isMine;


    public int modifier;
    public int oldModifier;

    public GameObject overlay;

    // Start is called before the first frame update
    void Start()
    {
        modifierSync = GetComponent<ModifierSync>();


        //Vector3 rotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        //transform.rotation = Quaternion.Euler(rotation);

        //dir = transform.right;
        dir = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        
    }

    public IEnumerator SpawnBall(int gridNumber, Vector3 pos)
    {
        gridPosition = gridNumber;
        isBallActive = true;
        
        yield return new WaitForSeconds(cooldown);

        isBallSpawned = true;
        transform.position = pos;
        startPos = pos;
        
        float spacing = GridManager.gridSpacing / 2;
        maxPos = new Vector3(startPos.x + spacing - transform.lossyScale.x, startPos.y + spacing - transform.lossyScale.y, startPos.z + spacing - transform.lossyScale.z);
        minPos = new Vector3(startPos.x - spacing + transform.lossyScale.x, startPos.y - spacing + transform.lossyScale.y, startPos.z - spacing + transform.lossyScale.z);


    }

    public void DespawnBall()
    {
        
        if (playerNumber == 1)
        {
            OppositePosition = GameManagerLogic.roomClient.transform.position;
            OppositeRotation = GameManagerLogic.roomClient.transform.rotation;

        } else if (playerNumber == 2)
        {
            OppositePosition = GameManagerLogic.roomServer.transform.position;
            OppositeRotation = GameManagerLogic.roomServer.transform.rotation;
        }

        

        switch (modifier)
        {
            case 0:
                //nothing happens - regular cube
                break;
            case 1:
                //bomb
                Realtime.Instantiate("Bomb", OppositePosition, OppositeRotation, new Realtime.InstantiateOptions
                {
                    ownedByClient = false,
                    preventOwnershipTakeover = false,
                    destroyWhenOwnerLeaves = false,
                    destroyWhenLastClientLeaves = true
                });
                break;
            case 2:
                //mine
                Realtime.Instantiate("Mine", OppositePosition, OppositeRotation, new Realtime.InstantiateOptions
                {
                    ownedByClient = false,
                    preventOwnershipTakeover = false,
                    destroyWhenOwnerLeaves = false,
                    destroyWhenLastClientLeaves = true
                });
                break;
            case 3:
                //One Color All
                gridManager.GetComponent<GridManager>().SetOneColorAll(5);
                
                break;
            case 4:
                //Transform size and speed
                gridManager.GetComponent<GridManager>().SetEasierToHit(5);
                if (playerNumber == 1)
                {
                    GameManagerLogic.roomClient.GetComponentInChildren<GridManager>().SetHarderToHit(5);
                }
                if (playerNumber == 2)
                {
                    GameManagerLogic.roomServer.GetComponentInChildren<GridManager>().SetHarderToHit(5);
                }

                break;
            case 5:
                
                GameManagerLogic.roomClient.GetComponentInChildren<GridManager>().RandomColor();
                GameManagerLogic.roomServer.GetComponentInChildren<GridManager>().RandomColor();

                //randomize own and opponent colors

                break;
            case 6:
                //shield maybe use backupvar 2 for shield bool

                break;
            case 7:
                //maybe a random question mark trap that can summon a trap for yourself or opponent or mystery item

                break;
            case 8:

                break;

            




        }

        if (overlay != null)
        {
            Destroy(overlay.gameObject);

        }

        GetComponent<ModifierSync>().SetModifier(0);
        //maybe request permission to be able to move the box/ball
        StartCoroutine(resetBallPosition(gameObject, 1));
        
        


        //GridManager gm = GetComponentInParent<GridManager>();
        //gm.SetSpawnzonesInUseArray(gridPosition, false);

    }

    

    IEnumerator resetBallPosition(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.GetComponent<MeshRenderer>().enabled = true;
        obj.GetComponent<BoxCollider>().enabled = true;
        GetComponentInChildren<MeshRenderer>().enabled = true;
        transform.position = instantiatePosition;
        isBallSpawned = false;
        isBallActive = false;

        

    }

    public void SetModifier(int mod)
    {
        modifier = mod;
        
    }

    // Update is called once per frame
    void Update()
    {
        modifier = modifierSync.GetModifier();

        if (modifier != oldModifier && modifier != 0)
        {
            if (overlay != null)
            {
                Destroy(overlay.gameObject);
            }
            overlay = Instantiate(overlayObject, transform.position, transform.rotation);


            overlay.transform.localScale = transform.localScale * 1.01f * 2;
            overlay.transform.SetParent(gameObject.transform);
            oldModifier = modifier;
            

            switch (modifier)
            {

                case 1:
                    overlay.GetComponent<MeshRenderer>().material = bombMat;
                    break;
                case 2:
                    overlay.GetComponent<MeshRenderer>().material = mineMat;
                    break;
                case 3:
                    overlay.GetComponent<MeshRenderer>().material = oneColorMat;
                    break;
                case 4:
                    overlay.GetComponent<MeshRenderer>().material = sizeSpeedMat;
                    break;
                case 5:
                    overlay.GetComponent<MeshRenderer>().material = randomizeColorMat;
                    break;
                case 6:
                    overlay.GetComponent<MeshRenderer>().material = shieldMat;
                    break;


            }
        }
        


        if (!GameManagerLogic.isServer) {
            return;
        }
        if (!isBallSpawned) return;
        
        currentPos = transform.position;
        
        dir = dir.normalized;

        if (currentPos.x > maxPos.x && dir.x > 0)
        {
            dir.x *= -1;
        }
        else if (currentPos.x < minPos.x && dir.x < 0)
        {
            dir.x *= -1;
        }


        if (currentPos.y > maxPos.y && dir.y > 0)
        {
            dir.y *= -1;
        }
        else if (currentPos.y < minPos.y && dir.y < 0)
        {
            dir.y *= -1;
        }

        
        if (currentPos.z > maxPos.z && dir.z > 0)
        {
            dir.z *= -1;
        }
        else if (currentPos.z < minPos.z && dir.z < 0)
        {
            dir.z *= -1;
        }

        transform.position += dir.normalized * Time.deltaTime * speed;

    }
}
