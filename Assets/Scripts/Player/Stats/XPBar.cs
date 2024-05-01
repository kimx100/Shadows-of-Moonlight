using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Slider xpBar;

    public XP xpComponent;
    private void Update()
    {
        xpBar.maxValue = xpComponent.maxXP;
        xpBar.value = xpComponent.xp;
    }
}
