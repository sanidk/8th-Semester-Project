using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class BombTrigger : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (GetComponentInParent<RealtimeView>().isOwnedLocallySelf)
        {

        }

        if (GetComponentInParent<BombBehaviour>().explode)
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                other.gameObject.GetComponent<PlayerStat>()._lives--;
                GameObject audioObject = Realtime.Instantiate("explodeAudioPrefab", transform.position, transform.rotation, new Realtime.InstantiateOptions
                {
                    ownedByClient = true,
                    preventOwnershipTakeover = true,
                    destroyWhenOwnerLeaves = false,
                    destroyWhenLastClientLeaves = true
                });

                GetComponentInParent<BombBehaviour>().Despawn();
            }

            

        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
