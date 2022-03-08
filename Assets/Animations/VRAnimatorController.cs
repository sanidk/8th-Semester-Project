using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAnimatorController : MonoBehaviour
{
    private Animator animator;
    public Vector3 previousPos;

    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        velocity = ((transform.TransformPoint(Vector3.zero) - previousPos).magnitude) / Time.deltaTime;
        previousPos = transform.TransformPoint(Vector3.zero);

        animator.SetBool("isMoving", velocity > 0.3f);

        //Debug.Log("Velocity: " + velocity);
    }
}