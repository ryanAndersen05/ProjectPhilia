using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectionNode : MonoBehaviour {
    #region enums
    public enum NodeType
    {
        ButtonNode,
        SliderNode
    }
    #endregion enums

    #region main variables
    public string nodeTitle = "Button";
    public NodeType selectionNodeType;
    public Text textBox;

    public UnityEvent buttonEvent;

    public SelectionNode northNode;
    public SelectionNode southNode;
    public SelectionNode eastNode;
    public SelectionNode westNode;
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
        buttonEvent.Invoke();


    }
    /// <summary>
    /// This allows us to add any
    /// </summary>
    /// <param name="buttonString"></param>
    public void SetStringOfButton(string buttonString)
    {
        textBox.text = nodeTitle + ": " + buttonString;
    }
    
}
