using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BGM��ς��鉼�v���O����
public class BGMManager : MonoBehaviour
{
    float m_ABGMPlayTime, m_BBGMPlayTime; // �Ȃ��Đ�����ۂ̎n�܂鎞��
    public bool m_ABGM { get; private set; } // TODO ���̖��OBGM�̖��O�Ȃǂ����܂莟��ς���

    [SerializeField] AudioClip m_ABGMClip;
    [SerializeField] AudioClip m_BBGMClip;

    AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_ABGMPlayTime = 0;
        m_BBGMPlayTime = 0;

        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = m_ABGMClip;
        m_AudioSource.Play();

        m_ABGM = true;
    }

    // Update is called once per frame
    void Update()
    {
        // �E�N���b�N��������BGM��؂�ւ���
        bool changeBGM = Input.GetButtonDown("ChangeBGM");
        if (changeBGM) ChangeBGM();
    }

    void ChangeBGM()
    {
        if(m_ABGM)
        {
            m_ABGMPlayTime = m_AudioSource.time;
            m_AudioSource.Stop();
            m_AudioSource.clip = m_BBGMClip;
            m_AudioSource.time = m_BBGMPlayTime;
            m_AudioSource.Play();
        }
        else
        {
            m_BBGMPlayTime = m_AudioSource.time;
            m_AudioSource.Stop();
            m_AudioSource.clip = m_ABGMClip;
            m_AudioSource.time = m_ABGMPlayTime;
            m_AudioSource.Play();
        }

        m_ABGM = !m_ABGM;
    }
}
