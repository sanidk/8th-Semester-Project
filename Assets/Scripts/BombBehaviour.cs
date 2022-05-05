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
    Vector3 instantiatePosition = new Vector3(0, -100, 0);
    public Vector3 dir;
    float randomDirectionAmount = 0.5f;

    AudioSource audioSource;
    public AudioClip explosionClip;


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

    public GameObject explosionSoundPrefab;
    // Start is called before the first frame update
    void Start()
    {
        originalMat = gameObject.GetComponent<MeshRenderer>().material;
        mat = new Material(originalMat);
        gameObject.GetComponent<MeshRenderer>().material = mat;
        try
        {
            gameObject.GetComponentInChildren<MeshRenderer>().material = mat;
        } catch (UnassignedReferenceException)
        {
            
        }
        
        audioSource = GetComponent<AudioSource>();
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
            gameObject.GetComponent<MeshRenderer>().material = originalMat;
            try
            {
                gameObject.GetComponentInChildren<MeshRenderer>().material = mat;
            }
            catch (UnassignedReferenceException)
            {

            }
            GetComponent<SphereCollider>().enabled = true;
            isMatReset = true;
        } else
        {
            float sineAlpha = Mathf.Sin(Time.time*4);
            Color color = new Color(originalMat.color.r, originalMat.color.g, originalMat.color.b, sineAlpha);
            
            mat.color = color;
        }


        


        if (!GameManagerLogic.isServer)
        {
            return;
        }





        if (Time.time > spawnTime + eventTime)
        {
            if (gameObject.CompareTag("Bomb"))
            {
                //explode = true;
                if (playerOwner == 1)
                {
                    GameManagerLogic.player1.GetComponent<PlayerStat>()._lives--;

                } else if (playerOwner == 2)
                {
                    GameManagerLogic.player2.GetComponent<PlayerStat>()._lives--;
                }

                //Instantiate(explosionSoundPrefab);
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
            GameManagerLogic.player1.GetComponent<PlayerStat>()._lives--;

        }
        else if (playerOwner == 2)
        {
            GameManagerLogic.player2.GetComponent<PlayerStat>()._lives--;
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
