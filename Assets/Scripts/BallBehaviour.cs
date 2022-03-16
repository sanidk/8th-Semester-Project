using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    GameObject gridManager;

    Vector3 startPos;
    Vector3 minPos;
    Vector3 maxPos;
    Vector3 currentPos;

    Vector3 dir;
    float randomDirectionAmount = 0.5f;

    float speed = .05f;
    public int gridPosition;

    public bool isBallActive = false;
    public bool isBallMoving = false;
    
    public static float cooldown = 3;


    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position;
        float spacing = GridManager.gridSpacing / 2;
        minPos = new Vector3(startPos.x + spacing, startPos.y + spacing, startPos.z + spacing);
        maxPos = new Vector3(startPos.x - spacing, startPos.y - spacing, startPos.z - spacing);

        Vector3 rotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        transform.rotation = Quaternion.Euler(rotation);

        dir = transform.forward;

    }

    public IEnumerator SpawnBall(int gridNumber, Vector3 pos)
    {
        gridPosition = gridNumber;
        isBallActive = true;
        
        yield return new WaitForSeconds(cooldown);
        transform.position = pos;


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

        if (currentPos.x > maxPos.x)
        {
            dir.x *= -1;
        }

        if (currentPos.x < minPos.x)
        {
            dir.x *= -1;
        }


        if (currentPos.y > maxPos.y)
        {
            dir.y *= -1;
        }

        if (currentPos.y < minPos.y)
        {
            dir.y *= -1;
        }


        if (currentPos.z > maxPos.z)
        {
            dir.z *= -1;
        }

        if (currentPos.z < minPos.z)
        {
            dir.z *= -1;
        }

        dir += new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)) * randomDirectionAmount;

        transform.position += dir.normalized * Time.deltaTime * speed;

    }
}
