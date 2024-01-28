using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuButtonPushed()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayButtonPushed()
    {
        SceneManager.LoadScene(1);
    }
    public void SetPlayerName(string name)
    {
        Debug.Log(name);
        GameManager.instance.playerName = name;
    }
}
