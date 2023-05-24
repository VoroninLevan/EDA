using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EncyclopaediaMultiItemManager : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI header;
    [SerializeField] protected TextMeshProUGUI infoText;
    [SerializeField] protected Canvas canvas;

    private Vector3 _origin;
    private Vector3 _destination;
    private bool _isSelected;
    private bool _isActive;
    private bool _isDataRetrieved;

    private string _header, _info;

    private const float TotalMovementTime = 1f;
    
    private Transform _cameraTransform;
    private DataBaseManager _dbManager;
    private DataBaseReplacement _dataBaseReplacement;


    // Start is called before the first frame update
    private void Start()
    {
        _isActive = true;
        _origin = transform.position;
        if (Camera.main != null) _cameraTransform = Camera.main.transform;

        _dbManager = GameObject.Find("DBManager").GetComponent<DataBaseManager>();
        _dataBaseReplacement = GameObject.Find("Dict").GetComponent<DataBaseReplacement>();
    }

    public void OnMouseDown()
    {
        if (!_isSelected && _isActive)
        {
            if(SpawnedObjectManager.IsObjectSelected()) return;
            MoveObjectToCamera();
            SpawnedObjectManager.SetSelectedObject(gameObject);
        }
        else
        {
            if (!_isActive) return;
            MoveObjectFromCamera();
            SpawnedObjectManager.RemoveSelection();
        }
    }

    private void MoveObjectToCamera()
    {
        _isActive = false;
        _isSelected = true;
        _origin = transform.position;
        _destination = _cameraTransform.position + _cameraTransform.forward * 0.5f;

        StartCoroutine(MoveObjectToCameraCoroutine(_origin, _destination, false));
    }
    
    public void MoveObjectFromCamera()
    {
        _isActive = true;

        StartCoroutine(MoveObjectToCameraCoroutine(_destination, _origin, true));
        canvas.gameObject.SetActive(false);
    }

    public bool IsActive()
    {
        return _isActive;
    }

    public bool IsSelected()
    {
        return _isSelected;
    }
    
    private void SetText()
    {
        if (!_isDataRetrieved) RetrieveData();
        header.text = _header;
        infoText.text = _info;
        canvas.gameObject.SetActive(true);

        canvas.transform.position = _cameraTransform.position + _cameraTransform.forward * 0.5f;
    }

    private void RetrieveData()
    {
        //_header = _dbManager.GetDBEntryItem(gameObject.name);
        _header = gameObject.name;
        //_info = _dbManager.GetDBEntryInfo(gameObject.name, 1);
        _info = _dataBaseReplacement.GetInfo(gameObject.name, 1);
        
        _isDataRetrieved = !_isDataRetrieved;
    }

    private IEnumerator MoveObjectToCameraCoroutine(Vector3 origin, Vector3 destination, bool removeFocus)
    {
        float currentMovementTime = 0f;
        while (Vector3.Distance(transform.position, destination) > 0 && currentMovementTime < TotalMovementTime)
        {
            currentMovementTime += Time.deltaTime;
            transform.position = Vector3.Lerp(origin, destination, currentMovementTime / TotalMovementTime);
            yield return null;
        }

        if (removeFocus)
        {
            _isSelected = !_isSelected;
            _isActive = true;
        }
        else
        {
            SetText();
            _isActive = true;
        }
    }
}