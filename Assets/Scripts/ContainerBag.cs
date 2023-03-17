using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContainerBag : MonoBehaviour
{
    [SerializeField] private float _padding;
    
    private Stack<CornRoll> _cornBags;
    private Vector3 _currentPadding;
    private float _height = 0.2f;
    private int _maxCount = 40;
    
    public event UnityAction<int,int> OnCountChanged; 

    private void Start()
    {
        _cornBags = new Stack<CornRoll>();
        _currentPadding = transform.position;
        OnCountChanged?.Invoke(_cornBags.Count, _maxCount);
    }

    public bool AddCornBag(CornRoll cornBag)
    {
        if (_cornBags.Count + 1 > _maxCount)
          return false;
        
        _cornBags.Push(cornBag);
        _currentPadding += new Vector3(0, cornBag.transform.localScale.y + _padding, 0);
        cornBag.TargetHeight = _currentPadding;
        OnCountChanged?.Invoke(_cornBags.Count, _maxCount);
        return true;
    }

    public void RemoveCornBag(Transform target)
    {
        if (_cornBags.Count == 0)
            return;

        _cornBags.Pop().Drop(target.transform.position);
        _currentPadding -= new Vector3(0, _height + _padding, 0);
        OnCountChanged?.Invoke(_cornBags.Count, _maxCount);
    }
}
