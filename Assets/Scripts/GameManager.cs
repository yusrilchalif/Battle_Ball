using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public float timeLeft = 140f;
    public GameObject uiPanel;
    public Text timerText;

    public static GameManager instance;
    public BallController ballControl;
    // public Transform playerUnits;
    // public GameObject Player;
    bool isTimeOver = false;

    void Start() 
    {
        uiPanel.SetActive(false);
        instance = this;
    }

    void Update() 
    {
        timerText.text = (timeLeft).ToString("0");
        if(isTimeOver == false)
        {
            timeLeft -= Time.deltaTime;
        }
        if(timeLeft <= 0)
        {
            isTimeOver = true;
            uiPanel.SetActive(true);
            ballControl.ResetPos();
        }

        // InputHandler.instance.PlayerMove();
    }


}
