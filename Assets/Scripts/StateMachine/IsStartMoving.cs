using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsStartMoving : Transition
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Animator.SetBool("IsMow", false);
            Animator.SetBool("IsWalking", true);
            NeedTransit = true;
        }
    }
}
