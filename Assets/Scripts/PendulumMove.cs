using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMovement : MonoBehaviour
{

    float MaxAngleDeflection = 90.0f;
    float SpeedOfPendulum = 2.0f; 
    float time = 90;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float angle = MaxAngleDeflection * Mathf.Sin(time += Time.deltaTime * SpeedOfPendulum);
        transform.parent.rotation = Quaternion.Euler(0, 0, angle);
    }
}

