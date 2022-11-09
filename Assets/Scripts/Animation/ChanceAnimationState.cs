using UnityEngine;

public sealed class ChanceAnimationState : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private string _currentState = string.Empty;

    public void HandlerChangeAnimationState(string NewState)
    {
        if(_currentState == NewState)
        {
            return;
        }

        if(_animator != null)
        {
            _animator.Play(NewState);
        }
      
        _currentState = NewState;
    } 
}