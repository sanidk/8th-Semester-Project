using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class GameManagerLogic : MonoBehaviour
{
    public GameObject roomServer;
    public GameObject roomClient;
    public GameObject roomActive;

    public GameObject networkManager;
    static RealtimeAvatarManager manager;
    public Dictionary<int, RealtimeAvatar> avatars;
    public Dictionary<int, RealtimeAvatar> previousAvatars;
    public static bool isServer = false;
    public bool isThisClientActingServer;
    bool isPlayersReady;

    public GameObject roomPlayer1;
    public GameObject roomPlayer2;
    GridManager gridManagerPlayer1;
    GridManager gridManagerPlayer2;

    public bool isPlayerSpawnSet;
    public GameObject VRRig;
    public GameObject spawnPlayer1;
    public GameObject spawnPlayer2;


    // Start is called before the first frame update
    void Start()
    {
        gridManagerPlayer1 = roomPlayer1.GetComponentInChildren<GridManager>();
        gridManagerPlayer2 = roomPlayer2.GetComponentInChildren<GridManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        isThisClientActingServer = isServer;

        if (manager == null)
        {
            manager = networkManager.GetComponent<RealtimeAvatarManager>();
            
        }
        else
        {
            avatars = manager.avatars;

        }

        if (!CheckIfServerExist())
        {
            AssignServer();
        }


        if (CheckIfServerExist())
        {
            if (isServer)
            {
                if (VRRig.transform.position != spawnPlayer1.transform.position)
                {
                    VRRig.transform.position = spawnPlayer1.transform.position;
                    roomActive = roomServer;
                }
                
            }
            else
            {
                if (VRRig.transform.position != spawnPlayer2.transform.position)
                {
                    VRRig.transform.position = spawnPlayer2.transform.position;
                    roomActive = roomClient;
                }

            }
        }

        if (!isServer) return;
          
        if (!isPlayersReady)
        {
            isPlayersReady = CheckIfAllPlayersReady();
            
        }
        print("isPlayersReady" + isPlayersReady);
        if (isPlayersReady)
        {
            print("calling spawn methods");
            gridManagerPlayer1.spawnBalls = true;
            gridManagerPlayer2.spawnBalls = true;

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
