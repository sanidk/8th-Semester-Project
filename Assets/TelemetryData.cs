using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Normal.Realtime;

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


    string headPosPath1 = @"C:\TelemetryData\headPosPath1.txt";
    string leftHandPosPath1 = @"C:\TelemetryData\leftHandPosPath1.txt";
    string rightHandPosPath1 = @"C:\TelemetryData\rightHandPosPath1.txt";
    string trapsSentPath1 = @"C:\TelemetryData\trapsSentPath1.txt";
    string cubesPath1 = @"C:\TelemetryData\cubesPath1.txt";
    string livesPath1 = @"C:\TelemetryData\livesPath1.txt";

    string headPosPath2 = @"C:\TelemetryData\headPosPath2.txt";
    string leftHandPosPath2 = @"C:\TelemetryData\leftHandPosPath2.txt";
    string rightHandPosPath2 = @"C:\TelemetryData\rightHandPosPath2.txt";
    string trapsSentPath2= @"C:\TelemetryData\trapsSentPath2.txt";
    string cubesPath2 = @"C:\TelemetryData\cubesPath2.txt";
    string livesPath2 = @"C:\TelemetryData\livesPath2.txt";


    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            return;
        }


        File.WriteAllText(headPosPath1, "");
        File.WriteAllText(leftHandPosPath1, "");
        File.WriteAllText(rightHandPosPath1, "");
        File.WriteAllText(trapsSentPath1, "");
        File.WriteAllText(cubesPath1, "");
        File.WriteAllText(livesPath1, "");

        File.WriteAllText(headPosPath2, "");
        File.WriteAllText(leftHandPosPath2, "");
        File.WriteAllText(rightHandPosPath2, "");
        File.WriteAllText(trapsSentPath2, "");
        File.WriteAllText(cubesPath2, "");
        File.WriteAllText(livesPath2, "");


    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Application.platform == RuntimePlatform.Android)
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

            if (playerNumber == 1)
            {
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

