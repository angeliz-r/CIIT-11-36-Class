using UnityEngine;

public class SnakeMovingState : StateMachineBehaviour
{
    private float _timer;
    private float _speed;
    public Rigidbody2D snakeRB;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0;
        _speed = 10;
        snakeRB = animator.GetComponent<Rigidbody2D>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer += Time.deltaTime;
        if (_timer > 10)
        {
            animator.SetBool("IsMoving", false);
        }
        //move the character
        Vector2 movementDirection = new Vector2(Random.Range(0,3), 0).normalized;
        snakeRB.MovePosition(snakeRB.position + movementDirection * _speed * Time.deltaTime);
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
