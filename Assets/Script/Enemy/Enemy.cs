using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [Header("属性")]
    public int MaxHealth;
    public int Health;
    public float PhyDamage;
    public float MaDamage;
    public float GunDamage;
    public float Speed;
    public bool isPoisoned;
    public bool isBlood;
    public bool isCold;
    [Header("寻路参数")]
    public UnityEvent<Vector2> OnMovement;
    public UnityEvent OnAttack;
    [SerializeField] private Transform player;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float attackDistance;
    
    private Seeker seeker;
    private List<Vector3> pathPointList;//路径点列表
    private int currentIndex = 0;//路径点索引
    private float pathGenerateInterval = 0.5f;//每0.5s生成一次路径;
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
    //自动寻路
    private void AutoPath() 
    {
        pathGenerateTimer += Time.deltaTime;
        //每0.5s调用一次
        if (pathGenerateTimer >= pathGenerateInterval)
        {
            GeneratePath(player.position);
            pathGenerateTimer = 0f;
        }
        //当路径列表为空，进行路径计算
        if(pathPointList == null || pathPointList.Count == 0)
        {
            GeneratePath(player.position);
        }//当敌人到达当前路径点，递增索引currentIndex并进行路径计算
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
                OnAttack?.Invoke();//攻击
            }
            else
            {
                /* Vector2 direction = player.position - transform.position;*/
                Vector2 direction = (pathPointList[currentIndex] - transform.position).normalized;
                OnMovement?.Invoke(direction);// 追击
            }
        }
        else
        {
            OnMovement?.Invoke(Vector2.zero);
        }
       
    }
    //获取路径点
    private void GeneratePath(Vector3 target)
    {
        currentIndex = 0;
        //三个参数：起点，终点，回调函数
        seeker.StartPath(transform.position, target, Path =>
        {
            pathPointList = Path.vectorPath;
        });
    }






}
