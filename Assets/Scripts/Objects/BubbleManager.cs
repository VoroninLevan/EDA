using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    private int _index;
    private string _entry = null;
    
    private DataBaseManager _dbManager;
    private GameObject _parent;
    private EncyclopaediaSingleItemManager _parentScript;
    private DataBaseReplacement _dataBaseReplacement;

    public GameObject infoGameObject;
    public TextMeshProUGUI infoText;

    private void Start()
    {
        _dbManager = GameObject.Find("DBManager").GetComponent<DataBaseManager>();
        _dataBaseReplacement = GameObject.Find("Dict").GetComponent<DataBaseReplacement>();
        
        _parent = GameObject.FindWithTag("SpawnedSingle");
        _parentScript = _parent.GetComponent<EncyclopaediaSingleItemManager>();
    }

    public void OnMouseDown()
    {
        _parentScript.HideBubbles();
        SetText();
    }

    public void SetIndex(int index)
    {
        _index = index;
    }

    private void SetText()
    {
        GetEntry();

        infoGameObject.SetActive(true);
        infoText.text = _entry;
    }

    private void GetEntry()
    {
        if(_entry != null) return;
        //_entry = _dbManager.GetDBEntryInfo(_parent.name, _index);
        _entry = _dataBaseReplacement.GetInfo(_parent.name, _index);
    }

    public void SetTextObjects(GameObject canvas, TextMeshProUGUI infoText)
    {
        if(infoGameObject != null) return;
        infoGameObject = canvas;
        this.infoText = infoText;
    }

    public GameObject GetParent()
    {
        return _parent;
    }

    public int GetIndex()
    {
        return _index;
    }
}
