using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb; //adds physics to our object
    public float moveSpeed;
    private Vector3 _moveDir;
    public float jumpForce;
    private bool _isGrounded;
    private Vector3 lastPosition;
    //controls
    public InputActionReference move;
    public InputActionReference jump;

    private void OnEnable()
    {
        //C# event to listen
        jump.action.performed += Jump;
    }

    private void Start()
    {
        if (!SampleGameManager.Instance.IsNewGame() && PlayerPrefs.HasKey("playerPositionX"))
        {
            lastPosition = SampleGameManager.Instance.GetPlayerPosition();
            this.gameObject.GetComponentInParent<Rigidbody>().position = lastPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _moveDir = move.action.ReadValue<Vector3>(); //checking if move buttons are pressed
    }

    private void FixedUpdate() //fixedupdate for physics
    {
        Vector3 movement = new Vector3(_moveDir.x * moveSpeed, 0, _moveDir.z * moveSpeed);
        movement.y = rb.linearVelocity.y;//setting the y so that the gravity stays normal and does not multiply
        rb.linearVelocity = movement; //update linear velocity
    }


    //Jump event that is being called
    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && _isGrounded == true) //will only trigger if player hits the jump button and if player is on the ground
        {
            Debug.Log("Jumped!");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision objectCollidedWith) //check if player is on the grund
    {
        if (objectCollidedWith.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }
    private void OnDisable()
    {
        //needs to be disabled since it will make a new event every time the script runs
        jump.action.performed -= Jump;
    }

}
