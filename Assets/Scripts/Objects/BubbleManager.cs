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

    private GameObject _infoGameObject;
    private TextMeshProUGUI _infoText;

    private void Start()
    {
        _dbManager = GameObject.Find("DBManager").GetComponent<DataBaseManager>();
        _parent = GameObject.FindWithTag("Spawned");
        _parentScript = _parent.GetComponent<EncyclopaediaSingleItemManager>();
    }

    private void OnMouseDown()
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

        _infoGameObject.SetActive(true);
        _infoText.text = _entry;
    }

    private void GetEntry()
    {
        if(_entry != null) return;
        _entry = _dbManager.GetDBEntryInfo(_parent.name, _index);
    }

    public void SetTextObjects(GameObject canvas, TextMeshProUGUI infoText)
    {
        if(_infoGameObject != null) return;
        _infoGameObject = canvas;
        _infoText = infoText;
    }
}
