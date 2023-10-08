using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField,Header("è¡Ç¶ÇÈÇ‹Ç≈ÇÃéûä‘")] float m_DestroyTime = 3;
    [SerializeField] float m_Speed = 3;
    Rigidbody2D m_RB;
    // Start is called before the first frame update
    void Start()
    {
        m_RB = GetComponent<Rigidbody2D>();
        m_RB.velocity = transform.right * m_Speed;
    }

    // Update is called once per frame
    void Update()
    {
        m_DestroyTime -= Time.deltaTime;

        if (m_DestroyTime < 0) Destroy(gameObject);
    }
}
