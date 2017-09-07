using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CustomCollider2D : MonoBehaviour {
    #region main variables
    public string[] layerMaskList = new string[] { "Default" };
    public int horizontalRayCount= 2;
    public int verticalRayCount = 2;

    private CustomPhysics2D rigid;
    private BoxCornerStruct colliderBounds;
    private int layerMask;
    private BoxCollider2D boxCollider;
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

    private Collider CastRaysToNearestCollider(Vector2 p1, Vector2 p2, int rayCount, Vector2 rayDirection)
    {
        Vector2 directionFromP1ToP2 = (p2 - p1).normalized;
        float magFromP1ToP2 = (p2 - p1).magnitude;
        Ray2D ray;
        for (int i = 0; i < rayCount; i++)
        {
            ray = new Ray2D(p1 + directionFromP1ToP2 * (magFromP1ToP2 / (rayCount - 1)), rayDirection);
        }
        return null;
    }




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
