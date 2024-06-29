using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class MainManager : MonoBehaviour
{
    public static MainManager instance { get; private set; }
    public Color teamColor;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveColor()
    {
        string json = JsonUtility.ToJson(instance.teamColor);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(System.IO.File.Exists(path))
        {
            string json = File.ReadAllText(path);
            instance.teamColor = JsonUtility.FromJson<Color>(json);
        }
    }
}