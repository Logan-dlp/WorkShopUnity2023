using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private NavigationController _player;

    private void LateUpdate()
    {
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        transform.position = new Vector3(_player.transform.position.x, 
            transform.position.y, 
            _player.transform.position.z);
    }
}
