// Botirov U. Специально для SAB Games.
using System.Collections;
using UnityEngine;

public class AiStateAttack : MonoBehaviour // Этот класс моделирует 'состояния атаки' ИИ.
{
    //========================
    [Tooltip("Скорость атаки в секундах.")]
    [SerializeField] private float attackSpeed = 1.5f;
    //========================
    [Tooltip("Сумма наносимого урона.")]
    [SerializeField] private int damage = 20;
    //========================
    // Делегат для атаки "на всякий случай" например пока что регистрируется в AnimationController.cs.
    public delegate void OnAttack();
    public OnAttack onAttack;
    //========================
    // Холодное оружия
    private ColdWeapon weapon;
    //========================
    // Для перезарядки
    private bool isCooldown;
    //========================
    
    
    //=========================================================
    private void Awake()
    {
        weapon = GetComponentInChildren<ColdWeapon>();
    }
    //=========================================================
    // Регистрируем события оружия.
    // Это вызывается когда оружие ударяет врага.
    private void OnEnable()
    {
        weapon.onWeaponHit += ApplyDamage;
    }
    private void OnDisable()
    {
        weapon.onWeaponHit -= ApplyDamage;
    }
    //=========================================================
    // Атакуем
    public void Attack()
    {
        if (!isCooldown)
        {
            onAttack?.Invoke();
            StartCoroutine(CooldownCoroutine());
        }
    }
    //=========================================================
    // Наносим урон
    private void ApplyDamage(GameObject target)
    {
        target.GetComponentInParent<Health>().TakeDamage(damage);
    }
    //=========================================================
    private IEnumerator CooldownCoroutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(attackSpeed);
        isCooldown = false;
    }
    //=========================================================
}
