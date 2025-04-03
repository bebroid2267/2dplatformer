using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathBoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 0.2f);
    }
}
