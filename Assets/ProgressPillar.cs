using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ProgressPillar : MonoBehaviour
{
    public GameObject RedProgress;
    public GameObject YellowProgress;
    public GameObject GreenProgress;
    public GameObject BlueProgress;

    GameObject[] redProgressArray;
    GameObject[] yellowProgressArray;
    GameObject[] greenProgressArray;
    GameObject[] blueProgressArray;

    private int amountOfProgressCubes = 10;

    Color red = Color.red;
    Color yellow = Color.yellow;
    Color green = Color.green;
    Color blue = Color.blue;

    public GameObject player;
    public GameObject lightSaber;

    bool redArraySetToDefaultColor;
    bool yellowArraySetToDefaultColor;
    bool greenArraySetToDefaultColor;
    bool blueArraySetToDefaultColor;

    public bool redCompleted;
    public bool yellowCompleted;
    public bool greenCompleted;
    public bool blueCompleted;

    public int playerNumber;


    // Start is called before the first frame update
    void Start()
    {
        redProgressArray = new GameObject[amountOfProgressCubes];
        yellowProgressArray = new GameObject[amountOfProgressCubes];
        greenProgressArray = new GameObject[amountOfProgressCubes];
        blueProgressArray = new GameObject[amountOfProgressCubes];


        for (int i = 0; i < amountOfProgressCubes; i++)
        {
            redProgressArray[i] = RedProgress.transform.GetChild(i).gameObject;
            yellowProgressArray[i] = YellowProgress.transform.GetChild(i).gameObject;
            greenProgressArray[i] = GreenProgress.transform.GetChild(i).gameObject;
            blueProgressArray[i] = BlueProgress.transform.GetChild(i).gameObject;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null || lightSaber == null) { return; }
        if (!player.GetComponent<RealtimeTransform>().isOwnedLocallySelf) { return; }

        if (redCompleted && yellowCompleted && greenCompleted && blueCompleted)
        {
            player.GetComponent<PlayerStat>()._currentLevel++;

            redCompleted = false;
            yellowCompleted = false;
            greenCompleted = false;
            blueCompleted = false;

            for (int i = 0; i < amountOfProgressCubes; i++)
            {
                redProgressArray[i].GetComponent<ColorSync>().SetColor(Color.grey);
                yellowProgressArray[i].GetComponent<ColorSync>().SetColor(Color.grey);
                greenProgressArray[i].GetComponent<ColorSync>().SetColor(Color.grey);
                blueProgressArray[i].GetComponent<ColorSync>().SetColor(Color.grey);
            }

        }

        if (player.GetComponent<PlayerStat>()._backupVariable3 == 1f) // Red
        {
            for (int i = 0; i < amountOfProgressCubes; i++)
            {
                redProgressArray[i].GetComponent<ColorSync>().SetColor(Color.red);
            }
            redCompleted = true;
            player.GetComponent<PlayerStat>()._backupVariable3 = 0;
        }
        else
        {
            if (lightSaber.GetComponent<Lighsaber>().swordColour() == red)
            {
                for (int i = 0; i < player.GetComponent<PlayerStat>()._scoreStreak; i++)
                {
                    redProgressArray[i].GetComponent<ColorSync>().SetColor(Color.red);
                }
                redArraySetToDefaultColor = false;
            }
            else if (lightSaber.GetComponent<Lighsaber>().swordColour() != red && !redArraySetToDefaultColor && !redCompleted)
            {
                for (int i = 0; i < amountOfProgressCubes; i++)
                {
                    redProgressArray[i].GetComponent<ColorSync>().SetColor(Color.grey);
                }
                redArraySetToDefaultColor = true;
            }
        }


        if (player.GetComponent<PlayerStat>()._backupVariable4 == 1f) // Yellow
        {
            for (int i = 0; i < amountOfProgressCubes; i++)
            {
                yellowProgressArray[i].GetComponent<ColorSync>().SetColor(Color.yellow);
            }
            yellowCompleted = true;
            player.GetComponent<PlayerStat>()._backupVariable4 = 0;
        }
        else
        {
            if (lightSaber.GetComponent<Lighsaber>().swordColour() == yellow)
            {
                for (int i = 0; i < player.GetComponent<PlayerStat>()._scoreStreak; i++)
                {
                    yellowProgressArray[i].GetComponent<ColorSync>().SetColor(Color.yellow);
                }
                yellowArraySetToDefaultColor = false;
            }
            else if (lightSaber.GetComponent<Lighsaber>().swordColour() != yellow && !yellowArraySetToDefaultColor && !yellowCompleted)
            {
                for (int i = 0; i < amountOfProgressCubes; i++)
                {
                    yellowProgressArray[i].GetComponent<ColorSync>().SetColor(Color.grey);
                }
                yellowArraySetToDefaultColor = true;
            }
        }


        if (player.GetComponent<PlayerStat>()._backupVariable5 == 1f) // Green
        {
            for (int i = 0; i < amountOfProgressCubes; i++)
            {
                greenProgressArray[i].GetComponent<ColorSync>().SetColor(Color.green);
            }
            greenCompleted = true;
            player.GetComponent<PlayerStat>()._backupVariable5 = 0;
        }
        else
        {
            if (lightSaber.GetComponent<Lighsaber>().swordColour() == green)
            {
                for (int i = 0; i < player.GetComponent<PlayerStat>()._scoreStreak; i++)
                {
                    greenProgressArray[i].GetComponent<ColorSync>().SetColor(Color.green);
                }
                greenArraySetToDefaultColor = false;
            }
            else if (lightSaber.GetComponent<Lighsaber>().swordColour() != green && !greenArraySetToDefaultColor && !greenCompleted)
            {
                for (int i = 0; i < amountOfProgressCubes; i++)
                {
                    greenProgressArray[i].GetComponent<ColorSync>().SetColor(Color.grey);
                }
                greenArraySetToDefaultColor = true;
            }
        }


        if (player.GetComponent<PlayerStat>()._backupVariable6 == 1f) // Blue
        {
            for (int i = 0; i < amountOfProgressCubes; i++)
            {
                blueProgressArray[i].GetComponent<ColorSync>().SetColor(Color.blue);
            }
            blueCompleted = true;
            player.GetComponent<PlayerStat>()._backupVariable6 = 0;
        }
        else
        {
            if (lightSaber.GetComponent<Lighsaber>().swordColour() == blue)
            {
                for (int i = 0; i < player.GetComponent<PlayerStat>()._scoreStreak; i++)
                {
                    blueProgressArray[i].GetComponent<ColorSync>().SetColor(Color.blue);
                }
                blueArraySetToDefaultColor = false;
            }
            else if (lightSaber.GetComponent<Lighsaber>().swordColour() != blue && !blueArraySetToDefaultColor && !blueCompleted)
            {
                for (int i = 0; i < amountOfProgressCubes; i++)
                {
                    blueProgressArray[i].GetComponent<ColorSync>().SetColor(Color.grey);
                }
                blueArraySetToDefaultColor = true;
            }
        }
    }
}

