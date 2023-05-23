using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class BubbleTests
{
    private const string Text = "The fifth largest";

    private BubbleManager _bubbleManagerScript;
    
    [SetUp]
    public void StartSetup()
    {
        SceneManager.LoadScene(2);
    }
    
    
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BubbleTests_TextObjectsAreNotNull()
    {
        GameObject bubbleObj = GameObject.Find("Bubble(Clone)");
        _bubbleManagerScript = bubbleObj.GetComponent<BubbleManager>();
        
        _bubbleManagerScript.SetTextObjects(new GameObject(), new GameObject().AddComponent<TextMeshProUGUI>());
        
        Assert.NotNull(_bubbleManagerScript.infoGameObject);
        Assert.NotNull(_bubbleManagerScript.infoText);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator BubbleTests_TextAsExpected()
    {
        GameObject bubbleObj = GameObject.Find("Bubble(Clone)");
        _bubbleManagerScript = bubbleObj.GetComponent<BubbleManager>();
        
        _bubbleManagerScript.SetTextObjects(new GameObject(), new GameObject().AddComponent<TextMeshProUGUI>());
        _bubbleManagerScript.OnMouseDown();
        
        Assert.True(_bubbleManagerScript.infoText.text.Contains(Text));
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator BubbleTests_IndexAsExpected()
    {
        GameObject bubbleObj = GameObject.Find("Bubble(Clone)");
        _bubbleManagerScript = bubbleObj.GetComponent<BubbleManager>();

        Assert.True(1 == _bubbleManagerScript.GetIndex());
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator BubbleTests_ParentExists()
    {
        GameObject bubbleObj = GameObject.Find("Bubble(Clone)");
        _bubbleManagerScript = bubbleObj.GetComponent<BubbleManager>();

        Assert.NotNull(_bubbleManagerScript.GetParent());
        yield return null;
    }
}
