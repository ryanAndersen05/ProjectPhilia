using System.Collections;
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

    #region monobehaviour methods
    private void Awake()
    {
        instance = this;
    }
    #endregion monobehaviour methods
}
