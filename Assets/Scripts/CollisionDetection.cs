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

    public AudioSource audioSource;
    public AudioClip oof;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        oof = Resources.Load("oofLol") as AudioClip;
        wasHit = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (GetComponent<RealtimeView>().isOwnedLocallySelf)
        {
            if (other.tag == "Trap" && !wasHit)
            {
                audioSource.PlayOneShot(oof, 0.5f);
                wasHit = true;
                playerStat = GetComponent<PlayerStat>();
                playerStat._lives--;
                StartCoroutine(resetCondition(3));
            }

            if (other.tag == "Laser" && !wasHit)
            {
                audioSource.PlayOneShot(oof, 0.5f);
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

