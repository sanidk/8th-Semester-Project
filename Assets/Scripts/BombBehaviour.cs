using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class BombBehaviour : MonoBehaviour
{

    public int playerSide;

    //public int playerOwnership;
    GameObject gameManager;
    GameObject gridManager;

    Vector3 startPos;
    Vector3 minPos;
    Vector3 maxPos;
    public Vector3 currentPos;
    Vector3 instantiatePosition = new Vector3(0, -100, 0);
    public Vector3 dir;
    float randomDirectionAmount = 0.5f;

    float speed = .05f;
    public int gridPosition;
    float spacing = 1f;

    bool isBallSpawned;
    public bool isBallActive = false;

    public static float cooldown = 3;

    float spawnTime;
    public float eventTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        if (!GameManagerLogic.isServer)
        {
            return;
        }

        spawnTime = Time.time;

        dir = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        maxPos = new Vector3(startPos.x + spacing, startPos.y + spacing, startPos.z + spacing);
        minPos = new Vector3(startPos.x - spacing, startPos.y - spacing, startPos.z - spacing);

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManagerLogic.isServer)
        {
            return;
        }

        if (Time.time > spawnTime + eventTime)
        {
            if (gameObject.CompareTag("Bomb"))
            {
                //EXPLODE
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

    

    public void Trigger()
    {
        if (!GameManagerLogic.isServer)
        {
            return;
        }

        if (gameObject.CompareTag("Bomb"))
        {
            //print("Bomb");
            Despawn();
            //DISARM
        }

        if (gameObject.CompareTag("Mine"))
        {
            //print("Mine");
            Explode();
        }

        Despawn();
    }

    public void Despawn()
    {
        

        Realtime.Destroy(gameObject);
    }

    private void Explode()
    {
        //throw new System.NotImplementedException();

        Despawn();
        //remove life by explosion.
    }


}
