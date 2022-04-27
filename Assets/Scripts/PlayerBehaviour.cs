using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject networkManager;
    private int streakToSendTrap = 3;

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
        if (GameManagerLogic.isServer && playerStat._backupVariable1)
        {
            if (playerStat._scoreStreak >= streakToSendTrap)
            {
                int randomInt = Random.Range(0, 4);
                int randomTrap = Random.Range(0, 2);
                GameManagerLogic.roomClient.GetComponentInChildren<GridManager>().sendTrap(randomInt, randomTrap);
                spawnSendLaserCubeTrap(1);
                playerStat._scoreStreak = 0;
            }
        }
        else if (GameManagerLogic.isServer && !playerStat._backupVariable1)
        {
            if (playerStat._scoreStreak >= streakToSendTrap)
            {
                int randomInt = Random.Range(0, 4);
                int randomTrap = Random.Range(0, 2);
                GameManagerLogic.roomServer.GetComponentInChildren<GridManager>().sendTrap(randomInt, randomTrap);
                spawnSendLaserCubeTrap(2);
                playerStat._scoreStreak = 0;
            }
        }

        if (GameManagerLogic.isServer && GameManagerLogic.isPlayersReady && !lightSaberSpawned)
        {
            lightSaber = Realtime.Instantiate("Lighsaber_final_final", transform.position, transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = false,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            lightSaber.GetComponent<Lighsaber>().playerObject = gameObject;
            //lightSaber.transform.SetParent(transform);
            lightSaberSpawned = true;
        }

        if (!GetComponent<RealtimeTransform>().isOwnedLocallySelf) return;

        if (playerStat._backupVariable1)
        {
            GameManagerLogic.isServer = true;
        }
        else
        {
            GameManagerLogic.isServer = false;
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

    private void spawnSendLaserCubeTrap(int playerOwner) {


        Vector3 position;
        Quaternion rotation;

        GameObject room;
        
        if (playerOwner == 1)
        {
            room = GameManagerLogic.representationCubeSpawnLocationPlayer1;
            position = room.transform.position;
            rotation = room.transform.rotation;
        }
        else if (playerOwner == 2)
        {
            room = GameManagerLogic.representationCubeSpawnLocationPlayer2;
            position = room.transform.position;
            rotation = room.transform.rotation;
            playerOwner = 2;
        } else
        {
            return;
        }


        GameObject representationCube = Realtime.Instantiate("RepresentationCube", position, rotation, new Realtime.InstantiateOptions
        {
            ownedByClient = false,
            preventOwnershipTakeover = false,
            destroyWhenOwnerLeaves = false,
            destroyWhenLastClientLeaves = true
        });

        representationCube.GetComponent<RepresentationCube>().playerOwner = playerOwner;

    }

}
