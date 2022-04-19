using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateScopeRenderTexture : MonoBehaviour
{
    public RenderTexture renderTextureToCopyFrom;
    RenderTexture renderTexture;
    Camera scopeCamera;
    public GameObject scopeObject;

    Material scopeRenderTextureMat;
    // Start is called before the first frame update
    void Start()
    {
        renderTexture = new RenderTexture(renderTextureToCopyFrom);
        scopeCamera = GetComponent<Camera>();
        scopeCamera.targetTexture = renderTexture;
        scopeObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", renderTexture);
    }

}
