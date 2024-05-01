using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;

    public Health healthComponent;
    private void Update()
    {
        healthBar.maxValue = healthComponent.maxHealth;
        healthBar.value = healthComponent.health;
    }
}
