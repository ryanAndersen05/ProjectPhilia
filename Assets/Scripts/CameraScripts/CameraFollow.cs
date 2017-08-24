using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float cameraLerpSpeed;

    private Transform targetTransform;
    private Vector2 targetOffset;

    /// <summary>
    /// On start up we set the targetTransform to be the cameras parent
    /// </summary>
    private void Awake()
    {
        targetTransform = this.transform.parent;
        if (targetTransform)
        {
            targetOffset = targetTransform.position - this.transform.position;
        }
    }

    private void LateUpdate()
    {
        if (!targetTransform) return;
    }
}
