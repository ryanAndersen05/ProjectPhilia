using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenu : MonoBehaviour {
    public SelectionNode initialSelectionNode;
    [Tooltip("Use this variable in order to reset the current node back to the initial node whenever this menu is loaded")]
    public bool resetSelectionNodeAfterEnable;
    [Tooltip("The threshold on the axis required before an action will occur")]
    [Range(0f, 1f)]
    public float axisThreshold = 0.5f;


    private SelectionNode currentSelectionNode;
    private float previousHorizontalInputt;
    private float previousVerticalInput;
    
    #region monobehaviour methods
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
                    if (currentSelectionNode.westNode) currentSelectionNode = currentSelectionNode.westNode;
                }
                else
                {
                    if (currentSelectionNode.eastNode) currentSelectionNode = currentSelectionNode.eastNode;
                }
            }
        }

        if (Mathf.Abs(vInput) > axisThreshold)
        {
            if (Mathf.Abs(previousVerticalInput) <= axisThreshold)
            {
                if (vInput < 0)
                {
                    if (currentSelectionNode.southNode) currentSelectionNode = currentSelectionNode.southNode;
                }
                else
                {
                    if (currentSelectionNode.northNode) currentSelectionNode = currentSelectionNode.northNode;
                }
            }
        }

        this.previousHorizontalInputt = hInput;
        this.previousVerticalInput = vInput;


    }
    #endregion monobehaviour methods



}
