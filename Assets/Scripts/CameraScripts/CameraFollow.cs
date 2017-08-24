using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float cameraLerpSpeed = 10;

    private Transform targetTransform;
    private Vector3 targetOffset;
    private Vector3 cameraVelocity;

    /// <summary>
    /// On start up we set the targetTransform to be the cameras parent
    /// </summary>
    private void Awake()
    {
        targetTransform = this.transform.parent;
        if (targetTransform)
        {
            targetOffset = this.transform.position - targetTransform.position;
        }
        this.transform.parent = null;
    }

    private void LateUpdate()
    {
        if (!targetTransform) return;

        //transform.position = Vector3.Lerp(transform.position, new Vector3(targetTransform.position.x, targetTransform.position.y, 0) + targetOffset, Time.deltaTime * cameraLerpSpeed);
        transform.position = Vector3.SmoothDamp(transform.position, targetTransform.position + targetOffset, ref cameraVelocity, cameraLerpSpeed);
    }
}
