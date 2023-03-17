using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public bool NeedTransit { get; protected set; }
    protected Rigidbody Rigidbody { get; private set; }
    protected Animator Animator { get; private set; }
    public State TargetState => _targetState;

    public void Init(Rigidbody rigidbody, Animator animator)
    {
        Rigidbody = rigidbody;
        Animator = animator;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
