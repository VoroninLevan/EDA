using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    [SerializeField] public float speedReduction;
    [SerializeField] public float amplitude;
    [SerializeField] public float verticalAlignment;
    [SerializeField] public GameObject target;

    private EncyclopaediaMultiItemManager _encyclopaediaMultiItemManager;


    private Vector3 _origin, _destination;

    private void Start()
    {
        _encyclopaediaMultiItemManager = gameObject.GetComponent<EncyclopaediaMultiItemManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(_encyclopaediaMultiItemManager != null && _encyclopaediaMultiItemManager.IsSelected()) return;
        
        var position = target.transform.position;
        
        float x = position.x + MathF.Cos(Time.time / speedReduction) * amplitude;
        float y = position.y + verticalAlignment;
        float z = position.z + MathF.Sin(Time.time / speedReduction) * amplitude;
        
        transform.position = new Vector3(x,y,z);
    }
}
