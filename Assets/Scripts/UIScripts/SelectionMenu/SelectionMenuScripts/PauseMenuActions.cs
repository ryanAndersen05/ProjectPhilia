using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuActions : SelectionMenu {
    public void DebugToggle()
    {
        MainGameUI.Instance.debugUI.gameObject.SetActive(!MainGameUI.Instance.debugUI.gameObject.activeSelf);
        currentSelectionNode.SetStringOfButton(MainGameUI.Instance.debugUI.gameObject.activeSelf ? "On" : "Off");

    }
}
