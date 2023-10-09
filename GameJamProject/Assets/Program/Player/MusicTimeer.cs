using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTimeer : MonoBehaviour
{
    [SerializeField] GameObject m_AGage;
    [SerializeField] GameObject m_BGage;

    Vector3 m_ARectTransform;
    Vector3 m_AScale;
    Vector3 m_BRectTransform;
    Vector3 m_BScale;

    Player m_Player;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GetComponent<Player>();

        RectTransform a = m_AGage.GetComponent<RectTransform>();
        RectTransform b = m_BGage.GetComponent<RectTransform>();

        m_ARectTransform = a.position;
        m_AScale = a.localScale;

        m_BRectTransform = b.position;
        m_BScale = b.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
