using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Barn : MonoBehaviour
{
    private int _cornPrice = 4;
    
    public event UnityAction<int> OnCornAdded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out CornRoll corn))
        {
            OnCornAdded?.Invoke(_cornPrice);
        }
    }
}
