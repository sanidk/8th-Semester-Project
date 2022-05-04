using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livesUIManager : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;

    GameObject[] hearts = new GameObject[5];

    public int lives;
    public int livesOld;


    // Start is called before the first frame update
    void Start()
    {
        hearts[0] = heart1;
        hearts[1] = heart2;
        hearts[2] = heart3;
        hearts[3] = heart4;
        hearts[4] = heart5;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives != livesOld)
        {
            StartCoroutine(looseLife(.5f, lives));
                

            livesOld = lives;

        }
    }

    IEnumerator looseLife(float time, int life)
    {
        for (int i = 0; i < lives+1; i++)
        { 
            hearts[i].SetActive(true);
        }

        for (int i = 0; i < 5; i++)
        {
            hearts[life].SetActive(!heart5.activeSelf);
            yield return new WaitForSeconds(time);
        }

        yield return new WaitForSeconds(time * 4);
        
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(false);
        }
          
    }
}
