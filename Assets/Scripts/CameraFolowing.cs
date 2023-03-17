using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolowing : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _distance;

    private Vector3 _nextPosition;

    private void Start()
    {
        Quaternion target = Quaternion.Euler(30, 0, 0);
        transform.rotation = target;
    }

    private void FixedUpdate()
    {
        _nextPosition = _player.transform.position + _distance;
        transform.position = Vector3.Lerp(transform.position, _nextPosition, _speed * Time.fixedDeltaTime);
    }
}
