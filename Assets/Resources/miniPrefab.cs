using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class miniPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    bool isTargetPosReached;
    float spawnTime;
    Vector3 initialPosition;
    public Transform targetTransform;
    private Vector3 scaleChange;
    private Vector3 rotationChange;
    private Vector3 finalPosition;
    private bool finalPosSet;
    public GameObject playerObj;
    private Vector3 targetPositionTest;
    private Vector3 initialScale;
    private Quaternion initialRotation;

    void Start()
    {
        spawnTime = Time.time;
        initialPosition = transform.position;
        initialScale = transform.localScale;
        scaleChange = new Vector3(0.01f,0.01f,0.01f);
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //ifServercheck?
        if (!GameManagerLogic.isSendFeedbackEnabled) { return; }
        if (!GetComponent<RealtimeView>().isOwnedLocallySelf) { return; }
        //transform.position += new Vector3(0.01f, 0.01f, 0.01f); // works 
        if (targetTransform != null)
        {
            //if (!playerObj.GetComponent<PlayerBehaviour>().spawnedTrapPositionSet) { return; }
            //targetPositionTest = playerObj.GetComponent<PlayerBehaviour>().spawnedTrapPosition;
            float elapsedTime = Time.time - spawnTime;
            if (gameObject.CompareTag("MiniMace"))
            {
                finalPosition = targetTransform.position + new Vector3(0, 4.5f, 0);
                transform.localScale = Vector3.Lerp(initialScale, new Vector3(0.5f, 0.5f, 0.5f), elapsedTime / 2);
                transform.position = Vector3.Lerp(initialPosition, finalPosition, elapsedTime / 2);

                //finalPosition = targetPositionTest + new Vector3(0, 3.5f, 0);
                //transform.localScale += scaleChange;//* Time.deltaTime;
                //transform.RotateAround(transform.position, Vector3.up, 80 * Time.deltaTime); // rotate around self with 5 degrees per sec.
            }
            else if (gameObject.CompareTag("MiniSpears"))
            {
                finalPosition = targetTransform.position + new Vector3(0,-0.3f,0);
                transform.localScale = Vector3.Lerp(initialScale, new Vector3(0.65f,0.65f,0.65f), elapsedTime / 2);
                transform.position = Vector3.Lerp(initialPosition, finalPosition, elapsedTime / 2);
                transform.rotation = Quaternion.Lerp(initialRotation,Quaternion.Euler(new Vector3(0,360,0)), elapsedTime / 2);
                //finalPosition = targetPositionTest + new Vector3(0, 3.5f, 0);
                //transform.localScale += scaleChange;//* Time.deltaTime;
                //transform.RotateAround(transform.position, Vector3.up, 80 * Time.deltaTime); // rotate around self with 5 degrees per sec.
            }
            else if (gameObject.CompareTag("MiniFist"))
            {
                finalPosition = targetTransform.position + new Vector3(0, 4.5f, 0);
                transform.localScale = Vector3.Lerp(initialScale, new Vector3(0.1f, 0.1f, 0.1f), elapsedTime / 2);
                transform.position = Vector3.Lerp(initialPosition, finalPosition, elapsedTime / 2);
                transform.rotation = Quaternion.Lerp(initialRotation, Quaternion.Euler(new Vector3(0, 0, 270)), elapsedTime / 2);

                //finalPosition = targetPositionTest + new Vector3(0, 3.5f, 0);
            }
            else if (gameObject.CompareTag("MiniArrows"))
            {
                finalPosition = targetTransform.position + new Vector3(0, 0, 0);
                transform.localScale = Vector3.Lerp(initialScale, new Vector3(0.55f, 0.55f, 0.55f), elapsedTime / 2);
                transform.position = Vector3.Lerp(initialPosition, finalPosition, elapsedTime / 2);
            }
            //float elapsedTime = Time.time - spawnTime;

            /*
            if (transform.localScale.x < 1.5f)
            {
                transform.localScale += scaleChange;//* Time.deltaTime;
                transform.RotateAround(transform.position, Vector3.up, 80 * Time.deltaTime); // rotate around self with 5 degrees per sec.
            }*/

            //float sineAlpha = Mathf.Sin(Time.time * 4);
            //Color color = new Color(originalMat.color.r, originalMat.color.g, originalMat.color.b, sineAlpha);
            //transform.position += new Vector3(0.1f, 0.1f, 0.1f);

            //mat.color = color;

            if (elapsedTime > 3) // set to 2.5 after
            {
                isTargetPosReached = true;
                playerObj.GetComponent<PlayerBehaviour>().miniPrefabOnLoc = true;
                Realtime.Destroy(gameObject);
            }
            //return;
        }
    }
}
