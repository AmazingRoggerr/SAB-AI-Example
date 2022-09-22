// Botirov U. Специально для SAB Games.
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvents : MonoBehaviour // Этот класс обрабатывает события в анимационных клипах.
{
    //========================
    public UnityEvent OnAttackEnter;
    public UnityEvent OnAttackExit;
    public UnityEvent OnFootSteps;
    //========================
    
    //=========================================================
    public void AttackEnter()
    {
        OnAttackEnter?.Invoke();
    }
    public void AttackExit()
    {
        OnAttackExit?.Invoke();
    }
    //=========================================================
    public void FootSteps()
    {
        OnFootSteps?.Invoke();
    }
    //=========================================================
}
