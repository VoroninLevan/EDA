using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CircularMotionTests
{
    private Vector3 _goPosition;
    private GameObject _go;

    [SetUp]
    public void StartSetup()
    {
        _go = new GameObject();
        GameObject target = new GameObject();
        //_go.AddComponent<EncyclopaediaMultiItemManager>();
        CircularMotion circularMotion = _go.AddComponent<CircularMotion>();
        circularMotion.amplitude = 3;
        circularMotion.speedReduction = 1;
        circularMotion.verticalAlignment = 3;
        circularMotion.target = target;
        GameObject.Instantiate(_go);
        _goPosition = _go.transform.position;
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator CircularMotionTests_ObjectMoving()
    {
        Assert.AreNotEqual(_goPosition, _go.transform.position);
        yield return null;
    }
}
