using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public GameObject sc;
    public GameObject lv;

    public void Scores()
    {
        sc.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Demo");
    }
    public void Stay()
    {
        lv.SetActive(false);
    }
    public void DoUQuit()
    {
        lv.SetActive(true);
    }
    public void RecEx()
    {
        sc.SetActive(false );
    }
    public void Quit()
    {
        Application.Quit();
    }
}
