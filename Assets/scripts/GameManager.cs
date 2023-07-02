using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject objects;
    public GameObject[] spawnObject;
    public GameObject[] spawnPoints;
    public float timer;
    public float timeBetweenSpawns;

    public GameObject[] coinTexture;
    public GameObject[] coinSpawn;

    public GameObject gameOver;

    

    public float speedMultiplier;

    public Text distanceUI;
    //public Text recordsUI;
    private float distance;
    int i = 0;




    void Update()
    {
        if (!gameOver.activeInHierarchy)
        {
            distanceUI.text = "—чет: " + distance.ToString("F1");
            distance += Time.deltaTime * 0.8f;
            
        }
        else if (distance > PlayerPrefs.GetFloat("records", i))
        {
            PlayerPrefs.SetFloat("records", distance);
        }
        


        speedMultiplier += Time.deltaTime * 0.1f;
        timer += Time.deltaTime;


        if (timer > timeBetweenSpawns && !gameOver.activeInHierarchy)
        {
            timer = 0;
            int randN = Random.Range(0, 3);
            Instantiate(spawnObject[randN], spawnPoints[randN].transform.position, Quaternion.identity);


            int randCoin = Random.Range(0, 2);
            Instantiate(coinTexture[0], coinSpawn[randCoin].transform.position, Quaternion.identity);
        }

    }
    //void HighScore()
    //{
       // if (distance > PlayerPrefs.SetString("records", 0)) 
        //{
            //PlayerPrefs.SetString("records", distance.ToString("F1"));
       // }
   // }
}

