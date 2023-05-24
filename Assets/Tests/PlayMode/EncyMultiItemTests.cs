using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class EncyMultiItemTests
{
    
    private const string Header = "Earth";
    private const string Info = "Earth—our home planet—is";
    
    [SetUp]
    public void StartSetup()
    {
        SceneManager.LoadScene(3);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator EncyMultiItemTests_ObjectNotActive()
    {
        GameObject earth = GameObject.Find("Earth");
        EncyclopaediaMultiItemManager managerScript = earth.GetComponent<EncyclopaediaMultiItemManager>();
        managerScript.OnMouseDown();
        
        Assert.False(managerScript.IsActive());
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator EncyMultiItemTests_ObjectActive()
    {
        GameObject earth = GameObject.Find("Earth");
        EncyclopaediaMultiItemManager managerScript = earth.GetComponent<EncyclopaediaMultiItemManager>();

        Assert.True(managerScript.IsActive());
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator EncyMultiItemTests_ObjectNotSelected()
    {
        GameObject earth = GameObject.Find("Earth");
        EncyclopaediaMultiItemManager managerScript = earth.GetComponent<EncyclopaediaMultiItemManager>();

        Assert.False(managerScript.IsSelected());
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator EncyMultiItemTests_ObjectSelected()
    {
        GameObject earth = GameObject.Find("Earth");
        EncyclopaediaMultiItemManager managerScript = earth.GetComponent<EncyclopaediaMultiItemManager>();
        managerScript.OnMouseDown();
        
        Assert.True(managerScript.IsSelected());
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator EncyMultiItemTests_CanvasActive()
    {
        GameObject earth = GameObject.Find("Earth");
        EncyclopaediaMultiItemManager managerScript = earth.GetComponent<EncyclopaediaMultiItemManager>();
        managerScript.OnMouseDown();
        
        yield return new WaitForSeconds(2f);
        
        GameObject canvas = GameObject.Find("CanvasPopUp");
        Assert.True(canvas.activeSelf);
    }
    
    [UnityTest]
    public IEnumerator EncyMultiItemTests_HeaderAsExpected()
    {
        GameObject earth = GameObject.Find("Earth");
        EncyclopaediaMultiItemManager managerScript = earth.GetComponent<EncyclopaediaMultiItemManager>();
        managerScript.OnMouseDown();
        
        yield return new WaitForSeconds(2f);
        
        TextMeshProUGUI header = GameObject.Find("Planet_Name").GetComponent<TextMeshProUGUI>();
        Assert.True(header.text.Contains(Header));
    }
    
    [UnityTest]
    public IEnumerator EncyMultiItemTests_InfoAsExpected()
    {
        GameObject earth = GameObject.Find("Earth");
        EncyclopaediaMultiItemManager managerScript = earth.GetComponent<EncyclopaediaMultiItemManager>();
        managerScript.OnMouseDown();
        
        yield return new WaitForSeconds(2f);
        
        TextMeshProUGUI info = GameObject.Find("Planet_Info").GetComponent<TextMeshProUGUI>();
        Assert.True(info.text.Contains(Info));
    }
}
