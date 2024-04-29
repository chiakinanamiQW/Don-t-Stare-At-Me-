using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public Camera camera;
    [SerializeField]private Vector2 playerMousePoint;
    public Vector2 PlayerMousePoint
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

    public Vector2 GetPlayerPosDirection()
    {
        Vector3 playerPosition = transform.position;
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - playerPosition;
        direction.Normalize();
        return direction;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, camera.ScreenToWorldPoint(Input.mousePosition));
    }
}
