using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class GameManagerLogic : MonoBehaviour
{
    public static GameObject roomServer;
    public static GameObject roomClient;
    public static GameObject roomActive;

    public GameLogic syncVariablesObject;

    public GameObject networkManager;
    static RealtimeAvatarManager manager;
    public Dictionary<int, RealtimeAvatar> avatars;
    public Dictionary<int, RealtimeAvatar> previousAvatars;
    public static bool isServer = false;
    public bool isThisClientActingServer;
    public static bool isPlayersReady;

    public GameObject roomPlayer1;
    public GameObject roomPlayer2;
    GridManager gridManagerPlayer1;
    GridManager gridManagerPlayer2;

    public bool isPlayerSpawnSet;
    public GameObject VRRig;
    public GameObject spawnPlayer1;
    public GameObject spawnPlayer2;

    public static GameObject representationCubeLaserReferencePlayer1;
    public static GameObject representationCubeLaserReferencePlayer2;

    public static GameObject representationCubeSpawnLocationPlayer1;
    public static GameObject representationCubeSpawnLocationPlayer2;
    


    // Start is called before the first frame update
    void Start()
    {
        gridManagerPlayer1 = roomPlayer1.GetComponentInChildren<GridManager>();
        gridManagerPlayer2 = roomPlayer2.GetComponentInChildren<GridManager>();

        representationCubeLaserReferencePlayer1 = GameObject.Find("RepresentationCubeLaserReferencePlayer1");
        representationCubeLaserReferencePlayer2 = GameObject.Find("RepresentationCubeLaserReferencePlayer2");
        representationCubeSpawnLocationPlayer1 = GameObject.Find("representationCubeSpawnLocationPlayer1");
        representationCubeSpawnLocationPlayer2 = GameObject.Find("representationCubeSpawnLocationPlayer2");

        syncVariablesObject = GetComponent<GameLogic>();


    }

    // Update is called once per frame
    void Update()
    {
        //maybe make delays in the loop so it doesnt check all the time
        isThisClientActingServer = isServer;
        isPlayersReady = syncVariablesObject._isPlayersReadyToStartGame;

        if (manager == null)
        {
            manager = networkManager.GetComponent<RealtimeAvatarManager>();


        }
        else
        {
            avatars = manager.avatars;

        }

        if (manager.avatars == null) {
            return;
        }


        if (CheckIfServerExist())
        {
            if (isServer)
            {
                if (VRRig.transform.position != spawnPlayer1.transform.position)
                {
                    VRRig.transform.position = spawnPlayer1.transform.position;
                    VRRig.transform.rotation = Quaternion.Euler(0, 90, 0);
                    roomActive = roomServer;
                }
                
            }
            else
            {
                if (VRRig.transform.position != spawnPlayer2.transform.position)
                {
                    VRRig.transform.position = spawnPlayer2.transform.position;
                    VRRig.transform.rotation = Quaternion.Euler(0, -90, 0);
                    roomActive = roomClient;
                }

            }
        } else
        {
            AssignServer();
        }

        CheckIfCorrectRoom();

        if (!isServer) return;
          
        if (!syncVariablesObject._isPlayersReadyToStartGame)
        {
            syncVariablesObject._isPlayersReadyToStartGame = CheckIfAllPlayersReady();
            //syncVariablesObject._isPlayersReadyToStartGame = isPlayersReady;
            
            //GameLogic._isPlayersReadyToStartGame = isPlayersReady;
        }

        if (syncVariablesObject._isPlayersReadyToStartGame)
        {

            gridManagerPlayer1.spawnBalls = true;
            gridManagerPlayer2.spawnBalls = true;

        }

    }

    void CheckIfCorrectRoom() 
    {
        if (isServer && roomActive != roomServer) {
            roomActive = roomServer;
            VRRig.transform.position = spawnPlayer1.transform.position;
            VRRig.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (!isServer && roomActive != roomClient)
        {
            roomActive = roomClient;
            VRRig.transform.position = spawnPlayer2.transform.position;
            VRRig.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }

    bool CheckIfAllPlayersReady()
    {
        if (avatars.Count < 2)
        {
            return false;
        }

        bool isTeamsReady = true;

        for (int i = 0; i < avatars.Count; i++)
        {
            RealtimeAvatar player = avatars[i];

            if (!player.gameObject.GetComponent<PlayerStat>()._isReady)
            {
                isTeamsReady = false;
            }

        }

        return isTeamsReady;


    }

    bool CheckIfServerExist()
    {
        bool isServerExist = true;

        for (int i = 0; i < avatars.Count; i++)
        {
            RealtimeAvatar player = avatars[i];

            if (!player.gameObject.GetComponent<PlayerStat>()._backupVariable1) //isServer
            {
                isServerExist = false;
            }

        }

        return isServerExist;
    }

    void AssignServer()
    {
        avatars[0].GetComponent<PlayerStat>()._backupVariable1 = true; //isServer
    }

}
