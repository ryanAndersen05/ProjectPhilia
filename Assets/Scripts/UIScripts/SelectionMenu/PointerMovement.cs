using UnityEngine;

public class PointerMovement : MonoBehaviour {
    #region main variables
    [Tooltip("The lerp transform speed that will be applied to the pointer transform object when moving to a new position")]
    public float pointerSpeed = 1;

    /// <summary>
    /// Should contain the target postion that the pointer should be placed
    /// </summary>
    private Transform targetTransform;
    #endregion main variables

    #region monobehaviour methods
    private void Start()
    {
        if (targetTransform)
        {
            SetNewTargetTransform(targetTransform, true);
        }
    }


    private void Update()
    {
        if (!targetTransform) return;


        this.transform.position = Vector3.Lerp(this.transform.position, targetTransform.position, Time.deltaTime * pointerSpeed);
    }
    #endregion monobehaviour methods


    public void SetNewTargetTransform(Transform targetTransform, bool moveImmediatelyToTarget = false)
    {
        if (moveImmediatelyToTarget)
        {
            this.transform.position = targetTransform.position;
        }

        this.targetTransform = targetTransform;

    }
}
