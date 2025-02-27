using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMove2D_IA : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    private Vector2 _moveDir;
    private bool _flip;

    [SerializeField] private InputActionReference _move;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        _moveDir = _move.action.ReadValue<Vector2>();
        Move();
        Flip();
        if (_moveDir.x > 0)
        {
            _flip = false;
        }
        else if (_moveDir.x < 0)
        {
            _flip = true;
        }
    }

    private void Move()
    {
        Vector2 movement = new Vector2(_speed * _moveDir.x, _speed * _moveDir.y);
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
