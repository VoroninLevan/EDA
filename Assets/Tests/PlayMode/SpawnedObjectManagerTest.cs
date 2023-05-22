using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpawnedObjectManagerTest
{
    // A Test behaves as an ordinary method
    /*[Test]
    public void SpawnedObjectManagerSimplePasses()
    {
        // Use the Assert class to test conditions
    }*/

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SpawnedObjectManagerWithEnumeratorPasses()
    {
        SpawnedObjectManager.SetSelectedObject(new GameObject());
        Assert.True(SpawnedObjectManager.IsObjectSelected());
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator SpawnedObjectManagerIsNull()
    {
        SpawnedObjectManager.SetSelectedObject(new GameObject());
        SpawnedObjectManager.RemoveSelection();
        Assert.False(SpawnedObjectManager.IsObjectSelected());
        yield return null;
    }
}
