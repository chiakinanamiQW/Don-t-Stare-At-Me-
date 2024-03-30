using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public Camera camera;
    [SerializeField]private Vector3 playerMousePoint;
    public Vector3 PlayerMousePoint
    {
        get
        {
            return playerMousePoint;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMousePoint = GetPlayerPosDirection();
    }

    public Vector3 GetPlayerPosDirection()
    {
        Vector3 playerPosition = transform.position;
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - playerPosition;
        direction.Normalize();
        return direction;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, camera.ScreenToWorldPoint(Input.mousePosition));
    }
}
