using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent _agent;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = target.position;
    }
}