using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject[] avaibleBlocks;
    public GameObject container;
    private bool isTriggered = false;
    int t, i;

    void Awake()
    {
        container = new GameObject("Map");
        GameObject room = (GameObject)Instantiate(avaibleBlocks[0], Vector3.zero, quaternion.identity, container.transform);
        t = 1;
        i = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("teste");
        if (collision.gameObject.CompareTag("FinalBorder"))
        {
            if (isTriggered == false)
            {
                Vector3 v3 = Vector3.zero;
                v3.x = 14.4f * t;
                GameObject room = (GameObject)Instantiate(avaibleBlocks[0], v3, quaternion.identity, container.transform);
                t++;
                if (t > 2)
                {
                    Debug.Log(i);
                    Destroy(container.transform.GetChild(i).gameObject);
                }
                isTriggered = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }
}
