using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FindPlayer : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovement;
    public UnityEvent OnAttack;
    [SerializeField] private Transform Player;
    [SerializeField] private float chassDistance = 3f;
    [SerializeField] private float AttackDistance = 0.8f;
    private void Update()
    {
        if (Player == null)
            return;
        float distance = Vector2.Distance(Player.position, transform.position);
        if (distance < chassDistance)
        {
            if (distance <= AttackDistance)
            {
                OnAttack?.Invoke();
            }
            else 
            {
                Vector2 direction = Player.position - transform.position;
                OnMovement?.Invoke(direction.normalized);
            }
        }
        else
        {
            OnMovement?.Invoke(Vector2.zero);
        }
    }
}
