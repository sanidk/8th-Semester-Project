using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class CollisionDetection : MonoBehaviour
{
    PlayerStat playerStat;
    GameObject target;

    private IEnumerator resetCoroutine;
    private bool wasHit;   

    // Start is called before the first frame update
    void Start()
    {
        wasHit = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (GetComponent<RealtimeView>().isOwnedLocallySelf)
        {
            if (other.tag == "Trap" && !wasHit)
            {
                wasHit = true;
                playerStat = GetComponent<PlayerStat>();
                playerStat._lives--;
                StartCoroutine(resetCondition(3));
            }

            if (other.tag == "Laser" && !wasHit)
            {
                wasHit = true;
                playerStat = GetComponent<PlayerStat>();
                playerStat._lives--;
                StartCoroutine(resetCondition(3));
            }
        }

        
    }

    IEnumerator resetCondition(float godFrames) {
        yield return new WaitForSeconds(godFrames);
        wasHit = false;
        
    }
}

