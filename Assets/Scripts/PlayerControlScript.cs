using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerControlScript : MonoBehaviour
{
    [SerializeField]
    private int MaxHealth;
    private int health;
    [SerializeField]
    private HealthBar healthBar;
    public int Health
    {
        get { return health; }
        set
        {
            health  = value;
            if (health <= 0)
            {
                health = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            healthBar.UpdateHealthBar(MaxHealth, health);
        }
    }
    [SerializeField]
    private float speed = 1f;
    private bool FacingRight = true;
    private float Move;

    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxisRaw("Horizontal") * speed;
        if (Move < 0 && FacingRight)
            Flip();
        else if (Move > 0 && !FacingRight)
            Flip();

    }
    private void FixedUpdate()
    {
        Movement();
        
    }
    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "gems")
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "cherrys")
        {
            Instantiate(other.gameObject,new Vector3(transform.position.x + 2f,
                transform.position.y, transform.position.z), Quaternion.Euler(0,0,0));
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "lighning")
        {
            TakeDamage(50);
        }
        else if (other.gameObject.tag == "fire")
        {
            TakeDamage(50);
            _rb.AddForce(new Vector2(5, 10), ForceMode2D.Impulse);
        }
        else if (other.gameObject.tag == "DeathPool")
        {
            TakeDamage(100);
        }
    }
    
    private void Movement()
    {
        Vector2 tatgerVElocity = new Vector2(Move * 10f, _rb.velocity.y);
        _rb.velocity = tatgerVElocity;
    }
    private void TakeDamage(int damageValue)
    {
        Health -= damageValue;
    }
    
}
