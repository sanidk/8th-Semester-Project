﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Lighsaber : MonoBehaviour
{
    //The number of vertices to create per frame
    private const int NUM_VERTICES = 12;

    [SerializeField]
    [Tooltip("The blade object")]
    private AudioClip audioWhenHit = null;

    [SerializeField]
    [Tooltip("The blade object")]
    private GameObject _blade = null;

    [SerializeField]
    [Tooltip("The empty game object located at the tip of the blade")]
    private GameObject _tip = null;

    [SerializeField]
    [Tooltip("The empty game object located at the base of the blade")]
    private GameObject _base = null;

    [SerializeField]
    [Tooltip("The mesh object with the mesh filter and mesh renderer")]
    private GameObject _meshParent = null;

    [SerializeField]
    [Tooltip("The number of frame that the trail should be rendered for")]
    private int _trailFrameLength = 3;

    [SerializeField]
    [ColorUsage(true, true)]
    [Tooltip("The colour of the blade and trail")]
    private Color _colour = Color.red;

    [SerializeField]
    [Tooltip("The amount of force applied to each side of a slice")]
    private float _forceAppliedToCut = 3f;

    public GameObject playerObject;

    private Mesh _mesh;
    private Vector3[] _vertices;
    private int[] _triangles;
    private int _frameCount;
    private Vector3 _previousTipPosition;
    private Vector3 _previousBasePosition;
    private Vector3 _triggerEnterTipPosition;
    private Vector3 _triggerEnterBasePosition;
    private Vector3 _triggerExitTipPosition;
    private AudioSource audioSource;
    public AudioClip scoreTemporary;
    private int score;
    private int streak;
    public Material bladeMat;

    public GameObject roomRefPlayer1;
    public GameObject roomRefPlayer2;

    Vector3 relativeSliceStart;
    void Start()
    {
        //if (!gameObject.GetComponentInParent<RealtimeTransform>().isOwnedLocallySelf) return;

        //Init mesh and triangles
        //_meshParent.transform.position = Vector3.zero;
        //_mesh = new Mesh();
        //_meshParent.GetComponent<MeshFilter>().mesh = _mesh;

        //Material trailMaterial = Instantiate(_meshParent.GetComponent<MeshRenderer>().sharedMaterial);
        //trailMaterial.SetColor("Color_8F0C0815", _colour);
        //_meshParent.GetComponent<MeshRenderer>().sharedMaterial = trailMaterial;

        //Material bladeMaterial = Instantiate(_blade.GetComponent<MeshRenderer>().sharedMaterial);
        //bladeMaterial.SetColor("Color_AF2E1BB", _colour);
        //_blade.GetComponent<MeshRenderer>().sharedMaterial = bladeMaterial;

        _vertices = new Vector3[_trailFrameLength * NUM_VERTICES];
        _triangles = new int[_vertices.Length];

        //Set starting position for tip and base
        _previousTipPosition = _tip.transform.position;
        _previousBasePosition = _base.transform.position;

        audioSource = GetComponent<AudioSource>();
        bladeMat = new Material(bladeMat); // copy of bladematerial
        bladeMat.SetColor("_EmissionColor", Color.red);
        _blade.GetComponent<MeshRenderer>().material = bladeMat;
    }

    void LateUpdate()
    {
        //if (!gameObject.GetComponentInParent<RealtimeTransform>().isOwnedLocallySelf) return;

        //Reset the frame count one we reach the frame length
        /*if (_frameCount == (_trailFrameLength * NUM_VERTICES))
        {
            _frameCount = 0;
        }

        //Draw first triangle vertices for back and front
        _vertices[_frameCount] = _base.transform.position;
        _vertices[_frameCount + 1] = _tip.transform.position;
        _vertices[_frameCount + 2] = _previousTipPosition;
        _vertices[_frameCount + 3] = _base.transform.position;
        _vertices[_frameCount + 4] = _previousTipPosition;
        _vertices[_frameCount + 5] = _tip.transform.position;

        //Draw fill in triangle vertices
        _vertices[_frameCount + 6] = _previousTipPosition;
        _vertices[_frameCount + 7] = _base.transform.position;
        _vertices[_frameCount + 8] = _previousBasePosition;
        _vertices[_frameCount + 9] = _previousTipPosition;
        _vertices[_frameCount + 10] = _previousBasePosition;
        _vertices[_frameCount + 11] = _base.transform.position;

        //Set triangles
        _triangles[_frameCount] = _frameCount;
        _triangles[_frameCount + 1] = _frameCount + 1;
        _triangles[_frameCount + 2] = _frameCount + 2;
        _triangles[_frameCount + 3] = _frameCount + 3;
        _triangles[_frameCount + 4] = _frameCount + 4;
        _triangles[_frameCount + 5] = _frameCount + 5;
        _triangles[_frameCount + 6] = _frameCount + 6;
        _triangles[_frameCount + 7] = _frameCount + 7;
        _triangles[_frameCount + 8] = _frameCount + 8;
        _triangles[_frameCount + 9] = _frameCount + 9;
        _triangles[_frameCount + 10] = _frameCount + 10;
        _triangles[_frameCount + 11] = _frameCount + 11;

        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;*/

        //Track the previous base and tip positions for the next frame
        _previousTipPosition = _tip.transform.position;
        _previousBasePosition = _base.transform.position;
        //_frameCount += NUM_VERTICES;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (!gameObject.GetComponentInParent<RealtimeTransform>().isOwnedLocallySelf) return;
        if (GameManagerLogic.isServer)
        {

            //Vector3 tipCollision = other.ClosestPoint(_triggerEnterTipPosition);
            //Vector3 baseCollision = other.ClosestPoint(_triggerEnterBasePosition);
            Vector3 tipCollision = _triggerEnterTipPosition;
            Vector3 baseCollision = _triggerEnterBasePosition;

            Vector3 sliceStart = (tipCollision + baseCollision) / 2;


            float oldMinX = other.transform.position.x - (other.transform.localScale.x / 2);
            float oldMaxX = other.transform.position.x + (other.transform.localScale.x / 2);
            float newMinX = roomRefPlayer2.transform.position.x - (roomRefPlayer2.transform.localScale.x / 2);
            float newMaxX = roomRefPlayer2.transform.position.x + (roomRefPlayer2.transform.localScale.x / 2);
            float valX = sliceStart.x;

            float oldMinY = other.transform.position.y - (other.transform.localScale.y / 2);
            float oldMaxY = other.transform.position.y + (other.transform.localScale.y / 2);
            float newMinY = roomRefPlayer2.transform.position.y - (roomRefPlayer2.transform.localScale.y / 2);
            float newMaxY = roomRefPlayer2.transform.position.y + (roomRefPlayer2.transform.localScale.y / 2);
            float valY = sliceStart.y;

            float oldMinZ = other.transform.position.z - (other.transform.localScale.z / 2);
            float oldMaxZ = other.transform.position.z + (other.transform.localScale.z / 2);
            float newMinZ = roomRefPlayer2.transform.position.z - (roomRefPlayer2.transform.localScale.z / 2);
            float newMaxZ = roomRefPlayer2.transform.position.z + (roomRefPlayer2.transform.localScale.z / 2);
            float valZ = sliceStart.z;

            float x = map2(valX, oldMinX, oldMaxX, newMinX, newMaxX);
            float y = map2(valY, oldMinY, oldMaxY, newMinY, newMaxY);
            float z = map2(valZ, oldMinZ, oldMaxZ, newMinZ, newMaxZ);


            relativeSliceStart = new Vector3(x, y, z);
        }

        _triggerEnterTipPosition = _tip.transform.position;
        _triggerEnterBasePosition = _base.transform.position;



        if (!other.GetComponent<Sliceable>())
        {
            return;
        }
        //audioSource.PlayOneShot(audioWhenHit);

        if (_colour != other.gameObject.GetComponent<ColouredObject>().getColorOfObject())
        {
            _colour = other.gameObject.GetComponent<ColouredObject>().getColorOfObject();
            _blade.GetComponent<MeshRenderer>().sharedMaterial.color = _colour;
            bladeMat.SetColor("_EmissionColor", _colour);
            _blade.GetComponent<MeshRenderer>().material = bladeMat;
            streak = 1;
            playerObject.GetComponent<PlayerStat>()._scoreStreak = 0;
            //other.GetComponent<CubeFeedback>().colour = _colour;
            return;
        }


        //audioSource.PlayOneShot(scoreTemporary);
        score++;
        streak++;
        //if (!playerObject.GetComponent<PlayerStat>()) { return; }
        //playerObject.GetComponent<PlayerStat>()._scoreStreak = streak;
        playerObject.GetComponent<PlayerStat>()._scoreStreak++;
        other.GetComponent<CubeFeedback>().cubeHit = false;
        other.GetComponent<CubeFeedback>().scoreStreakV2 = (int)playerObject.GetComponent<PlayerStat>()._scoreStreak;
        //No score variable to increase in Playerstat?
        switch ((int)playerObject.GetComponent<PlayerStat>()._scoreStreak)
        {
            case 1:
                bladeMat.SetColor("_EmissionColor", _colour * 2f);
                _blade.GetComponent<MeshRenderer>().material = bladeMat;
                break;
            case 2:
                bladeMat.SetColor("_EmissionColor", _colour * 3f);
                _blade.GetComponent<MeshRenderer>().material = bladeMat;
                break;
            case 3:
                bladeMat.SetColor("_EmissionColor", _colour * 4f);
                _blade.GetComponent<MeshRenderer>().material = bladeMat;
                break;
            case 4:
                bladeMat.SetColor("_EmissionColor", _colour * 5f);
                _blade.GetComponent<MeshRenderer>().material = bladeMat;
                break;
            case 5:
                bladeMat.SetColor("_EmissionColor", _colour * 6f);
                _blade.GetComponent<MeshRenderer>().material = bladeMat;
                break;
            case 6:
                bladeMat.SetColor("_EmissionColor", _colour * 7f);
                _blade.GetComponent<MeshRenderer>().material = bladeMat;
                break;
            case 7:
                bladeMat.SetColor("_EmissionColor", _colour * 8f);
                _blade.GetComponent<MeshRenderer>().material = bladeMat;
                break;
            case 8:
                bladeMat.SetColor("_EmissionColor", _colour * 9f);
                _blade.GetComponent<MeshRenderer>().material = bladeMat;
                break;
            case 9:
                bladeMat.SetColor("_EmissionColor", _colour * 11f);
                _blade.GetComponent<MeshRenderer>().material = bladeMat;
                break;
            case 10:
                bladeMat.SetColor("_EmissionColor", _colour * 15f);
                _blade.GetComponent<MeshRenderer>().material = bladeMat;
                break;
        }
    }

    public float map2(float Value, float OldMin, float OldMax, float NewMin, float NewMax)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((Value - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("RepresentationCube")) {

            if (!GameManagerLogic.isServer) {
                return;
            }

            _triggerExitTipPosition = _tip.transform.position;

            //Create a triangle between the tip and base so that we can get the normal
            Vector3 side1 = _triggerExitTipPosition - _triggerEnterTipPosition;
            Vector3 side2 = _triggerExitTipPosition - _triggerEnterBasePosition;

            //Get the point perpendicular to the triangle above which is the normal
            //https://docs.unity3d.com/Manual/ComputingNormalPerpendicularVector.html
            Vector3 normal = Vector3.Cross(side1, side2).normalized;

            //Transform the normal so that it is aligned with the object we are slicing's transform.
            Vector3 transformedNormal = ((Vector3)(other.gameObject.transform.localToWorldMatrix.transpose * normal)).normalized;

            //Get the enter position relative to the object we're cutting's local transform
            Vector3 transformedStartingPoint = other.gameObject.transform.InverseTransformPoint(_triggerEnterTipPosition);

            Plane plane = new Plane();

            plane.SetNormalAndPosition(
                    transformedNormal,
                    transformedStartingPoint);

            var direction = Vector3.Dot(Vector3.up, transformedNormal);

            //Flip the plane so that we always know which side the positive mesh is on
            if (direction < 0)
            {
                plane = plane.flipped;
            }


            Vector3 startPos = _triggerEnterTipPosition;


            Debug.DrawRay(startPos, normal, Color.green, 10);
            Debug.DrawRay(startPos, side1, Color.red, 10);
            Debug.DrawRay(startPos, side2, Color.blue, 10);


            Quaternion sliceDirection = Quaternion.LookRotation(side1);

            Quaternion laserOrientation = Quaternion.FromToRotation(Vector3.up, normal) * Quaternion.AngleAxis(90, Vector3.right);
            StartCoroutine(spawnLaser(sliceDirection, relativeSliceStart));


        }
        else
        {
            SliceCube(other);
        }

    }


    IEnumerator spawnLaser(Quaternion sliceDirection , Vector3 sliceStart) {
        yield return new WaitForSeconds(1);
        GameObject laser = Realtime.Instantiate("Laser", transform.position, transform.rotation, new Realtime.InstantiateOptions
        {
            ownedByClient = true,
            preventOwnershipTakeover = true,
            destroyWhenOwnerLeaves = false,
            destroyWhenLastClientLeaves = true
        });

        //laser.transform.position = sliceStart;

        //laser.GetComponent<LaserMovement>().direction = sliceDirection;
        //laser.GetComponent<LaserMovement>().startPosition = relativeSliceStart;
        laser.transform.position = relativeSliceStart;
        laser.transform.rotation = sliceDirection;

    }



    void SliceCube(Collider other) {
        //if (!gameObject.GetComponentInParent<RealtimeTransform>().isOwnedLocallySelf) return;

        _triggerExitTipPosition = _tip.transform.position;

        //Create a triangle between the tip and base so that we can get the normal
        Vector3 side1 = _triggerExitTipPosition - _triggerEnterTipPosition;
        Vector3 side2 = _triggerExitTipPosition - _triggerEnterBasePosition;

        //Get the point perpendicular to the triangle above which is the normal
        //https://docs.unity3d.com/Manual/ComputingNormalPerpendicularVector.html
        Vector3 normal = Vector3.Cross(side1, side2).normalized;

        //Transform the normal so that it is aligned with the object we are slicing's transform.
        Vector3 transformedNormal = ((Vector3)(other.gameObject.transform.localToWorldMatrix.transpose * normal)).normalized;

        //Get the enter position relative to the object we're cutting's local transform
        Vector3 transformedStartingPoint = other.gameObject.transform.InverseTransformPoint(_triggerEnterTipPosition);

        Plane plane = new Plane();

        plane.SetNormalAndPosition(
                transformedNormal,
                transformedStartingPoint);

        var direction = Vector3.Dot(Vector3.up, transformedNormal);

        //Flip the plane so that we always know which side the positive mesh is on
        if (direction < 0)
        {
            plane = plane.flipped;
        }



        GameObject[] slices = Slicer.Slice(plane, other.gameObject);

        //Destroy(other.gameObject); - Commented, Instead Despawn.
        if (GameManagerLogic.isServer)
        {
            other.GetComponent<BallBehaviour>().DespawnBall(); // Despawn - Relocate the full ball
        }

        other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        other.gameObject.GetComponent<BoxCollider>().enabled = false;

        StartCoroutine(reEnableMeshRenderer(other.gameObject, 2));


        Rigidbody rigidbody = slices[1].GetComponent<Rigidbody>();
        Vector3 newNormal = transformedNormal + Vector3.up * _forceAppliedToCut;
        rigidbody.AddForce(newNormal, ForceMode.Impulse);

        //maybe make ienumerater to wait a few seconds before despawning ball
        //other.getcomponent<BallBehaviour>().Despawn(); ish
        //Also script or function to delete object after few second?
    }

    IEnumerator reEnableMeshRenderer(GameObject obj, float time) { 
        yield return new WaitForSeconds(time);
        obj.GetComponent<MeshRenderer>().enabled = true;
        obj.GetComponent<BoxCollider>().enabled = true;


    }
}
