using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataBaseInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string filepath = Application.persistentDataPath + "/" + "ECA_DB";
        if (File.Exists(filepath)) return;
        WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "ECA_DB");
        while(!loadDB.isDone) {}
        File.WriteAllBytes(filepath, loadDB.bytes);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
