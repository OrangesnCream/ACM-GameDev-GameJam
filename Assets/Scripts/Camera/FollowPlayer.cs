using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    Vector3 target, mousePos, refVel, shakeOffset;
    float cameraDist = 3.5;
    float smoothTime = 0.2f, zStart;
    float 
    // Start is called before the first frame update
    void Start()
    {
        target=player.position;
        zStart = transform.positition.z;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = CaptureMousePos();
    }
    Vector3 CaptureMousePos() {
        Vector2 ret = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        ret *= 2;
        ret -= Vector2.one;
        float max = 0.9f;
        if (Mathf.Abs(ret.x)>max||Mathf.Abs(ret.y)>max) {
            ret = ret.normalized;
        }
        return ret;
    }
}
