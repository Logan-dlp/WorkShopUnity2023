using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshSurface))]
public class RandomSpawnItems : MonoBehaviour
{
    [SerializeField] private GameObject _objectSpawned;
    [SerializeField] private float _timelineMin = 0;
    [SerializeField] private float _timelineMax = 5;
    
    private NavMeshSurface _navMeshSurface;
    private NavMeshData _navMeshData;
    private Vector3 _randomPosition;

    private void Start()
    {
        _navMeshSurface = GetComponent<NavMeshSurface>();
        _navMeshData = _navMeshSurface.navMeshData;

        StartCoroutine(SpawnObjectCoroutine());
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_randomPosition, 1);
        }
    }

    private Vector3 SetRandomPosition(Bounds bounds)
    {
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        
        if (Physics.Raycast(new Vector3(x, 100, z), Vector3.down, out RaycastHit hit, 1000))
        {
            if (hit.collider.TryGetComponent(out NavMeshObstacle navMeshObstacle))
            {
                return SetRandomPosition(bounds);
            }
        }
        
        return new Vector3(x, transform.position.y + .2f, z);
    }

    IEnumerator SpawnObjectCoroutine()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(Random.Range(_timelineMin, _timelineMax));
            _randomPosition = SetRandomPosition(_navMeshData.sourceBounds);
            Instantiate(_objectSpawned, _randomPosition, Quaternion.Euler(Quaternion.identity.x, Random.Range(0, 359), Quaternion.identity.z));
        }
    }
}
