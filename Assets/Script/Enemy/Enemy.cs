using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [Header("����")]
    public int MaxHealth;
    public int Health;
    public float PhyDamage;
    public float MaDamage;
    public float GunDamage;
    public float Speed;
    public bool isPoisoned;
    public bool isBlood;
    public bool isCold;
    [Header("Ѱ·����")]
    public UnityEvent<Vector2> OnMovement;
    public UnityEvent OnAttack;
    [SerializeField] private Transform player;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float attackDistance;
    
    private Seeker seeker;
    private List<Vector3> pathPointList;//·�����б�
    private int currentIndex = 0;//·��������
    private float pathGenerateInterval = 0.5f;//ÿ0.5s����һ��·��;
    private float pathGenerateTimer = 0f;

    private void Awake()
    {
        seeker=GetComponent<Seeker>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Attribute>().TakeDamage(this);
        }
    }
    //�Զ�Ѱ·
    private void AutoPath() 
    {
        pathGenerateTimer += Time.deltaTime;
        //ÿ0.5s����һ��
        if (pathGenerateTimer >= pathGenerateInterval)
        {
            GeneratePath(player.position);
            pathGenerateTimer = 0f;
        }
        //��·���б�Ϊ�գ�����·������
        if(pathPointList == null || pathPointList.Count == 0)
        {
            GeneratePath(player.position);
        }//�����˵��ﵱǰ·���㣬��������currentIndex������·������
        else if (Vector2.Distance(transform.position, pathPointList[currentIndex]) <= 0.1f)
        {
            currentIndex++;
            if (currentIndex >= pathPointList.Count)
            {
                GeneratePath(player.position);
            }
        }
    } 
    private void Update()
    {
        if(player==null)
        {
            return;
        }
       
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance < chaseDistance)
        {
            AutoPath();
            if (pathPointList == null)
            {
                return;
            }
            if (distance <= attackDistance)
            {
                OnMovement?.Invoke(Vector2.zero);
                OnAttack?.Invoke();//����
            }
            else
            {
                /* Vector2 direction = player.position - transform.position;*/
                Vector2 direction = (pathPointList[currentIndex] - transform.position).normalized;
                OnMovement?.Invoke(direction);// ׷��
            }
        }
        else
        {
            OnMovement?.Invoke(Vector2.zero);
        }
       
    }
    //��ȡ·����
    private void GeneratePath(Vector3 target)
    {
        currentIndex = 0;
        //������������㣬�յ㣬�ص�����
        seeker.StartPath(transform.position, target, Path =>
        {
            pathPointList = Path.vectorPath;
        });
    }






}
