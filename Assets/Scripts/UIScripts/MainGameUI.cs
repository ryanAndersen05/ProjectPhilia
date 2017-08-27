﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// The primary HUD of the game. Holds references to various UI elements for other scripts to reference
/// </summary>
public class MainGameUI : MonoBehaviour {
    #region static variables
    private static MainGameUI instance;

    public static MainGameUI Instance
    {
        get
        {
            if (!instance)
            {
                instance = GameObject.FindObjectOfType<MainGameUI>();
            }
            return instance;
        }
    }
    #endregion static variables

    #region main variables
    public RectTransform pauseMenu;
    #endregion main variables

    #region monobehaviour methods
    private void Awake()
    {
        instance = this;

    }

    private void Update()
    {
        
    }
    #endregion monobehaviour methods

    private void CheckPauseGame()
    {
        //Pausing the game should only be allowed if the game is playing normally. And unpausing it would
        if (GameOverseer.Instance.currentGameState == GameOverseer.GameState.Game_Paused)
        {

        }
        else if (GameOverseer.Instance.currentGameState == GameOverseer.GameState.Game_Playing)
        {

        }
    }
}
