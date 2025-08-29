using UnityEngine;

public class PlayerMove2D : MonoBehaviour
{
    [SerializeField] private float _speed = 20f; //serializefield while keeping values private is best practice
    [SerializeField] private float _jumpForce = 8f;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        //get the needed components
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Move();
        Flip();
        Jump();
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(_speed * inputX, _rb.linearVelocity.y);
        _rb.linearVelocity = movement;
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
        }
    }
    private void Flip()
    {
        if (_rb.linearVelocity.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_rb.linearVelocity.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
