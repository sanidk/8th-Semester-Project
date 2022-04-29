using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistTrapBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter() {
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().isKinematic = true;   
    } 
}
