using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepPreventer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
