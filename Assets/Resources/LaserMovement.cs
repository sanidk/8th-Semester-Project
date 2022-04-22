using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class LaserMovement : MonoBehaviour
{
    float lifeSpan = 5;
    float startTime;
    float endTime;
    public Quaternion direction;
    float speed = 0.01f;
    public Vector3 roomRefPlayer2 = new Vector3(2, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        transform.position = roomRefPlayer2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManagerLogic.isServer) {
            return;
        }

        if (Time.time > startTime + lifeSpan) { 
        Realtime.Destroy(gameObject);
        }

        transform.position += direction.eulerAngles * Time.deltaTime * speed;
    }
}
