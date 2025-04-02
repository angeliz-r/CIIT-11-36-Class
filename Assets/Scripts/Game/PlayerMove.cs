using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    private Animator _animator;

    public float moveSpeed;
    public float jumpForce;
    public float rotationSpeed = 4f;

    private Vector3 _moveDir;
    private bool _isGrounded;
    
    private Vector3 lastPosition;

    //controls
    public InputActionReference move;
    public InputActionReference jump;
    
    private Transform cameraMainTransform;
   

    private void OnEnable()
    {
        //C# event to listen
        jump.action.performed += Jump;
        _animator = GetComponent<Animator>();
        cameraMainTransform = Camera.main.transform;
    }

    private void Start()
    {
        //check if player is in a new game and if the player has a checkpoint hit
        if (!SampleGameManager.Instance.IsNewGame() && PlayerPrefs.HasKey("playerPositionX"))
        {
            //if the player did hit a checkpoint, set its new position to the new player position
            lastPosition = SampleGameManager.Instance.GetPlayerPosition();
            this.gameObject.GetComponentInParent<Rigidbody>().position = lastPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _moveDir = move.action.ReadValue<Vector3>(); //checking if move buttons are pressed
        IsWalking();
    }

    private void FixedUpdate() //fixedupdate for physics
    {
        Vector3 movement = new Vector3(_moveDir.x * moveSpeed, 0, _moveDir.z * moveSpeed);
        movement.y = rb.linearVelocity.y; //setting the y so that the gravity stays normal and does not multiply
        rb.linearVelocity = movement; //update linear velocity
        
        //camera movement
        Vector3 cameraMove = new Vector3(_moveDir.x,0, _moveDir.z);
        cameraMove = cameraMainTransform.forward * cameraMove.z + cameraMainTransform.right * cameraMove.x;
        cameraMove.y = 0;

        if (_moveDir != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(_moveDir.x,_moveDir.z) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f,targetAngle,0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }


    //Jump event that is being called
    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && _isGrounded == true) //will only trigger if player hits the jump button and if player is on the ground
        {
            Debug.Log("Jumped!");
            AudioManager.Instance.PlaySFX("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision objectCollidedWith) //check if player is on the ground
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

    private void IsWalking()
    {
        if (_moveDir.x > 0 || _moveDir.x < 0 || _moveDir.z > 0 || _moveDir.z < 0)
            _animator.SetBool("IsWalking", true);
        else if (_moveDir.x == 0 || _moveDir.x == 0 || _moveDir.z == 0 || _moveDir.z == 0)
            _animator.SetBool("IsWalking", false);
    }

}
