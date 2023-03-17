using UnityEngine;

public class CornBagSeller : MonoBehaviour
{
    [SerializeField] private float _timeToSell;
    [SerializeField] private ContainerBag _containerBag;
    
    private float _timer;

    private void OnTriggerStay(Collider other)
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeToSell)
        {
            if (other.TryGetComponent(out Barn barn))
            {
                _containerBag.RemoveCornBag(barn.transform);
                _timer = 0;
            }
        }
    }
}
