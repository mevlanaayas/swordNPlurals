using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NpcController : MonoBehaviour
{
    public float patrolTime = 10f;
    public float aggroRange = 10f;
    public Transform[] wayPoints;

    private int _index;
    private float _speed, _agentSpeed;
    private Transform _player;

    // private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        // _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (_navMeshAgent != null)
        {
            _agentSpeed = _navMeshAgent.speed;
        }

        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _index = Random.Range(0, wayPoints.Length);

        InvokeRepeating(nameof(Tick), 0, 0.5f);
        if (wayPoints.Length > 0)
        {
            InvokeRepeating(nameof(Patrol), 0, patrolTime);
        }
    }

    private void Patrol()
    {
        _index = _index == wayPoints.Length - 1 ? 0 : _index + 1;
    }

    private void Tick()
    {
        _navMeshAgent.destination = wayPoints[_index].position;
        _navMeshAgent.speed = _agentSpeed / 2;

        if (_player == null || Vector3.Distance(transform.position, _player.position) > aggroRange) return;
        _navMeshAgent.destination = _player.position;
        _navMeshAgent.speed = _agentSpeed;
    }
}