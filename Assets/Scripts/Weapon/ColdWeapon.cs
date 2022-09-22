// Botirov U. Специально для SAB Games.
using UnityEngine;

public class ColdWeapon : MonoBehaviour // Этот класс обрабатывает столкновение оружия с телом врага и вызывает соответствующие события
{
    //========================
    [SerializeField] private string targetTag;
    //========================
    public delegate void OnWeaponHit(GameObject target);
    public OnWeaponHit onWeaponHit;
    //========================
    
    
    //=========================================================
    // Если оружие коснулся врага мы сообщим об этом его владельцу.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            onWeaponHit?.Invoke(other.gameObject);
        }
    }
    //=========================================================
}
