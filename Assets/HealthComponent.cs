using System;
using System.Collections;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    public float invincibilityTime = 2f;
    private bool canReciveDamage = true;

    private int currentHealth;
    
    public delegate void HealthChangedHandler(int oldHealth, int amountChanged);
    public event HealthChangedHandler OnHealthChanged;

    public delegate void HealthInitHandler
    public event HealthInitHandler
    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void ReceiveDamage(int amount, Vector3 origin)
    {
        if (canReciveDamage)
        {
            OnHealthChanged?.Invoke(currentHealth, amount);
            canReciveDamage = false;
            StartCoroutine(RunInvincibilityTimer(invincibilityTime, RefreshInvincibility));
            currentHealth -= amount;
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
        Debug.Log("Reset");
    }
}
