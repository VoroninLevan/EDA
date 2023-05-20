using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpawnedObjectManager
{
    private static GameObject _currentlySelected;

    public static void SetSelectedObject(GameObject selectedObject)
    {
        _currentlySelected = selectedObject;
    }

    public static bool IsObjectSelected()
    {
        return _currentlySelected != null;
    }

    public static void RemoveSelection()
    {
        _currentlySelected = null;
    }
}
