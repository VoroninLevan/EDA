using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObjectTerminator : MonoBehaviour
{
    public void TerminateObject()
    {
        GameObject[] spawned = GameObject.FindGameObjectsWithTag("Spawned");

        foreach (GameObject currentGo in spawned)
        {
            currentGo.SetActive(false);
        }

        GameObject[] spawnedSingle = GameObject.FindGameObjectsWithTag("SpawnedSingle");

        foreach (GameObject currentGo in spawnedSingle)
        {
            currentGo.SetActive(false);
        }
        //Destroy(GameObject.FindGameObjectWithTag("Spawned"));
        
    }
}
