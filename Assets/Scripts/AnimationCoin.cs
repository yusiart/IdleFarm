using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimationCoin : MonoBehaviour
{
   public void Move(Transform target)
   {
      transform.DOMove(target.position, 0.5f);
      Destroy(gameObject, 0.51f);
   }
}
