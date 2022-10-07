using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] WeaponValues weaponValues;


    public virtual void Shoot()
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();

        if(bullet != null)
        {
            bullet.SetActive(true);
        }
    }
}
