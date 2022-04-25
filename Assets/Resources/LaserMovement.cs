using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class LaserMovement : MonoBehaviour
{
    float lifeSpan = 10;
    float startTime;
    float endTime;
    public Quaternion direction;
    public Vector3 startPosition;
    float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        startPosition = transform.position;
        transform.position = startPosition-transform.forward;
        //transform.position-= transform.forward;

        //transform.rotation = direction;
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

        


        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
