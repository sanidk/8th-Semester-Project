using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    public Vector3 heading;
    public Collider collider;
    public static float checkRadius = 10f;
    public static float speed = .1f;

    void Start()
    {
        collider = GetComponent<Collider>();
    }

    void Update()
    {
        transform.forward = CalculateMove(.1f, .1f, 1, 0.1f, 0.1f);
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    Vector3 CalculateMove(float alignmentWeight, float cohesionWeight, float avoidanceWeight, float radius, float avoidanceRadius)
    {
        Vector3 move = Vector3.zero;
        Vector3[] behaviours = new Vector3[3];
        float[] weights = new float[3];
        weights[0] = alignmentWeight;
        weights[1] = cohesionWeight;
        weights[2] = avoidanceWeight;

        for (int i = 0; i < behaviours.Length; i++)
        {
            Vector3 dir = behaviours[i];
            if (i == 0)
            {
                dir = Alignment(radius) * weights[i];
            } else if (i == 1)
            {
                dir = Cohesion(radius) * weights[i];
            } else if (i == 2)
            {
                dir = Avoidance(avoidanceRadius) * weights[i];
            }

            if (dir != Vector3.zero)
            {
                if (dir.sqrMagnitude > Mathf.Pow(weights[i], 2)) //weights[i] * weights[i])
                {
                    dir.Normalize();
                    dir *= weights[i];
                }

                move += dir;
            }
        }

        return move;
    }

    void Move(Vector3 heading)
    {
        if (heading != Vector3.zero)
        {
            transform.forward = heading;
        }

        transform.position += transform.forward * Time.deltaTime;
    }

    List<Transform> GetNearbyObjects(float radius)
    {
        List<Transform> nearbyObjects = new List<Transform>();

        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, radius); //Physics overlap sphere 3D
        

        foreach (Collider coll in nearbyColliders)
        {
            if (coll != collider)
            {
                nearbyObjects.Add(coll.transform);
            }
        }

        return nearbyObjects;
    }


    Vector3 Cohesion(float radius)
    {
        List<Transform> nearbyObjects = GetNearbyObjects(radius);
        Vector3 pos = Vector3.zero;
        Vector3 dir = transform.forward;

        if (nearbyObjects.Count > 0)
        {
            foreach (Transform obj in nearbyObjects)
            {
                pos += obj.position;
            
            }
            pos /= nearbyObjects.Count;
            dir = pos - transform.position;
            return dir.normalized;
        } else
        {
            return dir;
        }  

    }

    Vector3 Alignment(float radius)
    {
        List<Transform> nearbyObjects = GetNearbyObjects(radius);
        Vector3 heading = Vector3.zero;
        Vector3 dir = transform.forward;

        if (nearbyObjects.Count > 0)
        {
            foreach (Transform obj in nearbyObjects)
            {
                heading += obj.forward;

            }
            heading /= nearbyObjects.Count;
            
            
        }

        return heading;

    }

    Vector3 AvoidanceOld(float radius)
    {
        List<Transform> nearbyObjects = GetNearbyObjects(radius);
        Vector3 heading = Vector3.zero;
        Vector3 dir = transform.forward;

        if (nearbyObjects.Count > 0)
        {
            foreach (Transform obj in nearbyObjects)
            {
                heading += (transform.position - obj.position).normalized * -1;

            }
            heading /= nearbyObjects.Count;


        }

        return heading;
    }

    
    public Vector3 Avoidance(float radius)
    {
        List<Transform> nearbyObjects = GetNearbyObjects(radius);

        if (nearbyObjects.Count == 0)
        {
            return Vector3.zero;
        }

        Vector3 heading = Vector3.zero;
        int avoidAmount = 0;
        foreach (Transform obj in nearbyObjects)
        {
            if (Vector3.SqrMagnitude(obj.position - transform.position) < radius)
            {
                heading += (transform.position - obj.position);
                avoidAmount++;
            }
        }

        if (avoidAmount > 0)
        {
            heading /= avoidAmount;
        }

        return heading;

    }
    
}
