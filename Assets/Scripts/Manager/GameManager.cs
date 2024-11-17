using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.IO;

[System.Serializable]
public class SaveData
{
    public bool[] isVisit = new bool[21];
    public bool[] ending = new bool[9];
    public string continueScene;
}

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    string path;

    public bool[]isVisit; 
    public bool[] ending;
    public string continueScene;

    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }
        else
        {
            Destroy(this);
        }

        var objs = FindObjectsOfType<GameManager>();
        if (FindObjectsOfType<GameManager>().Length==1)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

        isVisit = new bool[21];
        ending = new bool[9];

        path = Path.Combine(Application.dataPath, "database.json");
        JsonLoad();

    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        if (!File.Exists(path))
        {
            JsonMake();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData != null)
            {
                for (int i = 0; i < saveData.isVisit.Length; i++)
                {
                    GameManager.I.isVisit[i] = saveData.isVisit[i];
                }
                for (int i = 0; i < saveData.ending.Length; i++)
                {
                    GameManager.I.ending[i] = saveData.ending[i];
                }
                GameManager.I.continueScene = saveData.continueScene;

            }
        }
    }

    public void JsonMake()
    {
        SaveData saveData = new SaveData();

        saveData.isVisit[0] = true;
        for (int i = 1; i < 21; i++)
        {
            saveData.isVisit[i] = false;
        }
        for (int i = 0; i < 9; i++)
        {
            saveData.ending[i] = false;
        }
        GameManager.I.continueScene = "Scene1";
        saveData.continueScene = GameManager.I.continueScene;

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(path, json);
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        for (int i = 0; i < 21; i++)
        {
            saveData.isVisit[i] = GameManager.I.isVisit[i];
        }
        for (int i = 0; i < 9; i++)
        {
            saveData.ending[i] = GameManager.I.ending[i];
        }
        saveData.continueScene = GameManager.I.continueScene;

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(path, json);
    }


    public void ContinueBtn()
    {
        SceneManager.LoadScene(GameObject.Find("GameManager").GetComponent<GameManager>().continueScene);
    }
}
