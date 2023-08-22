using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class test : MonoBehaviour
{
    // private ItemUI a = new ItemUI();
    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.G))
    //     {
    //         int id = Random.Range(1, 2);
    //         Knapsack.Instance.StoreItem(id);
    //         
    //     }
    // }

    public int id = 3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Knapsack.Instance.StoreItem(id);
            //Destroy(gameObject);
        }
    }
}
