using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlantStawner : MonoBehaviour
{
    [SerializeField] private Plant _plantPrefab;
    [SerializeField] private float _timeToSpawn;
    
    private MeshCollider _planeCollider;
    private int _maxPlantsCount = 20;
    private float _x, _z;
    
    private Vector3 _spawnPoint;
    private Vector3 _sizeCol = new Vector3(0.5f, 0f, 0.5f);
    private Vector3 _centerCol = new Vector3(0f, 0.5f, 0f);
    
    private Collider [] _colliders;
    private bool _check;
    private float _timer;
    private int _plantsCount;
    
    
    private void Start()
    {
        _planeCollider = GetComponent<MeshCollider>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _timeToSpawn && _plantsCount < _maxPlantsCount)
        {
            StartPosition();
            _timer = 0;
        }
    }

    private void StartPosition()
    {
        _x = Random.Range(_planeCollider.transform.position.x - Random.Range(0, _planeCollider.bounds.extents.x),
            _planeCollider.transform.position.x + Random.Range(0, _planeCollider.bounds.extents.x));
        _z = Random.Range(_planeCollider.transform.position.z - Random.Range(0, _planeCollider.bounds.extents.z),
            _planeCollider.transform.position.z + Random.Range(0, _planeCollider.bounds.extents.z));

        _spawnPoint = new Vector3(_x, 0f, _z);

        _check = CheckSpawnPoint(_spawnPoint);

        if (_check)
        {
            Plant plant = Instantiate(_plantPrefab, _spawnPoint, Quaternion.identity);
            plant.OnPlantDied += OnPlantDied;
            _plantsCount++;
        }
        else
        {
            StartPosition();
        }
    }

    private bool CheckSpawnPoint(Vector3 spawnPoint)
    {
        _colliders = Physics.OverlapBox(spawnPoint, _sizeCol);
        if (_colliders.Length > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    private void OnPlantDied(Plant plant)
    {
        plant.OnPlantDied -= OnPlantDied;
        _plantsCount--;
    }
}
