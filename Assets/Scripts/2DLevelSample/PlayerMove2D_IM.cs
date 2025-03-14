using UnityEngine;

public class PlayerMove2D : MonoBehaviour
{
    //OLD
    [SerializeField] private float _speed = 20f; //serializefield while keeping values private is best practice
    private bool _flip;
    
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

        //Look for which buttons were pressed
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _flip = true;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _flip = false;
        }
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(_speed * inputX, _speed * inputY);
        _rb.linearVelocity = movement;
    }
    private void Flip()
    {
        if (_flip)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}
