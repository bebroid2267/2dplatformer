using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gofinallySceneScript : MonoBehaviour
{
    private int CheckFirstHouse;
    private void Start()
    {
        CheckFirstHouse = PlayerPrefs.GetInt("������������", 0);
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" && CheckFirstHouse == 1)
            SceneManager.LoadScene(3);
        PlayerPrefs.SetInt("������������", 0);

    }
}
