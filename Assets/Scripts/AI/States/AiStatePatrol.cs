// Botirov U. Специально для SAB Games.
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AiStatePatrol : MonoBehaviour // Этот класс моделирует "состояния патрулирование" ИИ.
{
    //========================
    [Tooltip("Путевые точки по которым будет бегать Агент и искать врага")]
    [SerializeField] private Transform[] wayPoints;
    //========================
    [Tooltip("Время между патрулированием путевых точек")]
    [SerializeField] private float timeBetweenPoints = 1.5f;
    //========================
    
    //========================
    // Рандомная цифра для сравнения и выбора путевых точек.
    private int randomPoint;
    //========================
    // Время для ожидание перед прохождением новой путевой точки.
    private float waitTime;
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
    private void Start()
    {
        waitTime = timeBetweenPoints;
        randomPoint = Random.Range(0, wayPoints.Length);
    }
    //=========================================================
    /// <summary>
    /// Рандомное патрулирование ИИ по путевым точкам.
    /// </summary>
    public void Patrolling()
    {
        // Устанавливаем путевую точку и отправляем агента.
        agent.SetDestination(wayPoints[randomPoint].position);
        
        // Если агент достигнул точку пути, то мы ждем "N"ное количество секунд и меняем путь.
        if (Vector3.Distance(transform.position, wayPoints[randomPoint].position) < 2.0f)
        {
            if(waitTime <= 0)
            {
                randomPoint = Random.Range(0, wayPoints.Length);
                waitTime = timeBetweenPoints;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
        // При патрулировании "управление поворотом" возвращаем агенту.
        agent.updateRotation = true;
    }
    //=========================================================
}