// Botirov U. Специально для SAB Games.
using UnityEngine;
using UnityEngine.AI;

public class AiStateChase : MonoBehaviour // Этот класс моделирует "состояния погони" ИИ за его врагом.
{
    //========================
    [Tooltip("Скорость поворота агента после достижения цели")]
    [SerializeField] private float lookAtSpeed = 10f;
    //========================
    
    //========================
    // Это мой компонент Навигационного агента.
    private NavMeshAgent agent;
    //========================
    
    
    //=========================================================
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    //=========================================================
    /// <summary>
    /// Преследует указаний цель.
    /// </summary>
    /// <param name="target">Цель на которого будет идти преследование</param>
    public bool ChaseTarget(Transform target)
    {
        // Идти к цели.
        agent.SetDestination(target.transform.position);
        
        // Это нужно чтобы агенты правильно смотрели друг на друга, так-как компонент NavMeshAgent не обновляет поворот после достижения цели
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            agent.updateRotation = false;
            
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookAtSpeed);
        }
        else
        {
            agent.updateRotation = true;
        }

        float distance = Vector3.Distance(transform.position, target.position);
        
        bool goalReached = distance < 1.5f;
        
        return goalReached;
    }
    //=========================================================
}