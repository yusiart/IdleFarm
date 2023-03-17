using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlantFinder : MonoBehaviour
{
    private List<Plant> _plants;
    
    public List<Plant> Plants => _plants;
    
    public event UnityAction<int> PlantsCountChanged;

    private void Start()
    {
        _plants = new List<Plant>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Plant plant))
        {
            _plants.Add(plant);
            plant.OnPlantDied += OnPlantDied;
            PlantsCountChanged?.Invoke(_plants.Count);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Plant plant))
        {
            _plants.Remove(plant);
            PlantsCountChanged?.Invoke(_plants.Count);
        }
    }
    
    private void OnPlantDied(Plant plant)
    {
        _plants.Remove(plant);
        PlantsCountChanged?.Invoke(_plants.Count);
        plant.OnPlantDied -= OnPlantDied;
    }
}
