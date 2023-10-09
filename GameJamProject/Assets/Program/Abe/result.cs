using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{

    [SerializeField] GameObject good;
    [SerializeField] GameObject great;
    [SerializeField] GameObject wonderful;

   

    public int goodD;
    public int goodgreat;
    public int greatwonderful;
    public int wonderfulU;

    public Text scoreText;

    void Start()
    {
        GameObject script1Object = GameObject.Find("Gamemanager");
        ScoreManager script1 = script1Object.GetComponent<ScoreManager>();
        int point = script1.m_Score;



        good.SetActive(false);
        great.SetActive(false);
        wonderful.SetActive(false);

        if (point>=goodD)
        {
            good.SetActive(true);

        }

        else if (point >= goodgreat && point < greatwonderful)
        {
            great.SetActive(true);

        }

        else if (point >= greatwonderful)
        {
            wonderful.SetActive(true);

        }

        scoreText.text = "" +script1.m_Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
