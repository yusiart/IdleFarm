using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
   [SerializeField] private float _speed;
   
   private float _growthSpeed = 0.1f;
   private float _maxSize = 1f;
   private float _timeToGrowth = 1f;
   private float _timer;
   private bool _isGrowth;
   private Vector3 _targetScale;
   
   public bool IsGrow => _isGrowth;

   private void Start()
   {
      _targetScale = transform.localScale;
   }

   private void Update()
   {
      _timer += Time.deltaTime;
      transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, Time.deltaTime * _speed);

      if (_timer > _timeToGrowth && transform.localScale.x < _maxSize)
      {
         _timer = 0;
         Grow();
      }
      else if(transform.localScale.x >= _maxSize)
      {
         _isGrowth = true;
      }
   }
   
   private void Grow()
   {
      _targetScale = new Vector3(transform.localScale.x + _growthSpeed, transform.localScale.y + _growthSpeed, transform.localScale.z + _growthSpeed);
   }
}
