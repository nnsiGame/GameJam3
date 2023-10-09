using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 強制スクロール（カメラにアタッチ）
public class ForcedScroll : MonoBehaviour
{
    [SerializeField] float m_AScrollSpeed = 3;
    [SerializeField] float m_BScrollSpeed = 5;

    BGMManager m_BGMManager;

    private void Start()
    {
        m_BGMManager = GameObject.FindWithTag("BGMManager").GetComponent<BGMManager>();
    }

    private void FixedUpdate()
    {
        if(m_BGMManager.m_ABGM)transform.Translate(transform.right * m_AScrollSpeed * Time.deltaTime);
        else transform.Translate(transform.right * m_BScrollSpeed * Time.deltaTime);
    }
}
