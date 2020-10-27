using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverObj;
    public GameObject settingsMenu;
    public GameObject levelcomplete;
    public PlayerMovement playerMovement;
    public Text TimeText;
    public  float Alltime=0;



    public void Start()
    {
        TimeText.text = Alltime.ToString();
    }
    public void Update()
    {
        if(playerMovement.playerProp.isAlive)
        Alltime += Time.deltaTime;
        TimeText.text = Math.Round(Alltime).ToString();
    }

     
   
    public void GameOver()
    {
        gameOverObj.SetActive(true);
    }
    public void StartGame()
    {
        gameOverObj.SetActive(false);
        Time.timeScale = 1F;
        SceneManager.LoadScene(0);            
    }

   
    public void Settings()
    {
        settingsMenu.SetActive(true);
        Time.timeScale = 0F;
       

    }
    public void Resume()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1F;       
       
    }

    public void Levelcomplete()
    {
        levelcomplete.SetActive(true);
    }


}
