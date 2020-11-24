using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float regenTime;

    public int maxHealth;
    public int currentHealth;

    public int damageUnit;

    private bool isHit = false;
    private bool isDead = false;

    public SpriteRenderer ObjRenderer;
    Color defaultColor;

    public ParticleSystem Hit;


    void Start()
    {
        currentHealth = maxHealth;
        defaultColor = ObjRenderer.color;
    }

    public void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Bullet"))
        {
            if (!isHit)
            {                
                isHit = true;
                StartCoroutine("SwitchColor");
                TakeDamage(damageUnit);
            }            
        }

        else if (hitInfo.gameObject.CompareTag("EnemyBullet"))
        {
            if (!isHit)
            {
                isHit = true;
                StartCoroutine("SwitchColor");
                TakeDamage(damageUnit);
            }
        }
    }

    public void PlayHitEffect()
    {
        FindObjectOfType<AudioManager>().PlaySound("ReflectorClank");
        ParticleSystem hit = Instantiate(Hit, transform.position, Quaternion.identity);
        hit.Play();
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            if (!isDead)
            {
                isDead = true;
                Die();
            }            
        }
    }

    public void TakeDamage(int damage)
    {
        PlayHitEffect();
        currentHealth -= damage;
    }

    public void Die()
    {
        Debug.Log("Enemy Killed");
        Destroy(gameObject);
    }

    IEnumerator SwitchColor()
    {
        ObjRenderer.color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(regenTime);
        ObjRenderer.color = defaultColor;
        isHit = false;
    }
}
