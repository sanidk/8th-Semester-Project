using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject networkManager;
    public int streakToSendTrap = 10;

    PlayerStat playerStat;
    GameObject gameManager;
    RealtimeAvatarManager manager;
    public Dictionary<int, RealtimeAvatar> avatars;
    GameObject lightSaber;
    bool lightSaberSpawned;

    // Start is called before the first frame update
    void Start()
    {
        playerStat = GetComponent<PlayerStat>();
        playerStat._isReady = true;

        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<RealtimeTransform>().isOwnedLocallySelf) return;
        
        if (playerStat._backupVariable1)
        {
            GameManagerLogic.isServer = true;
        } else
        {
            GameManagerLogic.isServer = false;
        }

        if (GameManagerLogic.isServer)
        {
            if (playerStat._scoreStreak >= streakToSendTrap)
            {
                int randomInt = Random.Range(0, 4);
                int randomTrap = Random.Range(0, 2);
                gameManager.GetComponent<GameManagerLogic>().roomClient.GetComponentInChildren<GridManager>().sendTrap(randomInt, randomTrap);
                playerStat._scoreStreak = 0;
            }
        }
        else if (!GameManagerLogic.isServer)
        {
            if (playerStat._scoreStreak >= streakToSendTrap)
            {
                int randomInt = Random.Range(0, 4);
                int randomTrap = Random.Range(0, 2);
                gameManager.GetComponent<GameManagerLogic>().roomServer.GetComponentInChildren<GridManager>().sendTrap(randomInt, randomTrap);
                playerStat._scoreStreak = 0;
            }
        }

        if (GameManagerLogic.isPlayersReady && !lightSaberSpawned)
        {
            lightSaber = Realtime.Instantiate("Lighsaber_final_final", transform.position, transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = true,
                preventOwnershipTakeover = true,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            lightSaber.GetComponent<Lighsaber>().playerObject = gameObject;
            lightSaberSpawned = true;
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (!GetComponent<RealtimeTransform>().isOwnedLocallySelf) return;
        
        if (other.CompareTag("ReadyPlayer"))
        {
            playerStat._isReady = true;
        }


    }

}
