using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menumaNAGER : MonoBehaviour
{
    public GameObject menuma;
    public void PlayGame()
    {
        Application.LoadLevel("startScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
    
}
