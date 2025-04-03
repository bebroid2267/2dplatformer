using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anlyLightScript : MonoBehaviour
{
    private Vector2 StartPosition;
    Rigidbody2D rb;
    public float speed = 10;
    public LayerMask passLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartPosition = transform.position;
    }
    void Update()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.position = StartPosition;
        }
        else if (passLayer == (passLayer | (1 << collision.gameObject.layer)))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        //else if (collision.gameObject.tag == "player")
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
