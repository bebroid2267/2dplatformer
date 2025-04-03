using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gohomeRespawn : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("ПрогрессДома", 1);
        }

    }
}
