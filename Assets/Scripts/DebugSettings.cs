﻿using System.Collections;
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

    public static void DrawPoint(Vector3 worldPoint, float scale, Color color)
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
    public static void DrawLineDirection(Vector3 originPoint, Vector3 direction)
    {
        DrawLineDirection(originPoint, direction, 1f);
    }

    public static void DrawLineDirection(Vector3 originPoint, Vector3 direction, float distance)
    {
        DrawLineDirection(originPoint, direction, distance, Color.red);
    }

    public static void DrawLineDirection(Vector3 originPoint, Vector3 direction, float distance, Color color)
    {
        DrawLineDirection(originPoint, direction, distance, color, 0.0f);
    }

    public static void DrawLineDirection(Vector3 originPoint, Vector3 direction, float distance, float duration)
    {
        DrawLineDirection(originPoint, direction, distance, Color.red, duration);
    }

    public static void DrawLineDirection(Vector3 originPoint, Vector3 direction, float distance, Color color, float duration)
    {
        DrawLine(originPoint, originPoint + direction * distance, color, duration);
    }

    public static void DrawLine(Vector3 originPoint, Vector3 endPoint)
    {
        DrawLine(originPoint, endPoint, Color.red);
    }

    public static void DrawLine(Vector3 originPoint, Vector3 endPoint, Color color)
    {
        DrawLine(originPoint, endPoint, color, 0.0f);
    }

    public static void DrawLine(Vector3 originPoint, Vector3 endPoint, float duration)
    {
        DrawLine(originPoint, endPoint, Color.red, duration);
    }

    public static void DrawLine(Vector3 originPoint, Vector3 endPoint, Color color, float duration)
    {
        Debug.DrawLine(originPoint, endPoint, color, duration, false);
    }
    #endregion DrawLine overrides
}
