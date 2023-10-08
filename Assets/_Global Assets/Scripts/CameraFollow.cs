using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public bool followX = false;
    public bool followY = false;
    public float leftCap = float.NegativeInfinity;
    public float rightCap = float.PositiveInfinity;
    public float topCap = float.PositiveInfinity;
    public float bottomCap = float.NegativeInfinity;

    void FixedUpdate()
    {
        transform.position = new Vector3(
            followX ? Mathf.Max(leftCap, Mathf.Min(rightCap, playerTransform.position.x)) : transform.position.x,
            followY ? Mathf.Max(bottomCap, Mathf.Min(topCap, playerTransform.position.y)) : transform.position.y,
            transform.position.z);
    }
}
