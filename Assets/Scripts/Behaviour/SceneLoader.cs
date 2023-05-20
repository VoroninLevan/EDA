using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class SceneLoader : MonoBehaviour
{
    
    public void TransferToScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
