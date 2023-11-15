using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public GameObject Player;

    Mana mana;


    int fireAttack = 30;

    float rotDiff = 180f;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Wizard");
        mana = Player.GetComponent<Mana>();
        
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * velocity;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + rotDiff);
        if (mana.currentMana >= 30)
        {
            mana.InititateAttack(fireAttack);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            // Deduct desired hitpoints from the enemy's health
            enemyHealth.TakeDamage(10);      
            Destroy(gameObject);
            

        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
