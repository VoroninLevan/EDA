using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameObject _currentlySpawned;

    private void Start()
    {
        if(gameObject.activeSelf) transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void SetSpawnedObject(GameObject spawnedObject)
    {
        _currentlySpawned = spawnedObject;
    }

    public void DestroySpawnedObject()
    {
        GameObject.Destroy(_currentlySpawned);
        _currentlySpawned = null;
    }
}
