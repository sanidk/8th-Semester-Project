using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerVR : MonoBehaviour
{

    TextMesh textMesh;
    public static string debuggingString;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = debuggingString;
    }
}
