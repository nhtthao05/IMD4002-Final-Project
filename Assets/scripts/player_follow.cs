using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_follow : MonoBehaviour
{
    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range(0.01f,0.1f)]
    public float SmoothFactor = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

    }
}
