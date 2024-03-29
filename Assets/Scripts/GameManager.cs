﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver;

    void Start()
    {
        _isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGameOver == true && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0); //current game scene
        }
        if (_isGameOver == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void GameOverman()
    {
        _isGameOver = true;
    }
}
