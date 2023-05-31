using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target; //makes target private
    [SerializeField]
    private Vector3 offsetPosition; //makes the offset private but also visible


    // First function called
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = target.TransformPoint(offsetPosition);
        transform.rotation = target.rotation;  //rotates camera
    }
} //class
