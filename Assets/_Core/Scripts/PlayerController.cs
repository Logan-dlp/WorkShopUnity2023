using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _mousePosition;
    private Vector3 _targetPosition;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (_targetPosition == null)
        {
            _targetPosition = transform.position;
        }
    }

    private void Update()
    {
        SetTargetPosition();
        _navMeshAgent.SetDestination(_targetPosition);
    }

    void SetTargetPosition()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit,  1000))
            {
                if (hit.collider.gameObject.TryGetComponent(out NavMeshSurface floorMeshSurface))
                {
                    _targetPosition = hit.point;
                    Debug.Log(_targetPosition);
                }
            }
        }
    }
}
