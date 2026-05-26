using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    private bool canReciveDamage = true;
    public float invincibilityTime = 2f;

    public delegate void HealthChangedHandler(float oldHealth, float amountChanged);
    public event HealthChangedHandler OnHealthChanged;

    public delegate void HealthInitialisedHandler(float newHealth);
    public event HealthInitialisedHandler OnHealthInitialised;
    private void Start()
    {
        currentHealth = maxHealth;
        OnHealthInitialised?.Invoke(currentHealth);
    }
   
    public void ReceiveDamage(float amount, Vector3 origin)
    {
        if (canReciveDamage)
        {
            currentHealth -= amount;
            OnHealthChanged?.Invoke(currentHealth, amount);
            canReciveDamage = false;
            StartCoroutine(RunInvincibilityTimer(invincibilityTime, RefreshInvincibility));
            
        }

        {
            if(currentHealth <= 0)
            {
                SceneManager.LoadScene("RIP");
            }
        }
    }

    IEnumerator RunInvincibilityTimer(float waitTime, Action callback)
    {
        yield return new WaitForSeconds(waitTime);
        callback.Invoke();
    }

    private void RefreshInvincibility()
    {
        canReciveDamage = true;

    }
    

    public void AddHealth(float healthToAdd)
    {
        currentHealth += healthToAdd;
        OnHealthChanged?.Invoke(currentHealth, healthToAdd);
    }
}
