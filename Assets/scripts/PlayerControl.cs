using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public GameObject gameOver;
    private Rigidbody2D rb;

    public Transform groundCheck;
    public LayerMask groundMask;
    private bool ground = false;
    private float groundRadius = 0.5f;

    public GameObject BoostAct;
    public int livescore = 0;
    public Text livesOnBoostUI;

    private float coinCount = 0;
    public Text coinCountUI;

    private Animator anim;

    public GameObject CoinCount;
    public GameObject Distance;
    public GameObject BoostPanel;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ground = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
        if (Input.GetKey(KeyCode.W) && ground==true)
        {
            Jump();
            
        }

        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().Play("penguin_slide");
        }
        if (livescore ==0)
        {
            BoostAct.SetActive(false);
        }


    }


    public void Jump()
    {
        //rb.AddForce(Vector2.up, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0,0.3f), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && livescore == 0)
        {
            gameOver.SetActive(true);
            BoostAct.SetActive(false);
            CoinCount.SetActive(false);
            BoostPanel.SetActive(false);

        }
        if(collision.tag =="Enemy"&& livescore > 0)
        {
            livescore -= 1;
            livesOnBoostUI.text = livescore.ToString();
        }
        if (collision.tag == "Coin")
        {
            float i = 1;
            coinCount += i;
            Destroy(collision.gameObject);
            coinCountUI.text = coinCount.ToString();
        }
    }



    public void Restart()
    {
        SceneManager.LoadScene("Demo");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Boost()
    {
        if (coinCount > 4)
        {
            coinCount -= 5;
            coinCountUI.text = coinCount.ToString();
            livescore += 3;
            BoostAct.SetActive(true);
            livesOnBoostUI.text = livescore.ToString();
            coinCountUI.text = coinCount.ToString();
        }

    }
}
