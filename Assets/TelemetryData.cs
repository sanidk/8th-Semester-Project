using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Normal.Realtime;
using System;

public class TelemetryData : MonoBehaviour
{
    public Dictionary<int, RealtimeAvatar> avatars;

    public static int cubes1;
    public static int cubes2;
    public static int lives1;
    public static int lives2;
    public static int traps1;
    public static int traps2;

    public static int cubes1old;
    public static int cubes2old;
    public static int lives1old;
    public static int lives2old;
    public static int traps1old;
    public static int traps2old;

    //static string datetimeRaw = DateTime.Now.ToString();
    static string format = "Mddyyyyhhmmsstt";
    static string datetime = DateTime.Now.ToString(format);

    string headPosPath1 = @"C:\TelemetryData\headPosPath1"+datetime+".txt";
    string leftHandPosPath1 = @"C:\TelemetryData\leftHandPosPath1" + datetime + ".txt";
    string rightHandPosPath1 = @"C:\TelemetryData\rightHandPosPath1" + datetime + ".txt";
    string trapsSentPath1 = @"C:\TelemetryData\trapsSentPath1" + datetime + ".txt";
    string cubesPath1 = @"C:\TelemetryData\cubesPath1" + datetime + ".txt";
    string livesPath1 = @"C:\TelemetryData\livesPath1" + datetime + ".txt";

    string headPosPath2 = @"C:\TelemetryData\headPosPath2" + datetime + ".txt";
    string leftHandPosPath2 = @"C:\TelemetryData\leftHandPosPath2" + datetime + ".txt";
    string rightHandPosPath2 = @"C:\TelemetryData\rightHandPosPath2" + datetime + ".txt";
    string trapsSentPath2= @"C:\TelemetryData\trapsSentPath2" + datetime + ".txt";
    string cubesPath2 = @"C:\TelemetryData\cubesPath2" + datetime + ".txt";
    string livesPath2 = @"C:\TelemetryData\livesPath2" + datetime + ".txt";


    void Start()
    {
        print(headPosPath1);



        if (Application.platform == RuntimePlatform.Android)
        {
            return;
        }


        //File.WriteAllText(headPosPath1, "");
        //File.WriteAllText(leftHandPosPath1, "");
        //File.WriteAllText(rightHandPosPath1, "");
        //File.WriteAllText(trapsSentPath1, "");
        //File.WriteAllText(cubesPath1, "");
        //File.WriteAllText(livesPath1, "");

        //File.WriteAllText(headPosPath2, "");
        //File.WriteAllText(leftHandPosPath2, "");
        //File.WriteAllText(rightHandPosPath2, "");
        //File.WriteAllText(trapsSentPath2, "");
        //File.WriteAllText(cubesPath2, "");
        //File.WriteAllText(livesPath2, "");


    }

    // Update is called once per frame
    void Update()
    {
        //print(Application.platform);
        //if (Application.platform != RuntimePlatform.WindowsPlayer)
        //{
        //    return;
        //}

        if (!GetComponent<GameLogic>()._isPlayersReadyToStartGame)
        {
            return;
        }
        avatars = GetComponent<GameManagerLogic>().avatars;
        

        for (int i = 0; i < avatars.Count; i++) // maybe for each loop instead
        {
            RealtimeAvatar player = avatars[i];
            if (player.isOwnedLocallySelf)
            {
                return;
            }
            int playerNumber = player.gameObject.GetComponent<PlayerBehaviour>().playerNumber;

            Vector3 headPos = player.gameObject.transform.Find("Head").transform.position;
            Vector3 leftHand = player.gameObject.transform.Find("Left Hand").transform.position;
            Vector3 rightHand = player.gameObject.transform.Find("Right Hand").transform.position;


            PlayerStat playerStat = player.gameObject.GetComponent<PlayerStat>();


            if (playerNumber == 1)
            {
                
                lives1 = playerStat._lives;

                File.AppendAllText(headPosPath1, Time.time.ToString() + " : " + headPos.x + " : " + headPos.y +" : " + headPos.z + "\n");
                File.AppendAllText(leftHandPosPath1, Time.time.ToString() + " : " + leftHand.x + " : " + leftHand.y + " : " + leftHand.z + "\n");
                File.AppendAllText(rightHandPosPath1, Time.time.ToString() + " : " + rightHand.x + " : " + rightHand.y + " : " + rightHand.z + "\n");
                
                if(cubes1 != cubes1old)
                {
                    File.AppendAllText(cubesPath1, Time.time.ToString() +" : " + cubes1 + "\n");
                    cubes1old = cubes1;
                }

                if (lives1 != lives1old)
                {
                    File.AppendAllText(livesPath1, Time.time.ToString() + " : " + lives1 + "\n");
                    lives1old = lives1;
                }

                if (traps1 != traps1old)
                {
                    File.AppendAllText(trapsSentPath1, Time.time.ToString() + " : " + traps1 + "\n");
                    traps1old = traps1;
                }

            }
            if (playerNumber == 2)
            {
                lives2 = playerStat._lives;

                File.AppendAllText(headPosPath2, Time.time.ToString() + " : " + headPos.x + " : " + headPos.y + " : " + headPos.z + "\n");
                File.AppendAllText(leftHandPosPath2, Time.time.ToString() + " : " + leftHand.x + " : " + leftHand.y + " : " + leftHand.z + "\n");
                File.AppendAllText(rightHandPosPath2, Time.time.ToString() + " : " + rightHand.x + " : " + rightHand.y + " : " + rightHand.z + "\n");

                if (cubes2 != cubes2old)
                {
                    File.AppendAllText(cubesPath2, Time.time.ToString() + " : " + cubes2 + "\n");
                    cubes2old = cubes2;
                }

                if (lives2 != lives2old)
                {
                    File.AppendAllText(livesPath2, Time.time.ToString() + " : " + lives2 + "\n");
                    lives2old = lives2;
                }

                if (traps2 != traps2old)
                {
                    File.AppendAllText(trapsSentPath2, Time.time.ToString() + " : " + traps2 + "\n");
                    traps2old = traps2;
                }
            }

        }
    }
}

