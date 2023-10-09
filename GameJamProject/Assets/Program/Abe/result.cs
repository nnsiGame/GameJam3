using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{

    [SerializeField] GameObject good;
    [SerializeField] GameObject great;
    [SerializeField] GameObject wonderful;


    public Text scoreText;
    public int goodD;
    public int goodgreat;
    public int greatwonderful;
    public int wonderfulU;

    void Start()
    {
        GameObject script1Object = GameObject.Find("ScoreManager");
        ScoreManager script1 = script1Object.GetComponent<ScoreManager>();
        // int point = script1.myVariable;
        int point = script1.m_Score;
        scoreText.text = " " + script1.m_Score;



        good.SetActive(false);
        great.SetActive(false);
        wonderful.SetActive(false);

        if (point>=goodD && point<100)
        {
            good.SetActive(false);

        }

        else if (point >= 0 && point < 100)
        {
            great.SetActive(false);

        }

        else if (point >= 0 && point < 100)
        {
            wonderful.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
