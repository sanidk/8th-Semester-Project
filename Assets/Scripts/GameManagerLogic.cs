using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class GameManagerLogic : MonoBehaviour
{

    public GameObject networkManager;
    static RealtimeAvatarManager manager;
    public Dictionary<int, RealtimeAvatar> avatars;
    public Dictionary<int, RealtimeAvatar> previousAvatars;
    public bool isServer = false;
    bool isPlayersReady;

    public GameObject roomPlayer1;
    public GameObject roomPlayer2;
    GridManager gridManagerPlayer1;
    GridManager gridManagerPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        gridManagerPlayer1 = roomPlayer1.GetComponent<GridManager>();
        gridManagerPlayer2 = roomPlayer2.GetComponent<GridManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (manager == null)
        {
            manager = networkManager.GetComponent<RealtimeAvatarManager>();
        }
        else
        {
            avatars = manager.avatars;

        }



        if (avatars.Count == 1)
        {
            isServer = true;
            //avatars[0].GetComponent<PlayerStats>()._isServer = true;

        }

        if (!isServer)
        {
            //avatars[0].gameObject.SetActive(false);
            return;
        }

        if (!isPlayersReady)
        {
            isPlayersReady = CheckIfAllPlayersReady();
        }

        //start game
        if (isPlayersReady)
        {
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

            //ENABLE THIS CODE
            //if (!player.gameObject.GetComponent<GameNetworkStats>()._isReady)
            //{
            //    isTeamsReady = false;
            //}

        }

        return isTeamsReady;


    }
}
