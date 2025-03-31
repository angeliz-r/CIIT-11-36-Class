using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMove2D_IA : MonoBehaviour
{
    //NEW INPUT SYSTEM
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    private Vector2 _moveDir;
    private float _horizontal;
    private bool _flip;

    [SerializeField] private InputActionReference _move;
    [SerializeField] private InputActionReference _jump;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        _moveDir = _move.action.ReadValue<Vector2>();
        IsWalking();
        Flip();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(_speed * _moveDir.x, _moveDir.y);
        movement.y = _rb.linearVelocity.y;//setting the y so that the gravity stays normal and does not multiply
        _rb.linearVelocity = movement; //update linear velocity
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _horizontal = ctx.ReadValue<Vector2>().x;

    }

    private void Flip()
    {
        if (_moveDir.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_moveDir.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    public void Jump (InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            //_rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
            AudioManager.Instance.PlaySFX("jump");
            _animator.SetBool("IsWalking", false);
        }
    }


    private bool IsGrounded()
    {
        //Debug.Log("grounded");
        return Physics2D.OverlapCircle(_groundChecker.position, 0.3f, _groundLayer);
    }

    private void IsWalking()
    {
        if (_horizontal > 0 || _horizontal < 0)
            _animator.SetBool("IsWalking", true);
        else if (_horizontal == 0)
            _animator.SetBool("IsWalking", false);
    }


}
