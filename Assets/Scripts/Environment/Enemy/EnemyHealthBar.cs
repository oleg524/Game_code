using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject entity;
    CharacterStats stats;

    public GameObject healthBarUI;


    private void OnEnable()
    {
        stats = entity.GetComponent<CharacterStats>();
    }
    private void Update()
    {
        if (stats.CurrentHealth == stats.MaxHealth)
        {
            healthBarUI.SetActive(false);
        }

        else
        {
            healthBarUI.SetActive(true);
        }

        slider.maxValue = stats.MaxHealth;
        slider.value = stats.CurrentHealth;
    }
}
