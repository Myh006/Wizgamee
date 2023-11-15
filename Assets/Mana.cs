using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public ManaBar manaBar;

    float manaInterval = 1f;
    float nextManaTime;

    public int maxMana = 300;
    public int currentMana;
    

    // Start is called before the first frame update
    void Start()
    {

        currentMana = maxMana;
      //  manaBar.setMaxMana = maxMana;
        nextManaTime = Time.time + manaInterval;

        manaBar.SetMaxMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        manaBar.SetMana(currentMana);

        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }

        else if (currentMana <= 0)
        {
            currentMana = 0;
        }
        if (Time.time > nextManaTime)
        {
            
         
            
                currentMana += 30;
                nextManaTime = Time.time + manaInterval;
            


        }



        //  manaBar.setMana = currentMana;
    }
        
    

    public void InititateAttack(int attackType)
    {
        currentMana -= attackType; 
    }
}
