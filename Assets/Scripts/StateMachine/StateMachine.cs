using UnityEngine;

[RequireComponent(typeof(Mow), typeof(PlayerControl))]
[RequireComponent(typeof(NotEnoughtPlants),typeof(IsPlantClose), typeof(IsStartMoving))]
public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;
    private Animator _animator;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        Reset(_firstState);
    }

    private void Update()
    {
        if(_currentState == null)
            return;

        var nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
        {
            _currentState.Enter(_animator, _rigidbody);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_animator, _rigidbody);
        }
    }
}
