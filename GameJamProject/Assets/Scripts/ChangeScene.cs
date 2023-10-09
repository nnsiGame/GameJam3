using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void change_button()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void change_button1()
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void change_button2()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
