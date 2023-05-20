using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUIManager : MonoBehaviour
{

    // Update is called once per frame
    private void Update()
    {
        if (IsEnabled())
        {
            transform.rotation = Quaternion.LookRotation( transform.position - Camera.main.transform.position );
        }
    }

    private bool IsEnabled()
    {
        return gameObject.activeSelf;
    }
}
