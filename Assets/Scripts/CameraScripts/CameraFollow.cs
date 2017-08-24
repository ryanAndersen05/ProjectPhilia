using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float cameraLerpSpeed = 10;

    private Transform targetTransform;
    private Vector3 targetOffset;

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

        transform.position = Vector3.Lerp(transform.position, new Vector3(targetTransform.position.x, targetTransform.position.y, 0) + targetOffset, Time.deltaTime * cameraLerpSpeed);
    }
}
