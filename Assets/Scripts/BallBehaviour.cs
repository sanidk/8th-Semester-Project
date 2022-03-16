using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    GameObject gridManager;

    Vector3 startPos;
    Vector3 minPos;
    Vector3 maxPos;
    public Vector3 currentPos;

    public Vector3 dir;
    float randomDirectionAmount = 0.5f;

    float speed = .05f;
    public int gridPosition;

    public bool isBallActive = false;
    public bool isBallMoving = false;
    
    public static float cooldown = 3;


    // Start is called before the first frame update
    void Start()
    {


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
        transform.position = pos;
        startPos = transform.position;
        float spacing = GridManager.gridSpacing / 2;
        maxPos = new Vector3(startPos.x + spacing, startPos.y + spacing, startPos.z + spacing);
        minPos = new Vector3(startPos.x - spacing, startPos.y - spacing, startPos.z - spacing);


    }

    public void DespawnBall()
    {
        isBallActive = false;
        transform.position = startPos;
        GridManager gm = GetComponentInParent<GridManager>();
        gm.SetSpawnzonesInUseArray(gridPosition, false);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isBallActive) return;
        
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