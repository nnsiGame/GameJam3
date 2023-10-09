using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : MonoBehaviour
{
    Collider2D m_Collider;
    [SerializeField] GameObject m_Shield;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider2D>();
        m_Collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Shield) m_Collider.enabled = true;
    }
}
