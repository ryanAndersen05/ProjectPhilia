using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSettings : MonoBehaviour {

    #region DrawPoint overrides

    public static void DrawPoint(Vector3 worldPoint)
    {
        DrawPoint(worldPoint, Color.red);
    }

    public static void DrawPoint(Vector3 worldPoint, Color color)
    {
        DrawPoint(worldPoint, 1, color);
    }

    public static void DrawPoint (Vector3 worldPoint, float scale)
    {
        DrawPoint(worldPoint, scale, Color.red);
    }

    public static void DrawPoint (Vector3 worldPoint, float scale, Color color)
    {
        DrawPoint(worldPoint, scale, color, 0.0f);
    }

    public static void DrawPoint(Vector3 worldPoint, float scale, float duration)
    {
        DrawPoint(worldPoint, scale, Color.red, duration);
    }

    public static void DrawPoint(Vector3 worldPoint, float scale, Color color, float duration)
    {
        float offset = scale / 2f;
        Debug.DrawLine(worldPoint + Vector3.up * offset, worldPoint - Vector3.up * offset, color, duration, false);
        Debug.DrawLine(worldPoint + Vector3.right * offset, worldPoint - Vector3.right * offset, color, duration, false);

        Vector3 dir = new Vector3(1, 1, 0).normalized;
        Debug.DrawLine(worldPoint + dir * offset, worldPoint - dir * offset, color, duration, false);
        dir = new Vector3(1, -1, 0);
        Debug.DrawLine(worldPoint + dir * offset, worldPoint - dir * offset, color, duration, false);
    }
    #endregion DrawPoint overrides

    #region DrawLine overrides

    #endregion DrawLine overrides
}
