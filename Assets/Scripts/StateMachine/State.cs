using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;
    protected Animator Animator { get; private set; }
    protected  Rigidbody Rigidbody { get; private set; }

    public void Exit()
    {
        if (enabled)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public void Enter(Animator animator, Rigidbody rigidbody)
    {
        if (enabled == false)
        {
            Animator = animator;
            Rigidbody = rigidbody;
            enabled = true;
            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Rigidbody, Animator);
            }
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}
