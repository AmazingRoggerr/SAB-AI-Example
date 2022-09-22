// Botirov U. Специально для SAB Games.
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
// Этот класс менеджера звука "ограничивает количество одновременно воспроизводимых звуковых эффектов"
// Дело в том что Unity не фильтрует порядок проигрование звуков и если этого не делать,
// звуки будут смещоваться и звучат это будет мягко говоря не круто.
{
    //========================
    [SerializeField] private AudioClip[] hitSounds;
    [SerializeField] private AudioClip footStep;
    
    private AudioSource audioSource;
    //========================
    private bool hitCooldown;
    private bool footStepCooldown;
    //========================
    
    
    //=========================================================
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    //=========================================================
    public void PlayFootStepSound()
    {
        if (footStepCooldown == false)
        {
            StartCoroutine(FootStepCoroutine(footStep));
        }
    }
    private IEnumerator FootStepCoroutine(AudioClip audioClip)
    {
        footStepCooldown = true;
        PlaySound(audioClip);
        
        yield return new WaitForSeconds(audioClip.length);
        footStepCooldown = false;
    }
    //=========================================================
    public void PlayHitSound()
    {
        if (hitCooldown == false)
        {
            int random = Random.Range(0, hitSounds.Length);
            StartCoroutine(HitCoroutine(hitSounds[random]));
        }
    }
    private IEnumerator HitCoroutine(AudioClip audioClip)
    {
        hitCooldown = true;
        PlaySound(audioClip);
        
        yield return new WaitForSeconds(audioClip.length);
        hitCooldown = false;
    }
    //=========================================================
    private void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip, audioSource.volume);
    }
    //=========================================================
}