using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullCubePieces : MonoBehaviour
{
    private float timeBeforeGettingDrawn = 1f;
    private float timeBeforeStopping = 0.75f;
    private float force = 250f;
    public Color colorOfSlicedCube;
    public GameObject progressPillar;
    GameObject progressPillarColorStack;
    Rigidbody rb;
    Collider coll;
    bool callOnce; // delete after testing:

    void Start()
    {
        colorOfSlicedCube = GetComponent<MeshRenderer>().material.color;
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        //if (progressPillar == null) { throw new MissingReferenceException("No progressPillar_Reference on PullCubePieces script"); }
        if (progressPillar == null) { return; }
        if (progressPillar.GetComponent<ProgressPillar>().playerNumber == 0) { return; }

        if(progressPillar.GetComponent<ProgressPillar>().playerNumber == 1)
        {
            //StartCoroutine(StopCubesMomentum(timeBeforeStopping));
            StartCoroutine(drawCubesToward(returnPillarColor(progressPillar), timeBeforeGettingDrawn));
        }
        else
        {
            //StartCoroutine(StopCubesMomentum(timeBeforeStopping));
            StartCoroutine(drawCubesToward(returnPillarColor(progressPillar), timeBeforeGettingDrawn));
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StopCubesMomentum(float time)
    {
        yield return new WaitForSeconds(time);
        //rb.velocity = Vector3.zero;
        //rb.angularVelocity = Vector3.zero;
        Vector3 velocity = rb.velocity;
        rb.velocity -= velocity;
    }

    IEnumerator drawCubesToward(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        Vector3 direction = obj.transform.position - transform.position; // Direction to ProgressPillar
        if(progressPillar.GetComponent<ProgressPillar>().playerNumber == 1)// temporary solution LOL
        {
            direction += new Vector3(0, 0, -7.5f); // temporary solution LOL
        }
        else
        {
            direction += new Vector3(0, 0, 7.5f);// temporary solution LOL
        }
        direction = direction.normalized;
        coll.enabled = false;
        rb.AddForce(direction * force);
        //rb.velocity = Vector3.zero;
        //rb.angularVelocity = Vector3.zero;

        //rb.AddForce(direction * force, ForceMode.Acceleration);
        //gameObject.GetComponent<Rigidbody>().AddForce(direction * force);
    }

    public GameObject returnPillarColor(GameObject pillar)
    {
        /*
        if (colorOfSlicedCube == pillar.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material.color)
        {
            progressPillarColorStack = pillar.transform.GetChild(0).gameObject;
            return progressPillarColorStack;
        }
        else if (colorOfSlicedCube == pillar.transform.GetChild(1).GetChild(0).GetComponent<MeshRenderer>().material.color)
        {
            progressPillarColorStack = pillar.transform.GetChild(1).gameObject;
            return progressPillarColorStack;
        }
        else if (colorOfSlicedCube == pillar.transform.GetChild(2).GetChild(0).GetComponent<MeshRenderer>().material.color)
        {
            progressPillarColorStack = pillar.transform.GetChild(2).gameObject;
            return progressPillarColorStack;
        }
        else if (colorOfSlicedCube == pillar.transform.GetChild(3).GetChild(0).GetComponent<MeshRenderer>().material.color)
        {
            progressPillarColorStack = pillar.transform.GetChild(3).gameObject;
            return progressPillarColorStack;
        }
        else
        {
            throw new MissingReferenceException("returnPillarColor method returns null");
            return null;
        }*/
        
        if (colorOfSlicedCube == Color.red) //
        {
            //progressPillarColorStack = pillar.transform.GetChild(0).gameObject;
            progressPillarColorStack = pillar.transform.Find("RedProgress").gameObject;
            return progressPillarColorStack;
        }
        else if (colorOfSlicedCube == Color.yellow)
        {
            //progressPillarColorStack = pillar.transform.GetChild(1).gameObject;
            progressPillarColorStack = pillar.transform.Find("YellowProgress").gameObject;
            return progressPillarColorStack;
        }
        else if (colorOfSlicedCube == Color.green)
        {
            //progressPillarColorStack = pillar.transform.GetChild(2).gameObject;
            progressPillarColorStack = pillar.transform.Find("GreenProgress").gameObject;
            return progressPillarColorStack;
        }
        else if (colorOfSlicedCube == Color.blue)
        {
            //progressPillarColorStack = pillar.transform.GetChild(3).gameObject;
            progressPillarColorStack = pillar.transform.Find("BlueProgress").gameObject;
            return progressPillarColorStack;
        }
        else
        {
            throw new MissingReferenceException("returnPillarColor method returns null");
            return null;
        }
    }
}
