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
    
    public Camera raycastCamera;
    
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Start()
    {
        if(gameObject.activeSelf) transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)&&(hit.collider.gameObject.CompareTag("Spawned")))
        {
            Destroy(hit.collider.gameObject);
        }
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            // Check if finger is over a UI element
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("Touched the UI");
            }
            else if (Physics.Raycast(ray, out hit)&&(hit.transform.name.ToString()!= "Quad"))
            {
                if (Input.GetTouch(0).deltaTime > 0.2f)
                {
                    Destroy(hit.transform.gameObject);
                }
            }

            else
            {
                //PlaceObject();
            }
        }
    }*/
    
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
