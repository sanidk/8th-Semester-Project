using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class BombBehaviour : MonoBehaviour
{

    public int playerOwner;
    public Dictionary<int, RealtimeAvatar> avatars;

    //public int playerOwnership;
    GameObject gameManager;
    GameObject gridManager;
    public Vector3 midPos;
    Vector3 startPos;
    Vector3 minPos;
    Vector3 maxPos;
    public Vector3 currentPos;
    Vector3 initialPosition;
    Vector3 instantiatePosition = new Vector3(0, -100, 0);
    public Vector3 dir;
    Vector3 initialDirection;
    bool isTargetPosReached;
    float randomDirectionAmount = 0.5f;

    AudioSource audioSource;
    public AudioClip explosionClip;

    public Vector3 targetPosition;
    bool isMatReset;

    float speed = .05f;
    public int gridPosition;
    float spacing = 1f;

    bool isBallSpawned;
    public bool isBallActive = false;

    public static float cooldown = 3;
    bool explode;
    float spawnTime;
    float eventTime = 10;
    Material mat;
    Material originalMat;
    public GameObject textMeshObj;
    public Transform countDownTransform;
    private GameObject CD_Copy;

    float redval = 0;

    public GameObject explosionSoundPrefab;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        
        originalMat = gameObject.GetComponent<MeshRenderer>().material;
        mat = new Material(originalMat);
        gameObject.GetComponent<MeshRenderer>().material = mat;
        //try
        //{
        //    gameObject.GetComponentInChildren<MeshRenderer>().material = mat;
        //} catch (UnassignedReferenceException)
        //{
            
        //}
        
        spawnTime = Time.time;


        dir = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        maxPos = new Vector3(midPos.x + spacing, midPos.y + spacing, midPos.z + spacing);
        minPos = new Vector3(midPos.x - spacing, midPos.y - spacing, midPos.z - spacing);

    }

    // Update is called once per frame
    void Update()
    {

        if (!isMatReset && Time.time > spawnTime + 2)
        {
            //gameObject.GetComponent<MeshRenderer>().material = originalMat;
            //try
            //{
            //    gameObject.GetComponentInChildren<MeshRenderer>().material = mat;
            //}
            //catch (UnassignedReferenceException)
            //{

            //}

            GetComponent<SphereCollider>().enabled = true;
            isMatReset = true;
        } else
        {
            float sineAlpha = Mathf.Sin(Time.time*4);
            Color color = new Color(originalMat.color.r, originalMat.color.g, originalMat.color.b, sineAlpha);
            
            mat.color = color;
        }


        

        /*
        if (!GameManagerLogic.isServer)
        {
            return;
        }
        */

        if (GameManagerLogic.isSendFeedbackEnabled)
        {
            transform.position = targetPosition;

        } else
        {
            if (!isTargetPosReached)
            {

                float elapsedTime = Time.time - spawnTime;
                transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / 2);
                if (elapsedTime > 2)
                {
                    GetComponent<TrailRenderer>().enabled = false;
                    //CD_Copy = Instantiate(textMeshObj, gameObject.transform, true); // make copy of textPrefab
                    //CD_Copy.GetComponent<DestroyXSec>().lifeTime = eventTime;
                    //CD_Copy.transform.position = countDownTransform.position;
                    if(playerOwner == 1)
                    {
                        CD_Copy = Instantiate(textMeshObj, gameObject.transform, true); // make copy of textPrefab
                        CD_Copy.GetComponent<DestroyXSec>().lifeTime = eventTime;
                        CD_Copy.GetComponent<TextMesh>().color = Color.white;
                        CD_Copy.transform.position = countDownTransform.position;
                        Vector3 direction = GameManagerLogic.player2.transform.GetChild(0).transform.position - CD_Copy.transform.position;
                        direction = direction.normalized;
                        CD_Copy.transform.rotation = Quaternion.LookRotation(direction);
                        CD_Copy.transform.rotation *= Quaternion.AngleAxis(180, Vector3.up);
                    }
                    else if (playerOwner == 2)
                    {
                        CD_Copy = Instantiate(textMeshObj, gameObject.transform, true); // make copy of textPrefab
                        CD_Copy.GetComponent<DestroyXSec>().lifeTime = eventTime;
                        CD_Copy.GetComponent<TextMesh>().color = Color.white;
                        CD_Copy.transform.position = countDownTransform.position;
                        Vector3 direction = GameManagerLogic.player1.transform.GetChild(0).transform.position - CD_Copy.transform.position;
                        direction = direction.normalized;
                        CD_Copy.transform.rotation = Quaternion.LookRotation(direction);
                        CD_Copy.transform.rotation *= Quaternion.AngleAxis(180, Vector3.up);

                    }
                    isTargetPosReached = true;
                }
                return;
            }
        }

        if (isTargetPosReached && (Time.time - spawnTime) < eventTime && CD_Copy != null)
        {
            float elapsedTime = Time.time - spawnTime;
            if ((eventTime - elapsedTime) < 3)
            {
                CD_Copy.GetComponent<TextMesh>().color = Color.red;
                //mby audio here as well?
            }
            CD_Copy.GetComponent<TextMesh>().text = ((int)eventTime - (int)elapsedTime).ToString();
        }
        
        

        
        if (Time.time > spawnTime + eventTime)
        {
            if (gameObject.CompareTag("Bomb"))
            {
                //explode = true;
                print(playerOwner);
                if (playerOwner == 1)
                {
                    GameManagerLogic.player2.GetComponent<PlayerStat>()._lives--;

                } else if (playerOwner == 2)
                {
                    GameManagerLogic.player1.GetComponent<PlayerStat>()._lives--;
                }

                GameObject audioObject = Realtime.Instantiate("explodeAudioPrefab", transform.position, transform.rotation, new Realtime.InstantiateOptions
                {
                    ownedByClient = true,
                    preventOwnershipTakeover = true,
                    destroyWhenOwnerLeaves = false,
                    destroyWhenLastClientLeaves = true
                });
                Despawn();
            }

            if (gameObject.CompareTag("Mine"))
            {
                
                Despawn();
            }

        } 
        //if (!isBallSpawned) return;

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

    

    public void TriggerMine()
    {
        explode = true;
        if (playerOwner == 1)
        {
            GameManagerLogic.player2.GetComponent<PlayerStat>()._lives--;
        }
        else if (playerOwner == 2)
        {
            GameManagerLogic.player1.GetComponent<PlayerStat>()._lives--;
        }
        GameObject audioObject = Realtime.Instantiate("explodeAudioPrefab", transform.position, transform.rotation, new Realtime.InstantiateOptions
        {
            ownedByClient = true,
            preventOwnershipTakeover = true,
            destroyWhenOwnerLeaves = false,
            destroyWhenLastClientLeaves = true
        });
        Despawn();

    }


    public void Despawn()
    {
        Realtime.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GameManagerLogic.isServer)
        {
            return;
        }
        
        if (gameObject.CompareTag("Mine"))
        {
            print("mine collision with player");
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                other.gameObject.GetComponent<PlayerStat>()._lives--;
                GameObject audioObject = Realtime.Instantiate("explodeAudioPrefab", transform.position, transform.rotation, new Realtime.InstantiateOptions
                {
                    ownedByClient = true,
                    preventOwnershipTakeover = true,
                    destroyWhenOwnerLeaves = false,
                    destroyWhenLastClientLeaves = true
                });
                Despawn();
            }
        }
        
    }


}
