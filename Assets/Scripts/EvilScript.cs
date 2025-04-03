using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EvilScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;
    private float move = 1;
    private float reserveMove;
    private bool FacingRight = true;
    public Animator animator;
    private Rigidbody2D _rb;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        reserveMove = move;
    }
    private void FixedUpdate()
    {
        Movement();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "WallEvil")
        {
            Flip();
            if (move == -1)
            {
                reserveMove = move;
                move = 1;
            }
            else if (move == 1)
            {
                move = -1;
                reserveMove = move;
            }
               
            animator.SetBool("attack", false);
        }
        else if (collision.gameObject.tag == "player")
        {
            _rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            move = 0;
            animator.SetBool("attack", true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Flip();
            _rb.constraints = RigidbodyConstraints2D.None;
            _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        if (move == 0)
        {
            move = reserveMove;
            if (animator.GetBool("attack") == true)
            {
                animator.SetBool("attack", false);
            }
        }

        
    }
    // Update is called once per frame
    private void Update()
    {
        animator.SetFloat("HorizontalMove", Mathf.Abs(move));
    }
    private void Movement()
    {
        if (move != 0)
        {
            Vector2 force = new Vector2(move, 2.6752f);
            if (_rb != null)
                _rb.AddForce(force * speed, ForceMode2D.Impulse);

        }

    }
    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public class MoveObject : MonoBehaviour
    {
        private float _time;
        [SerializeField] private float _currFrame = 1;
        [SerializeField] private float _n;
        private Vector3 _from;
        private Vector3 _to;
        private bool _start;

        private int _type;

        void Update()
        {
            if (_start && _type == 1)
            {
                float dX = _to.x - _from.x;
                float dY = _to.y - _from.y;
                transform.position =
                        new Vector3(_from.x + (dX / _n) * _currFrame, _from.y + (dY / _n) * _currFrame, transform.position.z);
                _currFrame++;
                if (Mathf.Abs(transform.position.x - _to.x) < 0.01 && Mathf.Abs(transform.position.y - _to.y) < 0.01)
                {
                    transform.position = _to;
                    _start = false;
                    Destroy(transform.GetComponent<MoveObject>());
                }
            }

            if (_start && _type == 2)
            {
                float dX = _to.x - _from.x;
                float dY = _to.y - _from.y;

                transform.position = new Vector3(_from.x + (dX / _n) * _currFrame,
                        _from.y + dY * (Mathf.Pow(_currFrame / _n, 3)),
                        transform.position.z);
                _currFrame++;
                if (Mathf.Abs(transform.position.x - _to.x) < 0.01 && Mathf.Abs(transform.position.y - _to.y) < 0.01)
                {
                    transform.position = _to;
                    _start = false;
                    Destroy(transform.GetComponent<MoveObject>());
                }
            }
        }

        private void Move(Transform trans, Vector3 to, float second)
        {
            _from = trans.position;
            _to = to;
            _n = (int)(Time.timeScale / Time.deltaTime * second);
            _start = true;
            _type = 1;
        }

        private void MoveCurve(Transform trans, Vector3 to, float second)
        {
            _from = trans.position;
            _to = to;
            _n = (int)(Time.timeScale / Time.deltaTime * second);
            _start = true;
            _type = 2;
        }

        public static void StartMove(Transform transform, Vector3 to, float second)
        {
            MoveObject s = transform.gameObject.AddComponent<MoveObject>();
            s.Move(transform, to, second);
        }

        public static void StartMoveCurve(Transform transform, Vector3 to, float second)
        {
            MoveObject s = transform.gameObject.AddComponent<MoveObject>();
            s.MoveCurve(transform, to, second);
        }
    }

}
