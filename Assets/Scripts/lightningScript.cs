using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lightningScript : MonoBehaviour
{
    private Vector2 StartPosition;
    Rigidbody2D rb;
    public float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartPosition = transform.position;
    }
    void Update()
    {
        rb.velocity = new Vector2(0, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.position = StartPosition;
        }
        //else if (collision.gameObject.tag == "player")
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}