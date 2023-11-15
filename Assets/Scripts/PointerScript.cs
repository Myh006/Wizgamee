using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    float yAxis;
    float minY = -5f;
    float maxY = 20f;

    // Start is called before the first frame update
    void Start()
    {
        yAxis = transform.position.y;
    }

    // Update is called once per frame
    Vector3 mousePosition;
    void Update()
    {
        float yValue = mousePosition.y;
        yValue = Mathf.Clamp(yValue, minY, maxY);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, yValue, 1f);
    }
}
