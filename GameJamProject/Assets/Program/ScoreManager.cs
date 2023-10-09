using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int m_Score { get;private set; }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlusScore(int score) => m_Score += score;

    public void ResetScore() => m_Score = 0;
}
