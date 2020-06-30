using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetObject;
    private float distanceToTarget;

    void Start()
    {
        distanceToTarget = transform.position.x -
        targetObject.transform.position.x;
    }

    
    void Update()
    {
        MoveX();
    }

    void MoveX()
    {
        float targetObjectX = targetObject.transform.position.x;

        Vector3 newCameraPosition = transform.position;
        newCameraPosition.x = targetObjectX + distanceToTarget;
        newCameraPosition.y = 0;
        transform.position = newCameraPosition;
    }

}
