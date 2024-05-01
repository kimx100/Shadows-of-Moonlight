using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class Mana : MonoBehaviour
{
    public TextMeshProUGUI manaText;
    public float mana;
    public float maxMana;

    void Start()
    {
        mana = maxMana;
    }

    void Update()
    {
        float roundedMana = (float)Math.Round(mana, 1);
        manaText.text = "Mana: " + roundedMana;

        if (Input.GetKeyDown(KeyCode.E))
            UseMana(12.555f);
    }
    public void UseMana(float manaCost)
    {
        if (mana > 0)
            mana -= manaCost;
        if (mana < 0)
            mana = 0;
    }
}
