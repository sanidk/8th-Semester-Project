using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    public static int level = 1;
    int previousLevel = 1;

    Text text;
    // Start is called before the first frame update
    void Start()
    {

        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (level != previousLevel)
        {
            text.text = "Level "+level.ToString();
            RemoveText(3);
            
            previousLevel = level;

        }
        
    }

    IEnumerator RemoveText(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        text.text = "";

    }
}
