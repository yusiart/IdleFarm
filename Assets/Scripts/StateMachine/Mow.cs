
using System;
using UnityEngine;

public class Mow : State
{
    [SerializeField] private GameObject _mover;

    private Collider _moverCollider;

    private void Awake()
    {
        _moverCollider = _mover.GetComponent<Collider>();
    }

    private void OnEnable()
    {
        _mover.SetActive(true);
        Animator.SetBool("IsWalking", false);
        Animator.SetBool("IsMow", true);
    }

    private void OnDisable()
    {
        _mover.SetActive(false);
        Animator.SetBool("IsMow", false);
        DeactivateMowerCollider();
    }
    
    public void ActivateMowerCollider()
    {
        _moverCollider.enabled = true;
    }
    
    public void DeactivateMowerCollider()
    {
        _moverCollider.enabled = false;
    }
}
