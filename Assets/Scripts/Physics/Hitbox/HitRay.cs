using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Hit ray is ideal for calculating the hit boxes of bullets or other fast moving objects
/// You can dynamically set the distance of the ray cast as well as the direction that the 
/// hit will be cast
/// </summary>
public class HitRay : MonoBehaviour {
    [Tooltip("Direction of the Hit raycast")]
    public Vector2 rayDirection;
    public float lengthOfRay = 1;
    public int rayCount = 1;


}
