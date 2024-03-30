using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public List<GameObject> weaponsList = new List<GameObject>();

    [SerializeField]private GameObject currentWeapon;
    [SerializeField]private PlayerDirection playerDirection;
    [SerializeField]private Attribute playerAttribute;


    private Vector3 sumPosition;
    private float angle;
    private Vector3 Mousepoint;
    private void Awake()
    {
        playerAttribute = transform.parent.GetComponent<Attribute>();
        playerDirection = transform.parent.GetComponent<PlayerDirection>();
    }

    void Update()
    {
        Controllrotate();

        if (Input.GetKeyDown(KeyCode.Q)|| Input.GetKeyDown(KeyCode.E))
        {
            SwitchWeapon();
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAttack();
        }
    }

    private void Controllrotate()
    {
        Mousepoint = new Vector3(playerDirection.PlayerMousePoint.x, playerDirection.PlayerMousePoint.y, 0);
        angle = Vector3.SignedAngle(Vector3.up, Mousepoint, Vector3.forward);//以向上为正方向
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    private void CurrentWeaponSummon()
    {
        if(transform.childCount != 0) 
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        Instantiate(currentWeapon, this.transform, false);
    }

    public void SwitchWeapon()
    {
        Debug.Log("switch");
        if(currentWeapon == null)
        {
            currentWeapon = weaponsList[0];
            CurrentWeaponSummon();
            return;
        }
        if(currentWeapon == weaponsList[weaponsList.Count - 1])
        {
            currentWeapon = weaponsList[0];
            CurrentWeaponSummon();
        }
        else
        {
            for (int i = 0; i < weaponsList.Count; i++)
            {
                if (currentWeapon == weaponsList[i]) 
                {
                    currentWeapon = weaponsList[i+1];
                    CurrentWeaponSummon();
                    break;
                }
            }
        }
    }

    public void PlayerAttack()
    {
        if(transform.childCount != 0) 
        {
            transform.GetChild(0).GetComponent<Weapon>().Attack();
        }
    }

    public void ChangeWeaponList(GameObject newWeapon,int changedWeaponIndex)
    {
        
        GameObject oldWeapon = weaponsList[changedWeaponIndex];
        weaponsList[changedWeaponIndex] = newWeapon;

        if (currentWeapon == oldWeapon)
        {
            Debug.Log("Destiory");
            currentWeapon = newWeapon;
            CurrentWeaponSummon();
        }
    }
}
