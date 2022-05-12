using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    public static int level = 1;
    int previousLevel = 1;
    bool oldSendFeedback;

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        oldSendFeedback = GameManagerLogic.isSendFeedbackEnabled;
        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (level != previousLevel)
        {
            text.text = "Level "+level.ToString()+"!";
            StartCoroutine(RemoveText(3));
            
            previousLevel = level;

        }
        ModeChanged();



    }

    public void ModeChanged()
    {
        if (GameManagerLogic.isSendFeedbackEnabled != oldSendFeedback)
        {
            text.text = "isSendFeedbackEnabled: " + GameManagerLogic.isSendFeedbackEnabled.ToString();
            oldSendFeedback = GameManagerLogic.isSendFeedbackEnabled;
            RemoveText(5);
        }
        
    }

    IEnumerator RemoveText(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        text.text = "";

    }
}
