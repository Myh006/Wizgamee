using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaBar : MonoBehaviour
{
   [SerializeField]
    Slider slider;
    // Start is called before the first frame update

    public void SetMaxMana(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }
    public void SetMana(int mana)
    {
        slider.value = mana;
    }
}