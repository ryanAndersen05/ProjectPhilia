﻿using UnityEngine;

public class SelectionNode : MonoBehaviour {
    #region enums
    public enum NodeType
    {
        ButtonNode,
        SliderNode
    }
    #endregion enums

    #region main variables
    public NodeType selectionNodeType;

    public SelectionNode northNode;
    public SelectionNode southNode;
    public SelectionNode eastNode;
    public SelectionNode westNode;

    public delegate void ButtonDelagate();
    public ButtonDelagate buttonActionEvent;
    #endregion main variables

    #region monobehaviour methods
    private void OnValidate()
    {
        if (selectionNodeType == NodeType.SliderNode)
        {
            this.eastNode = null;
            this.westNode = null;
        }
    }
    #endregion monobehaviour methods

    public void OnActionEvent()
    {

    }
}
