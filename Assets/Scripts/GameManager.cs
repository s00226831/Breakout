using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int blocksRemaining;
    public int timeRemaining;
    public int livesRemaining;

    public TMPro.TMP_Text txtTime;
    public TMPro.TMP_Text txtLives;

    private void Start()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        blocksRemaining = blocks.Length;
    }
    private void CheckIfGameOver ()
        {
            if(blocksRemaining <= 0)
            {
                Application.Quit();
            }
            else if(livesRemaining <= 0 || timeRemaining <=0)
        {
            //restart the scene
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
    }
    }
    

