using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class Health : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public float health;
    public float maxHealth;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        float roundedHealth = (float)Math.Round(health, 1);
        healthText.text = "Health: " + roundedHealth;

        if (Input.GetMouseButtonDown(2))
            TakeDamage(12.555f);
    }
    public void TakeDamage(float damage)
    {
        if (health > 0)
            health -= damage;
        if (health < 0)
            health = 0;
    }
}
