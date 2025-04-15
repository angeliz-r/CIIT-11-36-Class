using System.Runtime.CompilerServices;
using UnityEngine;

public class SnakeMovingState : StateMachineBehaviour
{
    private float _timeLimit;
    [SerializeField] private float _distance;
    private float _timer;
    [SerializeField] private float _speed;
    private bool _isRight;
    private Vector2 _moveDir;
    private Rigidbody2D _snakeRB;
    private SpriteRenderer _snakeSprite;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0;
        _speed = Random.Range(5, 8); //randomize speed
        _timeLimit = Random.Range(2, 5); //randomize time limit
        _isRight = true;
        _snakeRB = animator.GetComponent<Rigidbody2D>();
        _snakeSprite = animator.GetComponent<SpriteRenderer>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer += Time.deltaTime;
        if (_timer > _timeLimit)
        {
            animator.SetBool("IsMoving", false);
            _isRight = !_isRight;
        }
        if (_isRight)
        {
            _moveDir = new Vector2(_distance, 0).normalized;
            _snakeSprite.flipX = true;
        }
        else if (!_isRight)
        {
            _distance = -(_distance);
            _moveDir = new Vector2(_distance, 0).normalized;
            _snakeSprite.flipX = false;
        }
        _snakeRB.MovePosition(_snakeRB.position + _moveDir * _speed * Time.deltaTime);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
