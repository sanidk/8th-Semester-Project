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
    int previousLevel;

    GameObject roomOwned;
    GameObject roomServer;
    GameObject roomClient;

    public bool miniPrefabOnLoc;
    int randomSqOnFloor;
    public bool spawnMiniPrefab;

    int test = 0;
    bool isTakenBombDamage;


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
        roomServer = GameObject.Find("RoomPlayer1");
        roomClient = GameObject.Find("RoomPlayer2");

        previousLevel = playerStat._currentLevel;
        


    }

    // Update is called once per frame
    void Update()
    {

        

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
            roomOwned = roomServer;
            gameObject.tag = "Player1";
            gameObject.transform.Find("Head").tag = "Player1";
            gameObject.transform.Find("Left Hand").tag = "Player1";
            gameObject.transform.Find("Right Hand").tag = "Player1";


        }
        else if (!playerStat._backupVariable1)
        {
            playerNumber = 2;
            roomOwned = roomClient;
            gameObject.tag = "Player2";
            gameObject.transform.Find("Head").tag = "Player2";
            gameObject.transform.Find("Left Hand").tag = "Player2";
            gameObject.transform.Find("Right Hand").tag = "Player2";
        }

        if (!GameManagerLogic.isDebuggingModeEnabled && Application.platform != RuntimePlatform.Android)
        {
            return;
        }

        roomOwned.GetComponentInChildren<GridManager>().playerReference = transform.gameObject;

        if (GetComponent<RealtimeView>().isOwnedLocallySelf && playerStat._backupVariable1)
        {
            //telemetry data wont work here because its not networked
            //TelemetryData.traps2++;
            if (playerStat._scoreStreak >= streakToSendTrap)
            {
                randomSqOnFloor = Random.Range(0, 4);
                if (playerStat._backupVariable3 == 1f)
                {
                    randomTrap = 0;
                    if (GameManagerLogic.isSendFeedbackEnabled)
                    {
                        if (lightSaber != null)
                        {
                            GameObject miniSpears = Realtime.Instantiate("SpearTrap_miniPrefab", lightSaber.GetComponent<Lighsaber>()._tip.transform.position, Quaternion.Euler(0, 0, 0), new Realtime.InstantiateOptions
                            {
                                ownedByClient = true,
                                preventOwnershipTakeover = false,
                                destroyWhenOwnerLeaves = false,
                                destroyWhenLastClientLeaves = true
                            });
                            miniSpears.GetComponent<miniPrefab>().targetTransform = GameManagerLogic.roomClient.GetComponentInChildren<GridManager>().trapCubeList[randomSqOnFloor].transform;
                            miniSpears.GetComponent<miniPrefab>().playerObj = gameObject;
                        }
                    }
                }
                else if (playerStat._backupVariable4 == 1f)
                {
                    randomTrap = 1;
                    if (GameManagerLogic.isSendFeedbackEnabled)
                    {
                        if (lightSaber != null)
                        {
                            GameObject miniMace = Realtime.Instantiate("MaceTrap_miniPrefab", lightSaber.GetComponent<Lighsaber>()._tip.transform.position, Quaternion.Euler(0, 0, 0), new Realtime.InstantiateOptions
                            {
                                ownedByClient = true,
                                preventOwnershipTakeover = false,
                                destroyWhenOwnerLeaves = false,
                                destroyWhenLastClientLeaves = true
                            });
                            miniMace.GetComponent<miniPrefab>().targetTransform = GameManagerLogic.roomClient.GetComponentInChildren<GridManager>().trapCubeList[randomSqOnFloor].transform;
                            miniMace.GetComponent<miniPrefab>().playerObj = gameObject;
                        }
                    }
                }
                else if (playerStat._backupVariable5 == 1f)
                {
                    randomTrap = 2;
                    if (GameManagerLogic.isSendFeedbackEnabled)
                    {
                        if (lightSaber != null)
                        {
                            GameObject miniFist = Realtime.Instantiate("FistTrap_miniPrefab", lightSaber.GetComponent<Lighsaber>()._tip.transform.position, Quaternion.Euler(0, 0, 0), new Realtime.InstantiateOptions
                            {
                                ownedByClient = true,
                                preventOwnershipTakeover = false,
                                destroyWhenOwnerLeaves = false,
                                destroyWhenLastClientLeaves = true
                            });
                            miniFist.GetComponent<miniPrefab>().targetTransform = GameManagerLogic.roomClient.GetComponentInChildren<GridManager>().trapCubeList[randomSqOnFloor].transform;
                            miniFist.GetComponent<miniPrefab>().playerObj = gameObject;
                        }
                    }
                }
                else if (playerStat._backupVariable6 == 1f)
                {
                    randomTrap = 3;
                    if (GameManagerLogic.isSendFeedbackEnabled)
                    {
                        if (lightSaber != null)
                        {
                            GameObject miniArrows = Realtime.Instantiate("BulletTrap_miniPrefab", lightSaber.GetComponent<Lighsaber>()._tip.transform.position, Quaternion.Euler(0, 0, 0), new Realtime.InstantiateOptions
                            {
                                ownedByClient = true,
                                preventOwnershipTakeover = false,
                                destroyWhenOwnerLeaves = false,
                                destroyWhenLastClientLeaves = true
                            });
                            miniArrows.GetComponent<miniPrefab>().targetTransform = GameManagerLogic.roomClient.GetComponentInChildren<GridManager>().trapCubeList[randomSqOnFloor].transform;
                            miniArrows.GetComponent<miniPrefab>().playerObj = gameObject;
                        }
                    }
                }
                //int randomInt = Random.Range(0, 4);
                //int randomTrap = Random.Range(0, 4);
                //GameManagerLogic.roomClient.GetComponentInChildren<GridManager>().sendTrap(randomInt, randomTrap);
                if (!GameManagerLogic.isSendFeedbackEnabled)
                {
                    GameManagerLogic.roomClient.GetComponentInChildren<GridManager>().sendTrap(randomSqOnFloor, randomTrap);
                }
                playerStat._scoreStreak = 0;
            }
            if (miniPrefabOnLoc && GameManagerLogic.isSendFeedbackEnabled)
            {
                GameManagerLogic.roomClient.GetComponentInChildren<GridManager>().sendTrap(randomSqOnFloor, randomTrap);
                miniPrefabOnLoc = false;
            }
            if (playerStat._currentLevel != previousLevel)
            {
                spawnSendLaserCubeTrap(2);
                previousLevel = playerStat._currentLevel;
            }
        }
        else if (GetComponent<RealtimeView>().isOwnedLocallySelf && !playerStat._backupVariable1)
        {
            if (playerStat._scoreStreak >= streakToSendTrap)
            {
                //TelemetryData.traps1++;
                randomSqOnFloor = Random.Range(0, 4);
                if (playerStat._backupVariable3 == 1f)
                {
                    randomTrap = 0;
                    if (GameManagerLogic.isSendFeedbackEnabled)
                    {
                        if (lightSaber != null)
                        {
                            GameObject miniSpears = Realtime.Instantiate("SpearTrap_miniPrefab", lightSaber.GetComponent<Lighsaber>()._tip.transform.position, Quaternion.Euler(0, 0, 0), new Realtime.InstantiateOptions
                            {
                                ownedByClient = true,
                                preventOwnershipTakeover = false,
                                destroyWhenOwnerLeaves = false,
                                destroyWhenLastClientLeaves = true
                            });
                            miniSpears.GetComponent<miniPrefab>().targetTransform = GameManagerLogic.roomServer.GetComponentInChildren<GridManager>().trapCubeList[randomSqOnFloor].transform;
                            miniSpears.GetComponent<miniPrefab>().playerObj = gameObject;
                        }
                    }
                }
                else if (playerStat._backupVariable4 == 1f)
                {
                    randomTrap = 1;
                    if (GameManagerLogic.isSendFeedbackEnabled)
                    {
                        if (lightSaber != null)
                        {
                            GameObject miniMace = Realtime.Instantiate("MaceTrap_miniPrefab", lightSaber.GetComponent<Lighsaber>()._tip.transform.position, Quaternion.Euler(0, 0, 0), new Realtime.InstantiateOptions
                            {
                                ownedByClient = true,
                                preventOwnershipTakeover = false,
                                destroyWhenOwnerLeaves = false,
                                destroyWhenLastClientLeaves = true
                            });
                            miniMace.GetComponent<miniPrefab>().targetTransform = GameManagerLogic.roomServer.GetComponentInChildren<GridManager>().trapCubeList[randomSqOnFloor].transform;
                            miniMace.GetComponent<miniPrefab>().playerObj = gameObject;
                        }
                    }
                }
                else if (playerStat._backupVariable5 == 1f)
                {
                    randomTrap = 2;
                    if (GameManagerLogic.isSendFeedbackEnabled)
                    {
                        if (lightSaber != null)
                        {
                            GameObject miniFist = Realtime.Instantiate("FistTrap_miniPrefab", lightSaber.GetComponent<Lighsaber>()._tip.transform.position, Quaternion.Euler(0, 0, 0), new Realtime.InstantiateOptions
                            {
                                ownedByClient = true,
                                preventOwnershipTakeover = false,
                                destroyWhenOwnerLeaves = false,
                                destroyWhenLastClientLeaves = true
                            });
                            miniFist.GetComponent<miniPrefab>().targetTransform = GameManagerLogic.roomServer.GetComponentInChildren<GridManager>().trapCubeList[randomSqOnFloor].transform;
                            miniFist.GetComponent<miniPrefab>().playerObj = gameObject;
                        }
                    }
                }
                else if (playerStat._backupVariable6 == 1f)
                {
                    randomTrap = 3;
                    if (GameManagerLogic.isSendFeedbackEnabled)
                    {
                        if (lightSaber != null)
                        {
                            GameObject miniArrows = Realtime.Instantiate("BulletTrap_miniPrefab", lightSaber.GetComponent<Lighsaber>()._tip.transform.position, Quaternion.Euler(0, 0, 0), new Realtime.InstantiateOptions
                            {
                                ownedByClient = true,
                                preventOwnershipTakeover = false,
                                destroyWhenOwnerLeaves = false,
                                destroyWhenLastClientLeaves = true
                            });
                            miniArrows.GetComponent<miniPrefab>().targetTransform = GameManagerLogic.roomServer.GetComponentInChildren<GridManager>().trapCubeList[randomSqOnFloor].transform;
                            miniArrows.GetComponent<miniPrefab>().playerObj = gameObject;
                        }
                    }
                }
                //int randomInt = Random.Range(0, 4);
                //int randomTrap = Random.Range(0, 4);
                //GameManagerLogic.roomServer.GetComponentInChildren<GridManager>().sendTrap(randomInt, randomTrap);
                if (!GameManagerLogic.isSendFeedbackEnabled)
                {
                    GameManagerLogic.roomServer.GetComponentInChildren<GridManager>().sendTrap(randomSqOnFloor, randomTrap);
                }
                playerStat._scoreStreak = 0;
            }
            if (miniPrefabOnLoc && GameManagerLogic.isSendFeedbackEnabled)
            {
                GameManagerLogic.roomServer.GetComponentInChildren<GridManager>().sendTrap(randomSqOnFloor, randomTrap);
                miniPrefabOnLoc = false;
            }
            if (previousLevel != playerStat._currentLevel)
            {
                spawnSendLaserCubeTrap(1);
                previousLevel = playerStat._currentLevel;
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
            if (playerStat._backupVariable1)
            {
                ProgressPillar = Realtime.Instantiate("ProgressPillar", transform.position + new Vector3(15f, 2.1f, 2.75f), Quaternion.Euler(0, -90, 0), new Realtime.InstantiateOptions
                {

                    ownedByClient = true,
                    preventOwnershipTakeover = false,
                    destroyWhenOwnerLeaves = false,
                    destroyWhenLastClientLeaves = true
                });
                ProgressPillar.GetComponent<ProgressPillar>().playerNumber = 1;
            }
            else
            {
                ProgressPillar = Realtime.Instantiate("ProgressPillar", transform.position + new Vector3(-15f, 2.1f, 2.75f), Quaternion.Euler(0, 90, 0), new Realtime.InstantiateOptions
                {

                    ownedByClient = true,
                    preventOwnershipTakeover = false,
                    destroyWhenOwnerLeaves = false,
                    destroyWhenLastClientLeaves = true
                });
                ProgressPillar.GetComponent<ProgressPillar>().playerNumber = 2;
            }
            ProgressPillar.GetComponent<ProgressPillar>().player = gameObject;
            ProgressPillar.GetComponent<ProgressPillar>().lightSaber = lightSaber;
            lightSaber.GetComponent<Lighsaber>().progressPillar = ProgressPillar;
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



    IEnumerator ImmuneXSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        isTakenBombDamage = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        


        if (!GetComponent<RealtimeTransform>().isOwnedLocallySelf) return;

        if (other.CompareTag("BombCollider"))
        {
            if (!isTakenBombDamage)
            {
                playerStat._lives--;
                isTakenBombDamage = true;
                StartCoroutine(ImmuneXSeconds(1));
            }
            
            
            //GameObject audioObject = Realtime.Instantiate("explodeAudioPrefab", other.gameObject.transform.position, other.gameObject.transform.rotation, new Realtime.InstantiateOptions
            //{
            //    ownedByClient = false,
            //    preventOwnershipTakeover = false,
            //    destroyWhenOwnerLeaves = false,
            //    destroyWhenLastClientLeaves = true
            //});
            other.GetComponentInParent<RealtimeTransform>().RequestOwnership();

            other.GetComponentInParent<BombBehaviour>().Explode();
        }

        if (other.CompareTag("ReadyPlayer"))
        {
            playerStat._isReady = true;
        }

        

        if (other.CompareTag("Mine"))
        {
            playerStat._lives--;

            //GameObject audioObject = Realtime.Instantiate("explodeAudioPrefab", other.gameObject.transform.position, other.gameObject.transform.rotation, new Realtime.InstantiateOptions
            //{
            //    ownedByClient = false,
            //    preventOwnershipTakeover = false,
            //    destroyWhenOwnerLeaves = false,
            //    destroyWhenLastClientLeaves = true
            //});
            other.GetComponent<RealtimeTransform>().RequestOwnership();

            other.GetComponent<BombBehaviour>().Explode();
        }


    }

    private void spawnSendLaserCubeTrap(int playerOwner) {

        Vector3 position;
        Quaternion rotation;

        GameObject room;
        
        if (playerOwner == 1)
        {
            room = GameManagerLogic.representationCubeSpawnLocationPlayer2;
            position = room.transform.position;
            rotation = room.transform.rotation;
        }
        else if (playerOwner == 2)
        {
            room = GameManagerLogic.representationCubeSpawnLocationPlayer1;
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
