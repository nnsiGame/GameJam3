using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MagicGage : MonoBehaviour
{
    float m_MaxGage;
    Player m_Player;
    Image m_Image;

    private void Start()
    {
        m_Player = GameObject.FindWithTag("Player").GetComponent<Player>();
        m_Image = GetComponent<Image>();
        m_MaxGage = m_Player.m_MagicChargeGage;
    }

    private void Update()
    {
        m_Image.fillAmount = m_Player.m_MagicChargeGage / m_MaxGage;
    }
}
