using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuHandler : MonoBehaviour
{
    public TextMeshProUGUI Label;
    public TextMeshProUGUI TextBox;
    
     private void Awake()
    {
        var data = DataBroker.Instance.LoadPlayerDetails();

        this.Label.text = $"High Score {data.HighScore} by {data.PlayerName}";
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
        DataBroker.Instance.PlayerName = TextBox.text;        
    }

    public void Exit()
    {

        DataBroker.Instance.SavePlayerDetails();
        // conditional compliling
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}