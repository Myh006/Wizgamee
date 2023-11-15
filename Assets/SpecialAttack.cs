using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
   public PManaBar pManaBar;

    float manaInterval = 2f;
    float nextManaTime;

   public int damage = 100;
    public int maxPMana = 100;
    public int currentPMana = 0;


    private void Start()
    {
        currentPMana = maxPMana;
        nextManaTime = Time.time + manaInterval;
        pManaBar.SetMaxMana(maxPMana);
    }
    void Update()
    {
        pManaBar.SetMana(currentPMana);
        if (Time.time > nextManaTime)
        {
            if (currentPMana >= maxPMana)
            {
                currentPMana = maxPMana;
            }
            else 
            { 
            currentPMana += 20;
            nextManaTime = Time.time + manaInterval;
            }
            
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && currentPMana >= 100)
        {
            Debug.Log("Hello world");
            // Perform your action here

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // Loop through each game object
            foreach (GameObject enemy in enemies)
            {
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                    currentPMana = 0;
                   
                }
               
            }
            
        }
    }
}