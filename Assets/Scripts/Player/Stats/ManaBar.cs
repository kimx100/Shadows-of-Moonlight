using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider manaBar;

    public Mana manaComponent;  
    private void Update()
    {
        manaBar.maxValue = manaComponent.maxMana;
        manaBar.value = manaComponent.mana;
    }
}
