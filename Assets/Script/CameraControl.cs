using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraControl : MonoBehaviour
{
    public GameObject Lookat;
    public float smooth;
    private void LateUpdate()
    {
        if (Lookat != null)
        {
            Vector3 desiredPosition = Lookat.transform.position;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smooth);
            smoothedPosition.z = -10;
            transform.position = smoothedPosition;
        }

    }
}
