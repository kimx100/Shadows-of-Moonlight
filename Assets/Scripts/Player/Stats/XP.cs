using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class XP : MonoBehaviour
{
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI levelText;
    public float xp;
    public float maxXP;
    private int level;
    private void Start()
    {
        if (level == 0)
            maxXP = 100;
    }
    void Update()
    {
        float roundedXP = (float)Math.Round(xp, 1);
        xpText.text = "" + roundedXP + " / " + maxXP;

        levelText.text = "" + level;

        if (Input.GetKeyDown(KeyCode.Q))
            GiveXP(50000f);
    }
    public void GiveXP(float xpGain)
    {
        xp += xpGain;
        if (xp >= maxXP)
        {
            StartCoroutine(LevelUp());
        }
    }
    IEnumerator LevelUp()
    {
        while (xp >= maxXP)
        {
            if (Time.timeScale != 0)
            {
                float extraXP = xp - maxXP;
                level++;
                maxXP = (float)Math.Round(maxXP + maxXP * 0.2f);
                xp = extraXP;
                yield return null;
            }
            else
                yield return null;
        }
    }
}
