using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public Transform PlayerTransform;

    private Vector3 offset;

    private Vector3 _cameraOffset;

   

    public float RotationSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
        
        transform.position = player.transform.position + offset;
    }
}
