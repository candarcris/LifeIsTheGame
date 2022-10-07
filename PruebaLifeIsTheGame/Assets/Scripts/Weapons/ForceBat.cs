using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBat : Weapon
{
    public GameObject hitBal;
    public Transform objective, hitBallParent, parentFPS, positionHitBallInit;
    Animator anim;
    Rigidbody hitbalRb;
    public bool hit = false;

    private void Awake() 
    {
        hitbalRb = hitBal.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable() 
    {
        objective.parent = parentFPS.parent;
        hit = false;
        hitBal.transform.position = positionHitBallInit.position;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "hitBall")
        {
            objective.parent = hitBallParent.parent;
            hit = true;
        }
    }
    public override void Shoot()
    {
        anim.SetTrigger("Hit");
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(hit == true)
        {
            hitbalRb.AddForce(hitBal.transform.forward * 0.2f, ForceMode.Impulse);
        }
    }
}
