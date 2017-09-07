using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CustomCollider2D : MonoBehaviour {
    #region main variables
    public string[] layerMaskList = new string[] { "Default" };
    public BoxCollider2D boxCollider;
    public int horizontalRayCount= 2;
    public int verticalRayCount = 2;

    private CustomPhysics2D rigid;
    private BoxCornerStruct colliderBounds;
    private int layerMask;
    #endregion main variables

    #region monobehaviour methods
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigid = GetComponent<CustomPhysics2D>();
        layerMask = LayerMask.GetMask(layerMaskList);
    }


    private void Update()
    {
        colliderBounds = GetCurrentColliderCorners();
    }

    private void OnValidate()
    {
        if (horizontalRayCount < 2) horizontalRayCount = 2;
        if (verticalRayCount < 2) verticalRayCount = 2;
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
