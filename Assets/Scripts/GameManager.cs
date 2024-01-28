using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string playerName;

    string highScoreName;
    int highScoreValue;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        LoadHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName(string name)
    {
        Debug.Log(name);
        playerName = name;
    }

    public void SetHighscore(int points)
    {
        if (points > highScoreValue)
        {
            highScoreValue = points;
            highScoreName = playerName;
            SetHighscoreText();
            SaveHighScore();
        }  
    }

    public void SetHighscoreText()
    {
        GameObject scoreTxtObj = GameObject.Find("HighScoreText");
        if (scoreTxtObj != null)
        {
            scoreTxtObj.GetComponent<Text>().text = $"Best Score : {highScoreName}: {highScoreValue}";
        }
    }
    [System.Serializable]
    class SaveData
    {
        public string name;
        public int value;
    }

    void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.name = highScoreName;
        data.value = highScoreValue;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScoreName = data.name;
            highScoreValue = data.value;
        }
        else
        {
            highScoreName = "Player";
            highScoreValue = 0;
        }
    }
}
