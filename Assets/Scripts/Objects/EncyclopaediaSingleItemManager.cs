using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EncyclopaediaSingleItemManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject[] points;
    
    private DataBaseManager _dbManager;

    private List<GameObject> _initBubbles;
    
    // Text objects
    private GameObject _infoGameObject;
    private TextMeshProUGUI _header;
    private TextMeshProUGUI _infoText;

    private bool _isSelected;
    
    // Start is called before the first frame update
    void Start()
    {
        _dbManager = GameObject.Find("DBManager").GetComponent<DataBaseManager>();
        _initBubbles = new List<GameObject>();
        
        int entryCount = _dbManager.GetEntryCount(gameObject.name);
        
        FindTextObjects();

        if (points.Length < 1) return;

        for (int i = 0; i < entryCount; i++)
        {
            GameObject currentPrefab = Instantiate(prefab);
            currentPrefab.transform.position = points[i].transform.position;
            _initBubbles.Add(currentPrefab);

            BubbleManager bubbleManagerScript = currentPrefab.GetComponent<BubbleManager>(); 
            bubbleManagerScript.SetIndex(i + 1);
            bubbleManagerScript.SetTextObjects(_infoGameObject, _infoText);
        }
    }

    private void OnMouseDown()
    {
        if(!_isSelected) return;
        
        ShowBubbles();
    }

    public void HideBubbles()
    {
        foreach (var bubble in _initBubbles)
        {
            bubble.SetActive(false);
        }

        _isSelected = true;
    }

    public void ShowBubbles()
    {
        _infoGameObject.SetActive(false);
        
        foreach (var bubble in _initBubbles)
        {
            bubble.SetActive(true);
        }

        _isSelected = false;
    }
    
    private void FindTextObjects()
    {
        if(_infoGameObject != null) return;
        _infoGameObject = GameObject.FindWithTag("InfoText");
        
        _header = GameObject.Find("Planet_Name").GetComponent<TextMeshProUGUI>();
        SetHeader();
        
        _infoText = GameObject.Find("Planet_Info").GetComponent<TextMeshProUGUI>();
        
        _infoGameObject.SetActive(false);
    }

    private void SetHeader()
    {
        _header.text = gameObject.name;
    }
}
