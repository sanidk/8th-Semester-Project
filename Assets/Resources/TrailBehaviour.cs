using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField]
    public float thrust = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        rb.AddForce(transform.up * thrust);
    }
}
