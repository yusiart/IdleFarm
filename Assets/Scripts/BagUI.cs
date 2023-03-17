using TMPro;
using UnityEngine;

public class BagUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _bagCount;
    [SerializeField] private ContainerBag _containerBag;

    private void OnEnable()
    {
        _containerBag.OnCountChanged += OnCountChanged;
    }

    private void OnDisable()
    {
        _containerBag.OnCountChanged -= OnCountChanged;
    }
    
    private void OnCountChanged(int count, int maxCount)
    {
        _bagCount.text = count + " / " + maxCount;
    }
}
