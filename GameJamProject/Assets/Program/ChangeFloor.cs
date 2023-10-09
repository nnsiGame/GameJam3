using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloor : MonoBehaviour
{
    [SerializeField] bool m_Orange;
    BGMManager m_BGMMnager;
    Collider2D m_Collider;
    SpriteRenderer m_SpriteRender;

    // Start is called before the first frame update
    void Start()
    {
        m_BGMMnager = GameObject.FindWithTag("BGMManager").GetComponent<BGMManager>();
        m_Collider = GetComponent<Collider2D>();
        m_SpriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_BGMMnager.m_ABGM)
        {
            if (m_Orange)
            {
                m_Collider.enabled = true;
                m_SpriteRender.color = new Color(m_SpriteRender.color.r, m_SpriteRender.color.g, m_SpriteRender.color.b, 1);
            }
            else 
            {
                m_Collider.enabled = false;
                m_SpriteRender.color = new Color(m_SpriteRender.color.r, m_SpriteRender.color.g, m_SpriteRender.color.b, 0.1f);
            }
        }
        else
        {
            if (m_Orange)
            {
                m_Collider.enabled = false;
                m_SpriteRender.color = new Color(m_SpriteRender.color.r, m_SpriteRender.color.g, m_SpriteRender.color.b, 0.1f);
            }
            else
            {
                m_Collider.enabled = true;
                m_SpriteRender.color = new Color(m_SpriteRender.color.r, m_SpriteRender.color.g, m_SpriteRender.color.b, 1);
            }
        }
    }
}
