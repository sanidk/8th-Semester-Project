using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColouredObject : MonoBehaviour
{

    private Color colorOfObject;
    public Material materialOfObject;
    private int randomNumber;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<MeshRenderer>()) { return; }
        meshRenderer = GetComponent<MeshRenderer>();
        materialOfObject = new Material(materialOfObject);

        randomNumber = Random.Range(0, 3);
        if (randomNumber == 0) { materialOfObject.color = Color.green; }
        else if (randomNumber == 1) { materialOfObject.color = Color.blue; }
        else { materialOfObject.color = Color.red; }
        colorOfObject = materialOfObject.color;
        meshRenderer.material = materialOfObject;
    }

    public Color getColorOfObject()
    {
        return materialOfObject.color;
    }

    public Color ColorOfObject
    {
        get
        {
            return colorOfObject;
        }
        set
        {
            colorOfObject = value;
        }
    }

    
    void Update()
    {
        
    }
}
