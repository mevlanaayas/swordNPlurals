using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    // private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        // _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
}