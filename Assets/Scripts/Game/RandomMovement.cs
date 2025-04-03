using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    public float range;
    public Transform center;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(center.position, range, out point))
            {
                //Debug.DrawRay(point, Vector3.up, Color.red, 1.0f);
                _agent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            _animator.SetBool("IsMoving", true);
            return true;
        }
        result = Vector3.zero;
        _animator.SetBool("IsMoving", false);
        return false;
    }
}
