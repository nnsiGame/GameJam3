using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MagicCreatePosition : MonoBehaviour
{
    Camera m_Camera;

    private void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = m_Camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousePos - transform.position;
        
        transform.rotation = Quaternion.FromToRotation(Vector2.right, dir);
    }
}
