using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // The maximum health value
    public int currentHealth; // The current health value

    private void Start()
    {
        // Initialize the current health to the maximum health on start
        currentHealth = maxHealth;
    }

   

    public void TakeDamage(int damageAmount)
    {
        // Reduce the current health by the damage amount
        currentHealth -= damageAmount;

       

        // Check if the object has been depleted of health
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Call any other necessary methods, like triggering animations or effects
            // when the object is damaged but not destroyed
        }
    }

    public void SpecialAttack() 
    {
        currentHealth -= 100;
        if (currentHealth <= 0) { }
    }



    private void Die()
    {
        // Perform any necessary actions when the object is destroyed, like playing death animations or particle effects
        Destroy(gameObject);
    }
}