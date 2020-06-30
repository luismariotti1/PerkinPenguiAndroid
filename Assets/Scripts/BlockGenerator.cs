using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject[] avaibleBlocks;
    public GameObject container;
    private float xSize;
    private int nextPosition, childIndex;
    private bool isTriggered;
    public GameObject targetObject;
    private Vector3 v3;
    private float distanceToTarget;
    void Awake()
    {
        container = new GameObject("Map");
        Instantiate(avaibleBlocks[0], Vector3.zero, quaternion.identity, container.transform);
        xSize = 14.4f;
        nextPosition = 1;
        childIndex = 0;
        isTriggered = false;
        v3 = Vector3.zero;
        v3.y = targetObject.transform.position.y + 4;
        v3.x = targetObject.transform.position.x + 4;
        transform.position = v3;
        distanceToTarget = transform.position.x - targetObject.transform.position.x;
    }

    private void Update()
    {
        MoveX();    
    }

    void MoveX()
    {
        float targetObjectX = targetObject.transform.position.x;

        v3.x = targetObjectX + distanceToTarget;
        transform.position = v3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FinalBorder"))
        {
            Debug.Log("true");
            if (isTriggered == false)
            {
                creatSectionMap();
                isTriggered = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }
    private void creatSectionMap()
    {
        Vector3 v3 = Vector3.zero;
        v3.x = xSize * nextPosition;
        Instantiate(avaibleBlocks[0], v3, quaternion.identity, container.transform);
        nextPosition++;
        if (nextPosition > 2)
        {
            Destroy(container.transform.GetChild(childIndex).gameObject);
        }
    }
}
