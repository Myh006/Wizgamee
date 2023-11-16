using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spatkScript : MonoBehaviour
{
    float explosionInterval = 0.5f;
    float nextExplosionTime;
    // Start is called before the first frame update
    void Start()
    {
        nextExplosionTime = Time.time + explosionInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextExplosionTime)
        {
            Animator.Destroy(gameObject);
        }
    }
}
