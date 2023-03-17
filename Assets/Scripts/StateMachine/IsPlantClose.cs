using UnityEngine;

public class IsPlantClose : Transition
{
    [SerializeField] private PlantFinder _plantFinder;

    private float _timer;
    
    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (Rigidbody.velocity == Vector3.zero && _timer > 0.5f)
        {
            CheckIsPlantClose();
            _timer = 0;
        }
    }

    private void CheckIsPlantClose()
    {
        if (_plantFinder.Plants.Count <= 0)
            return;

        foreach (var plant in _plantFinder.Plants)
        {
            if (plant.GetComponent<PlantGrowth>().IsGrow)
            {
                NeedTransit = true;
            }
        }
    }
}
