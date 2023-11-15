using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDamage : MonoBehaviour
{

    public float moveSpeed;
    public int damageAmount;
    public float damageInterval;

    float nextDamageTime;

    bool canNotMove;
    bool canDamage;

    public GameObject obstacleTracerObject;

    private void Start()
    {
        damageInterval = 1;
        moveSpeed = 5;
        damageAmount = 5;

        nextDamageTime = Time.time;

        canNotMove = false;
        canDamage = false;
    }


    private void FixedUpdate()
    {
        RaycastHit2D castleCollision = Physics2D.Raycast(obstacleTracerObject.transform.position, -Vector2.up);
        Debug.DrawRay(obstacleTracerObject.transform.position, -Vector2.up * castleCollision.distance * 1f, Color.red);

        if (castleCollision.collider != null && castleCollision.collider.CompareTag("Player"))
        {
            if (castleCollision.distance <= 0f)
            {
                canNotMove = true;
                canDamage = true;
            }

        }
    }

    private void Update()
    {
        if (canNotMove)
        {

            moveSpeed = 0;
        }

        transform.position = transform.position + (Vector3.down * moveSpeed * Time.deltaTime);

        if (canDamage && Time.time >= nextDamageTime)
        {
            ApplyDamageToTower();


        }


    }

    private void ApplyDamageToTower()
    {
        // Find the TowerHealth component and apply damage
        TowerHealth towerHealth = FindObjectOfType<TowerHealth>();
        if (towerHealth != null)
        {
            towerHealth.TakeDamage(damageAmount);
        }

        nextDamageTime = Time.time + damageInterval;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }


}