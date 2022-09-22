// Botirov U. Специально для SAB Games.
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour // Этот класс обрабатывает нанесенный урон и количество жизни сущности.
{
    //========================
    [SerializeField] private int health = 100;
    //========================
    [SerializeField] private GameObject body;
    //========================
    public delegate void OnEntityDeath();
    public OnEntityDeath onEntityDeath;
    public UnityEvent OnDeath;
    //========================
    
    
    //=========================================================
    // Получаем урон.
    public void TakeDamage(int damage)
    {
        health -= damage;
        ChekHealth();
    }
    //=========================================================
    // Проверяем количество жизни.
    private void ChekHealth()
    {
        if (health <= 0)
        {
            OnDeath?.Invoke();
            onEntityDeath?.Invoke();
            
            Destroy(body);
            
            Destroy(gameObject, 4f);
        }
    }
    //=========================================================
}
