using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class result : MonoBehaviour
{

    [SerializeField] GameObject good;
    [SerializeField] GameObject great;
    [SerializeField] GameObject wonderful;

   

    public int goodD;
    public int goodgreat;
    public int greatwonderful;
    public int wonderfulU;

    void Start()
    {
        //Script1 script1 = GetComponent<Script1>();
        // int point = script1.myVariable;
         int point = 0;




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
