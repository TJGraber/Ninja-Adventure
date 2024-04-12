using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    TextMeshProUGUI damageText;

    void Awake()
    {
        damageText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetDamageText(float damage)
    {
        damageText.text = damage.ToString();
    }

    public void DestroyText()
    {
        Destroy(this.gameObject);
    }
}
