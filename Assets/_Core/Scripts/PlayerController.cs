using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    private Camera _mainCamera;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _mousePosition;
    private Vector3 _targetPosition;

    private void Start()
    {
        _mainCamera = Camera.main;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (_targetPosition == null)
        {
            _targetPosition = transform.position;
        }
    }

    private void Update()
    {
        UpdateCameraPosition();
        SetTargetPosition();
        _navMeshAgent.SetDestination(_targetPosition);
    }

    void SetTargetPosition()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit,  1000))
            {
                if (hit.collider.gameObject.TryGetComponent(out NavMeshSurface floorMeshSurface))
                {
                    _targetPosition = hit.point;
                }
            }
        }
    }

    void UpdateCameraPosition()
    {
        _mainCamera.transform.position = new Vector3(transform.position.x, 
            _mainCamera.transform.position.y, 
            transform.position.z);
    }
}
