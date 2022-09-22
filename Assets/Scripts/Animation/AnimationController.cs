// Botirov U. Специально для SAB Games.
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AnimationController : MonoBehaviour // Этот класс обрабатывает "анимации" ИИ.
{
    //========================
    private Animator animator;
    private readonly int speed = Animator.StringToHash("Speed");
    private readonly int attack = Animator.StringToHash("Attack");
    private readonly int attackIndex = Animator.StringToHash("AttackIndex");
    private readonly int death = Animator.StringToHash("Death");
    //========================
    private NavMeshAgent agent;
    //========================
    private AiStateAttack attackState;
    //========================
    private Health health;
    //========================
    
    
    //=========================================================
    // Получаем необходимых компонентов.
    private void Awake()
    {
        animator = GetComponent<Animator>();
        
        agent = GetComponentInParent<NavMeshAgent>();
        attackState = GetComponentInParent<AiStateAttack>();
        health = GetComponentInParent<Health>();
    }
    //=========================================================
    // Регистрируем событие атаки и смерти
    private void OnEnable()
    {
        attackState.onAttack += AttackAnimation;
        health.onEntityDeath += DeathAnimation;
    }
    private void OnDisable()
    {
        attackState.onAttack -= AttackAnimation;
        health.onEntityDeath -= DeathAnimation;
    }
    //=========================================================
    // Устанавливаем и обновляем параметры аниматора.
    private void Update()
    {
        animator.SetFloat(speed, agent.velocity.sqrMagnitude > 2f ? 1f : 0f);
    }
    //=========================================================
    private void AttackAnimation()
    {
        animator.SetTrigger(attack);
        animator.SetInteger(attackIndex, Random.Range(0, 2));
    }
    //=========================================================
    private void DeathAnimation()
    {
        animator.SetBool(death,true);
    }
    //=========================================================
}
