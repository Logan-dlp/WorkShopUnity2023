using System;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(PlayerPhysics))]
public class NavigationController : MonoBehaviour
{
    private Camera _mainCamera;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _mousePosition;

    private void Start()
    {
        _mainCamera = Camera.main;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        SetTargetPosition();
    }

    void SetTargetPosition()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit,  Single.PositiveInfinity))
            {
                if (hit.collider.gameObject.TryGetComponent(out NavMeshSurface floorMeshSurface))
                {
                    _navMeshAgent.SetDestination(hit.point);
                }
            }
        }
    }
}
