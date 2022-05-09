using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    bool isTargetPosReached;
    float spawnTime;
    Vector3 initialPosition;
    public Transform targetTransform;

    void Start()
    {
        spawnTime = Time.time;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //ifServercheck?
        if (!isTargetPosReached && targetTransform != null) // doesnt trigger because scoreStreak is reset before targetTransform can be set.
        {
            GetComponentInChildren<MeshRenderer>().material.color = Color.red; // just a test to see if this if statement triggers.
            float elapsedTime = Time.time - spawnTime;
            transform.position = Vector3.Lerp(initialPosition, targetTransform.position, elapsedTime / 2);
            if (elapsedTime > 3)
            {
                isTargetPosReached = true;
            }
            return;
        }
    }
}
