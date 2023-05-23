using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DataBaseReplacementTests
{
    private DataBaseReplacement _dataBaseReplacement;

    private const string Venus = "Venus";
    private const string Moon = "Moon";


    [SetUp]
    public void StartSetup()
    {
        GameObject go = new GameObject();
        _dataBaseReplacement = go.AddComponent<DataBaseReplacement>();
        GameObject.Instantiate(go);
    }
    
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator DataBaseReplacementTests_CountIsThree()
    {
        Assert.AreEqual(3, _dataBaseReplacement.GetCount(Moon));
        
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator DataBaseReplacementTests_CountIsOne()
    {
        Assert.AreEqual(1, _dataBaseReplacement.GetCount(Venus));
        
        yield return null;
    }
}
