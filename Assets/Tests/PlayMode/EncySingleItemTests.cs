using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class EncySingleItemTests
{

    private const string Header = "Moon";
    private const string Info = "The fifth largest moon";
    private const int BubbleCount = 3;
    
    [SetUp]
    public void StartSetup()
    {
        SceneManager.LoadScene(2);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator EncySingleItemTests_BubblesAsExpected()
    {
        GameObject moon = GameObject.Find("Moon");
        EncyclopaediaSingleItemManager managerScript = moon.GetComponent<EncyclopaediaSingleItemManager>();
        
        Assert.AreEqual(BubbleCount, managerScript.GetInitBubbles());
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator EncySingleItemTests_BubblesAppearsInScene()
    {
        GameObject moon = GameObject.Find("Moon");
        EncyclopaediaSingleItemManager managerScript = moon.GetComponent<EncyclopaediaSingleItemManager>();
        
        GameObject bubble = GameObject.Find("Bubble(Clone)");
        
        Assert.NotNull(bubble);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator EncySingleItemTests_BubblesNotExists()
    {
        GameObject moon = GameObject.Find("Moon");
        EncyclopaediaSingleItemManager managerScript = moon.GetComponent<EncyclopaediaSingleItemManager>();
        managerScript.HideBubbles();
        
        GameObject bubble = GameObject.Find("Bubble(Clone)");
        
        Assert.Null(bubble);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator EncySingleItemTests_HeaderAsExpected()
    {
        GameObject moon = GameObject.Find("Moon");
        EncyclopaediaSingleItemManager managerScript = moon.GetComponent<EncyclopaediaSingleItemManager>();
        managerScript.HideBubbles();
        
        TextMeshProUGUI info = GameObject.Find("Planet_Name").GetComponent<TextMeshProUGUI>();
        
        Assert.True(info.text.Contains(Header));
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator EncySingleItemTests_InfoDisabled()
    {
        GameObject moon = GameObject.Find("Moon");
        EncyclopaediaSingleItemManager managerScript = moon.GetComponent<EncyclopaediaSingleItemManager>();

        GameObject info = GameObject.Find("Planet_Info");

        Assert.Null(info);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator EncySingleItemTests_InfoAsExpected()
    {
        GameObject moon = GameObject.Find("Moon");
        EncyclopaediaSingleItemManager managerScript = moon.GetComponent<EncyclopaediaSingleItemManager>();

        BubbleManager bubbleManagerScript = GameObject.Find("Bubble(Clone)").GetComponent<BubbleManager>();
        bubbleManagerScript.OnMouseDown();

        yield return new WaitForSeconds(1f);
        
        TextMeshProUGUI info = GameObject.Find("Planet_Info").GetComponent<TextMeshProUGUI>();
        
        Assert.True(info.text.Contains(Info));
        yield return null;
    }
}
