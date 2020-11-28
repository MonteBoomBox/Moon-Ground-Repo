using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damageUnit = 10;

    private float GValue;
    private float BValue;

    public float regenTime = 0.2f;
    private bool isDead = false;

    public SpriteRenderer ObjRenderer;
    Color defaultColor;

    private bool isHit = false;

    public HealthBar healthBar;
    public GameObject HealthDisplay;
    TextMeshProUGUI CurrentHealthDisplay;

    public ParticleSystem HitEffect;

    void Start()
    {
        currentHealth = maxHealth;
        defaultColor = ObjRenderer.color;
        healthBar.SetMaxHealth(maxHealth);
        CurrentHealthDisplay = HealthDisplay.GetComponent<TextMeshProUGUI>();
    }

    public void OnCollisionEnter2D(Collision2D Hit)
    {
        //if (Hit.gameObject.CompareTag("Bullet"))
        //{
        //    if (!isHit)
        //    {
        //        isHit = true;
        //        TakeDamage(damageUnit);
        //    }
        //}

        //else if (Hit.gameObject.CompareTag("EnemyBullet"))
        //{
        //    if (!isHit)
        //    {
        //        isHit = true;
        //        TakeDamage(damageUnit);
        //    }
        //}
    }

    public void TakeDamage(int damage)
    {
        ParticleSystem hit = Instantiate(HitEffect, transform.position, Quaternion.identity);
        hit.Play();
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Update()
    {
        if (!isDead)
        {
            if (currentHealth <= 0)
            {
                isDead = true; 
                KillPlayer();
            }
        }

        //if (Input.GetKeyDown(KeyCode.Backspace)) // Debug Key for Testing Damage Function
        //{
        //    TakeDamage(10);
        //}

        CurrentHealthDisplay.text = currentHealth.ToString();

        
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isDead = false;
    }

    //public void ShowDamage()
    //{
    //     Color damageColor = ObjRenderer.color;
    //     damageColor = new Color(1f, 0f, 0f, 1f);
    //}

    //public void UnshowDamage()
    //{
    //     Color regenColor = ObjRenderer.color;
    //     regenColor = new Color(1f, 1f, 1f, 1f);
    //}

    IEnumerator SwitchColor()
    {
        ObjRenderer.color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(regenTime);
        ObjRenderer.color = defaultColor;
        isHit = false;
    }
}
