using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject followPlayer;
    public float lerpPerFrame = .01f;
    public bool lockYAxis = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objPos = followPlayer.transform.position;

        objPos.z = transform.position.z;
        if (lockYAxis)
        {
            objPos.y = transform.position.y;
        }

        transform.position = Vector3.Lerp(transform.position, objPos, lerpPerFrame);
    }
}
