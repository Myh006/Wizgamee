using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class StaffFunctions : MonoBehaviour
{


    private Camera mainCam;
    private Vector3 mousePos;
    float offset = -90f;
    public GameObject Projectile;
    public Transform ProjectileTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    // Start is called before the first frame update

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg + offset;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(Projectile, ProjectileTransform.position, Quaternion.identity);
        }




    }
}
