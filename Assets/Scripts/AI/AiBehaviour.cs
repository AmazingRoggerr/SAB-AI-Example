// Botirov U. Специально для SAB Games.
using UnityEngine;

public class AiBehaviour : MonoBehaviour // Этот класс моделирует поведение ИИ.
{
    //========================
    [Header("Detection Properties")]
    //========================
    [Tooltip("Тег врага")]
    [SerializeField] private string targetTag;
    //========================
    [Tooltip("Радиус обнаружения врага")]
    public float detectRadius = 10f;
    //========================
    [Tooltip("Система частиц для визуального отображения радиуса обнаружения")]
    [SerializeField] private ParticleSystem radiusVisual;
    //========================

    //========================
    [Header("Entity States")]
    //========================
    [Tooltip("Этот компонент моделирует 'состояния патрулирование' ИИ.")]
    [SerializeField] private AiStatePatrol patrolState;
    //========================
    [Tooltip("Этот компонент моделирует 'состояния погони' ИИ.")]
    [SerializeField] private AiStateChase chaseState;
    //========================
    [Tooltip("Этот компонент моделирует 'состояния атаки' ИИ.")]
    [SerializeField] private AiStateAttack attackState;
    //========================

    //========================
    [Header("Текущая цель.")]
    [Tooltip("Просто для отладки.")]
    [SerializeField] private Transform currentTarget;
    //========================
    
    
    //=========================================================
    private void Awake()
    {
        gameObject.GetComponent<SphereCollider>().radius = detectRadius;
    }
    //=========================================================
    private void Update()
    {
        // Определяем мейн модуль систему частиц
        var mainModule = radiusVisual.main;
        
        // Если есть цель, мы его приследуем.
        if (currentTarget != null)
        {
            if (chaseState.ChaseTarget(currentTarget))
            {
                attackState.Attack();
            }
            mainModule.startColor = new Color(1, 0, 0, 0.05f);
        }
        // Иначе продолжаем патрулировать.
        else
        {
            patrolState.Patrolling();
            mainModule.startColor = new Color(1, 1, 1, 0.05f);
        }
    }
    //=========================================================
    // При обнаружение новой цели устанавливает его как "Текущий"
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(targetTag) && currentTarget == null)
        {
            currentTarget = other.transform;
        }
    }
    // Если цель покидает радиус обнаружения то мы его обнуляем "цель = нет"
    private void OnTriggerExit(Collider other)
    {
        if (other.transform == currentTarget)
        {
            currentTarget = null;
        }
    }
    //=========================================================
}