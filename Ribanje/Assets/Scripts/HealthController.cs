using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class HealthController : MonoBehaviour
{
    private const int HEALTH_CAP = 10;

    public int currentHealth;
    public int maxHealth;
    public Image[] hearts;
    public Sprite heart;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++) {
            if (i < maxHealth)
            {
                hearts[i].enabled = true;  
            }
            else
            {
                hearts[i].enabled = false;
            }


            var heartColor = hearts[i].color;
            if (i < currentHealth)
            {

                heartColor.a = 1f;
            }
            else
            {
                heartColor.a = 0.3f;
            }

            hearts[i].color = heartColor;

        }
    }

    public void addHearts(int amount)
    {
        if (currentHealth < maxHealth) currentHealth += amount;
    }

    public void deductHearts(int amount)
    {
        if (currentHealth > 0) currentHealth -= amount;
    }
    public void addMaxHearts(int amount)
    {
        maxHealth = math.min(HEALTH_CAP, maxHealth + amount);
        currentHealth = math.min(HEALTH_CAP, currentHealth + amount);
    }

    public void deductMaxHearts(int amount)
    {
        maxHealth = math.max(1, maxHealth - amount);
        currentHealth = math.min(maxHealth, currentHealth);
    }
    
}

