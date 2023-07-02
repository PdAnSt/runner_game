using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RecordsManage : MonoBehaviour
{
    public TMP_Text Scores;
    // Start is called before the first frame update
    void Start()
    {
        float flrec = PlayerPrefs.GetFloat("records");
        Scores.text = flrec.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
