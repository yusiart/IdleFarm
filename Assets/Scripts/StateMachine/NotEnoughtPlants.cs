using UnityEngine;

public class NotEnoughtPlants : Transition
{
    [SerializeField] private PlantFinder _plantFinder;
    
    private void OnEnable()
    {
        NeedTransit = false;
        _plantFinder.PlantsCountChanged += OnPlantsCountChanged;
    }
    
    private void OnDisable()
    {
        _plantFinder.PlantsCountChanged -= OnPlantsCountChanged;
    }
    
    private void OnPlantsCountChanged(int count)
    {
        if (count <= 0)
        {
            NeedTransit = true;
        }
    }
}
