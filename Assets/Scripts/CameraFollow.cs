using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 0.125f;
    Vector3 offset = new Vector3(0, 0, -1);

    void Start()
    {
        Datamanager dataManager = new Datamanager();
        transform.position = dataManager.LoadCameraPosition();
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;
    }
}
