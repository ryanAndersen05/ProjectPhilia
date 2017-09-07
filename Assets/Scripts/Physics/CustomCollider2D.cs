using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CustomCollider2D : MonoBehaviour {
    #region main variables
    public BoxCollider2D boxCollider;
    #endregion main variables

    #region monobehaviour methods
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        
    }
    #endregion monobehaviour methods


    private BoxCornerStruct GetCurrentColliderCorners()
    {
        BoxCornerStruct boxCorners = new BoxCornerStruct();

        boxCorners.bottomRight = new Vector2(boxCollider.bounds.max.x, boxCollider.bounds.min.y);
        boxCorners.bottomLeft = boxCollider.bounds.min;
        boxCorners.topRight = boxCollider.bounds.max;
        boxCorners.topLeft = new Vector2(boxCollider.bounds.min.x, boxCollider.bounds.max.y);

        return boxCorners;
    } 


    private struct BoxCornerStruct
    {
        public Vector2 bottomRight;
        public Vector2 bottomLeft;
        public Vector2 topRight;
        public Vector2 topLeft;
    }
}
