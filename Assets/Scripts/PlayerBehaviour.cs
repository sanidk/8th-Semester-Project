using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerBehaviour : MonoBehaviour
{
    public int playerNumber;
    public GameObject networkManager;
    private int streakToSendTrap = 10;

    PlayerStat playerStat;
    GameObject gameManager;
    RealtimeAvatarManager manager;
    public Dictionary<int, RealtimeAvatar> avatars;
    GameObject lightSaber;
    GameObject ProgressPillar;
    bool lightSaberSpawned;
    int randomTrap;


    // Start is called before the first frame update
    void Start()
    {
        //if (Application.platform != RuntimePlatform.Android)
        //{
        //    return;
        //}
        playerStat = GetComponent<PlayerStat>();
        playerStat._isReady = true;

        gameManager = GameObject.Find("GameManager");

        GameManagerLogic.PlayerObject = transform.gameObject;



    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerLogic.isDebuggingModeEnabled && Application.platform != RuntimePlatform.Android)
        {
            return;
        }
        //if (Application.platform != RuntimePlatform.Android)
        //{
        //    playerNumber = 0;

        //} else if (playerStat._backupVariable1)
        //{
        //    playerNumber = 1;

        //} else if (!playerStat._backupVariable1)
        //{
        //    playerNumber = 2;
        //}

        if (playerStat._backupVariable1)
        {
            playerNumber = 1;

        }
        else if (!playerStat._backupVariable1)
        {
            playerNumber = 2;
        }

        if (GetComponent<RealtimeView>().isOwnedLocallySelf && playerStat._backupVariable1)
        {
            if (playerStat._scoreStreak >= streakToSendTrap)
            {
                if (playerStat._backupVariable3 == 1f)
                {
                    randomTrap = 0;
                    playerStat._backupVariable3 = 0;
                }
                else if (playerStat._backupVariable4 == 1f)
                {
                    randomTrap = 1;
                    playerStat._backupVariable4 = 0;
                }
                else if (playerStat._backupVariable5 == 1f)
                {
                    randomTrap = 2;
                    playerStat._backupVariable5 = 0;
                }
                else if (playerStat._backupVariable6 == 1f)
                {
                    randomTrap = 3;
                    playerStat._backupVariable6 = 0;
                }
                int randomInt = Random.Range(0, 4);
                //int randomTrap = Random.Range(0, 4);
                GameManagerLogic.roomClient.GetComponentInChildren<GridManager>().sendTrap(randomInt, randomTrap);
                spawnSendLaserCubeTrap(1);
                playerStat._scoreStreak = 0;
            }
        }
        else if (GetComponent<RealtimeView>().isOwnedLocallySelf && !playerStat._backupVariable1)
        {
            if (playerStat._scoreStreak >= streakToSendTrap)
            {
                if (playerStat._backupVariable3 == 1f)
                {
                    randomTrap = 0;
                    playerStat._backupVariable3 = 0;
                }
                else if (playerStat._backupVariable4 == 1f)
                {
                    randomTrap = 1;
                    playerStat._backupVariable4 = 0;
                }
                else if (playerStat._backupVariable5 == 1f)
                {
                    randomTrap = 2;
                    playerStat._backupVariable5 = 0;
                }
                else if (playerStat._backupVariable6 == 1f)
                {
                    randomTrap = 3;
                    playerStat._backupVariable6 = 0;
                }
                int randomInt = Random.Range(0, 4);
                //int randomTrap = Random.Range(0, 4);
                GameManagerLogic.roomClient.GetComponentInChildren<GridManager>().sendTrap(randomInt, randomTrap);
                spawnSendLaserCubeTrap(2);
                playerStat._scoreStreak = 0;
            }
        }

        if (GetComponent<RealtimeView>().isOwnedLocallySelf && GameManagerLogic.isPlayersReady && !lightSaberSpawned)
        {
            lightSaber = Realtime.Instantiate("Lighsaber_final_final", transform.position + new Vector3(0, 1f, 0), transform.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = true,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            lightSaber.GetComponent<Lighsaber>().playerObject = gameObject;
            //lightSaber.transform.SetParent(transform);
            ProgressPillar = Realtime.Instantiate("ProgressPillar", transform.position + new Vector3(0, 0, 2.5f), Quaternion.Euler(0, 0, 0), new Realtime.InstantiateOptions
            {

                ownedByClient = true,
                preventOwnershipTakeover = false,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true
            });
            ProgressPillar.GetComponent<ProgressPillar>().player = gameObject;
            ProgressPillar.GetComponent<ProgressPillar>().lightSaber = lightSaber;
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
