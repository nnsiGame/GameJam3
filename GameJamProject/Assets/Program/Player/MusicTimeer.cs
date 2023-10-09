using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicTimeer : MonoBehaviour
{
    [SerializeField] GameObject m_AGage;
    [SerializeField] GameObject m_BGage;

    RectTransform a;
    RectTransform b;

    Vector3 m_ARectTransform;
    Vector3 m_AScale;
    Vector3 m_BRectTransform;
    Vector3 m_BScale;

    [SerializeField]Image m_AImage;
    [SerializeField]Image m_BImage;

    Player m_Player;
    BGMManager m_BGMManager;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindWithTag("Player").GetComponent<Player>();
        m_BGMManager = GameObject.FindWithTag("BGMManager").GetComponent<BGMManager>();

        a = m_AGage.GetComponent<RectTransform>();
        b = m_BGage.GetComponent<RectTransform>();

        m_ARectTransform = a.position;
        m_AScale = a.localScale;

        m_BRectTransform = b.position;
        m_BScale = b.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_BGMManager.m_ABGM)
        {
            a.position = m_ARectTransform;
            a.localScale = m_AScale;

            b.position = m_BRectTransform;
            b.localScale = m_BScale;
        }
        else
        {
            a.position = m_BRectTransform;
            a.localScale = m_BScale;

            b.position = m_ARectTransform;
            b.localScale = m_AScale;
        }

        print(m_Player.m_AMusicGage / 60);

        m_AImage.fillAmount = m_Player.m_AMusicGage / 60;
        m_BImage.fillAmount = m_Player.m_BMusicGage / 60;
    }
}
