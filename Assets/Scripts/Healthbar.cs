using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthbarSprite;

    private float maxHealth;

    public void InitializeHealthBar(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void UpdateHealthBar(float currentHealth)
    {
        healthbarSprite.fillAmount = currentHealth / maxHealth;
    }
}
