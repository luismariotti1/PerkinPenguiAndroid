using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsLayoutSelector : MonoBehaviour
{
    public GameObject[] coinLayoutPrefab;
    private void Awake()
    {
        int radom = Random.Range(0, coinLayoutPrefab.Length);
        Instantiate(coinLayoutPrefab[radom],this.transform);
    }
}
