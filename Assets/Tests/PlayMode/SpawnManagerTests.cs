using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpawnManagerTests
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SpawnManagerTests_GOHasZeroRotation()
    {
        GameObject go = new GameObject();
        go.AddComponent<SpawnManager>();

        Quaternion expected = Quaternion.Euler(0, 0, 0);
        Quaternion goRotation = go.transform.rotation;
        Assert.AreEqual(expected, goRotation);
        
        yield return null;
    }
}
