using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectionMenu : MonoBehaviour {
    public SelectionNode initialSelectionNode;
    [Tooltip("Use this variable in order to reset the current node back to the initial node whenever this menu is loaded")]
    public bool resetSelectionNodeAfterEnable;
    [Tooltip("The threshold on the axis required before an action will occur")]
    [Range(0f, 1f)]
    public float axisThreshold = 0.5f;
    public PointerMovement pointer;



    protected SelectionNode currentSelectionNode;
    private float previousHorizontalInputt;
    private float previousVerticalInput;

    public delegate string ButtonDelegate();

    #region monobehaviour methods
    private void Awake()
    {
        SetCurrentSelectionNode(initialSelectionNode);
    }

    private void OnEnable()
    {
        if (resetSelectionNodeAfterEnable)
        {
            currentSelectionNode = initialSelectionNode;
        }
    }

    private void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(hInput) > axisThreshold)
        {
            if (Mathf.Abs(previousHorizontalInputt) <= axisThreshold)
            {
                if (hInput < 0)
                {
                    print(hInput);
                    if (currentSelectionNode.westNode) SetCurrentSelectionNode(currentSelectionNode.westNode);
                }
                else
                {
                    print(hInput);
                    if (currentSelectionNode.eastNode) SetCurrentSelectionNode(currentSelectionNode.eastNode);
                }
            }
        }

        if (Mathf.Abs(vInput) > axisThreshold)
        {
            if (Mathf.Abs(previousVerticalInput) <= axisThreshold)
            {
                if (vInput < 0)
                {
                    print(vInput);
                    if (currentSelectionNode.southNode) SetCurrentSelectionNode(currentSelectionNode.southNode);
                }
                else
                {
                    print(vInput);
                    if (currentSelectionNode.northNode) SetCurrentSelectionNode(currentSelectionNode.northNode);
                }
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            currentSelectionNode.OnActionEvent();
        }

        this.previousHorizontalInputt = hInput;
        this.previousVerticalInput = vInput;
    }


    #endregion monobehaviour methods

    private void SetCurrentSelectionNode(SelectionNode selectionNode)
    {
        this.currentSelectionNode = selectionNode;
        if (pointer)
        {
            pointer.SetNewTargetTransform(currentSelectionNode.pointerPositions[0]);
        }
    }

    protected virtual void UpdateAllNodes()
    {

    }

}
