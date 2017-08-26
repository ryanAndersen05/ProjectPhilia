using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverseer : MonoBehaviour {
    #region enums
    public enum GameState { Game_Playing, Game_Paused }
    #endregion enums

    #region static variables
    private static GameOverseer instance;

    public static GameOverseer Instance
    {
        get
        {
            if (!instance)
            {
                instance = GameObject.FindObjectOfType<GameOverseer>();
            }
            return instance;
        }
    }

    #endregion static varaibles

    #region main variables
    public GameState currentGameState { get; private set; }
    #endregion main variables


    #region monobehaviour methods
    private void Awake()
    {
        instance = this;
    }
    #endregion monobehaviour methods

    /// <summary>
    /// Potentially want to use this to make some adjustments to the game if the state is ever changed.
    /// For instance we may want to remove control from the player if the game is paused, and return control if the
    /// game is playing.
    /// </summary>
    /// <param name="newGameState"></param>
    public void SetGameState(GameState newGameState)
    {
        currentGameState = newGameState;
    }
    /// <summary>
    /// Returns true if the currentGame state is equal to the 
    /// </summary>
    /// <param name="gameState"></param>
    /// <returns></returns>
    public bool IsCurrentGameState(GameState gameState)
    {
        return this.currentGameState == gameState;
    }
}
