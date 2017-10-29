using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuActions : MonoBehaviour {
    public void DebugToggle()
    {
        MainGameUI.Instance.debugUI.gameObject.SetActive(!MainGameUI.Instance.debugUI.gameObject.activeSelf);
    }
}
