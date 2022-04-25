using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColouredObject : MonoBehaviour
{
    public Material redMaterial;
    public Material greenMaterial;
    public Material blueMaterial;


    private Color colorOfObject;
    Color green = new Color(126, 196, 145, 1);
    Color blue = new Color(72, 79, 217, 1);
    Color red = new Color(214, 84, 97, 1);
    //add yellow custom color
    

    public Material materialOfObject;
    private int randomNumber;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<MeshRenderer>()) { return; }
        meshRenderer = GetComponent<MeshRenderer>();
        materialOfObject = new Material(materialOfObject);

        //randomNumber = Random.Range(0, 3);
        //if (randomNumber == 0) { materialOfObject.color = green; }
        //else if (randomNumber == 1) { materialOfObject.color = blue; }
        //else { materialOfObject.color = red; }
        /*if (randomNumber == 0) { materialOfObject = greenMaterial; }
        else if (randomNumber == 1) { materialOfObject = blueMaterial; }
        else { materialOfObject = redMaterial; }
        //colorOfObject = materialOfObject.color;
        meshRenderer.material = materialOfObject;*/

        //Use custom colors:
        randomNumber = Random.Range(0, 4);
        if (randomNumber == 0) { materialOfObject.color = Color.green; }
        else if (randomNumber == 1) { materialOfObject.color = Color.blue; }
        else if (randomNumber == 2) { materialOfObject.color = Color.red; }
        else { materialOfObject.color = Color.yellow; }
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
