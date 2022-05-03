using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistTrapBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "FloorPlayer1" || other.name == "FloorPlayer2") {
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().isKinematic = true;   
        }
    } 
}
