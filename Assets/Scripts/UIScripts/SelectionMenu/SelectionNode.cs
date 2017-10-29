using UnityEngine;

public class SelectionNode : MonoBehaviour {
    #region enums
    public enum NodeType
    {
        ButtonNode;
        SliderNode;
    }
    #endregion enums

    #region main variables
    public NodeType selectionNodeType;

    public SelectionNode northNode;
    public SelectionNode southNode;
    public SelectionNode eastNode;
    public SelectionNode westNode;
    #endregion main variables

    #region monobehavior methods

    #endregion monobehavior methods
}
