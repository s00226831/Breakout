using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int blocksRemaining;
    public int BlocksRemaining
    {
        get { return blocksRemaining; }
    }

    public int timeRemaining;
    public int livesRemaining;
    //Kepp track of how much time has passed
    float elapsedTime;

    public TMPro.TMP_Text txtTime;
    public TMPro.TMP_Text txtLives;

    private void Start()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        blocksRemaining = blocks.Length;

    }

    private void Update()
    {
        // add on how much time has passed since last update
        //fractions of a second 0.016
        elapsedTime += Time.deltaTime;

        if(elapsedTime > 1.0f)
        {
            timeRemaining--;
            elapsedTime = 0;

            txtTime.text = timeRemaining.ToString();
        }

        CheckIfGameOver();
    }
    private void CheckIfGameOver ()
        {
            if(blocksRemaining <= 0)
            {
            SceneManager.LoadScene("gamewon");
            }
            else if(livesRemaining <=0 || timeRemaining <=0)
            {
            SceneManager.LoadScene("gameover");
            }

        }
    public void OnBlockDestroyed()
    {
        blocksRemaining--;
        CheckIfGameOver();
    }
    public void OnLiveLost()
    {
        livesRemaining--;
        CheckIfGameOver();
        txtLives.text = livesRemaining.ToString();
    }
    }
    

