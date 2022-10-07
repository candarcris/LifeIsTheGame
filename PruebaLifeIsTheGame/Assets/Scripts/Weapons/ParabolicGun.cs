using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicGun : Weapon
{
    [SerializeField] private GameObject bulletPosition;
    private void Awake() 
    {
        bulletPosition = GameObject.Find("BulletPosition");
    }
    public override void Shoot()
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        
        if(bullet != null)
        {
            bullet.transform.position = bulletPosition.transform.position;
            bullet.transform.rotation = bulletPosition.transform.rotation;
            bullet.SetActive(true);
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}
