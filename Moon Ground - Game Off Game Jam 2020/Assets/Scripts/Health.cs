using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        currentHealth = maxHealth;
        defaultColor = ObjRenderer.color;
    }

    public void OnCollisionEnter2D(Collision2D Hit)
    {
        if (Hit.gameObject.CompareTag("Bullet"))
        {
            if (!isHit)
            {
                isHit = true;
                StartCoroutine(SwitchColor());
                TakeDamage(damageUnit);
            }
        }

        else if (Hit.gameObject.CompareTag("EnemyBullet"))
        {
            if (!isHit)
            {
                isHit = true;
                StartCoroutine(SwitchColor());
                TakeDamage(damageUnit);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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

        
    }

    public void KillPlayer()
    {
        Debug.Log("YOU DIED!");
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
