using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int m_Score { get;private set; }

    public void PlusScore(int score) => m_Score += score;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
