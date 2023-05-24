using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ARImageTracking : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    private ARTrackedImageManager _arTrackedImageManager;

    private void Awake()
    {
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach (var prefab in prefabs)
        {
            GameObject currentPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            currentPrefab.name = prefab.name;
            
            spawnedPrefabs.Add(prefab.name, currentPrefab);
            currentPrefab.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage currentImage in eventArgs.added)
        {
            UpdateImage(currentImage);
        }
        foreach (ARTrackedImage currentImage in eventArgs.updated)
        {
            UpdateImage(currentImage);
        }
        foreach (ARTrackedImage currentImage in eventArgs.removed)
        {
            spawnedPrefabs[currentImage.name].SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage image)
    {
        string name = image.referenceImage.name;
        Vector3 position = image.transform.up * 0.2f;

        GameObject prefab = spawnedPrefabs[name];
        prefab.transform.position = position;
        
        prefab.SetActive(true);

        foreach (GameObject gameObject in spawnedPrefabs.Values)
        {
            if (gameObject.name != name) gameObject.SetActive(false);
        }
    }
}
