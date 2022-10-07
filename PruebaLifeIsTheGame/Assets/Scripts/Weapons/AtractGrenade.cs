using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtractGrenade : Weapon
{
    private float velRot = 500f;
    private float speed = 3;
    public Transform objectiveGrenade, parentGrenade, grenadeHandP, grenadeInitPos, campo;
    public bool inPlace = false, shootDone = false;
    private Animator anim;

    public List<GameObject> orbitObjectsList = new List<GameObject>();

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable() 
    {
        ReestartGrenade();
    }

    private void ReestartGrenade()
    {
        transform.parent = grenadeHandP.transform.parent;
        objectiveGrenade.parent = grenadeHandP.transform.parent;
        anim.SetTrigger("Restart");
        transform.position = grenadeHandP.position;
        objectiveGrenade.GetComponent<Collider>().enabled = true;
        objectiveGrenade.position = grenadeInitPos.position;
        shootDone = false;
        inPlace = false;
    }

    public override void Shoot()
    {
        if(inPlace == false)
        {
            shootDone = true;
            anim.SetTrigger("Launched");
            transform.parent = parentGrenade.parent;
            objectiveGrenade.parent = parentGrenade.parent;
            float velocidadDesplazamiento = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, objectiveGrenade.position, velocidadDesplazamiento);
        }
    }

    public void OrbitaGrenade()
    {
        this.transform.Rotate(new Vector3(0, velRot, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "GrenadeObjective")
        {
            inPlace = true;
            campo.gameObject.SetActive(true);
            anim.enabled = false;
            
            if(objectiveGrenade.GetComponent<Collider>())
            {
                objectiveGrenade.GetComponent<Collider>().enabled = false;
            }
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            shootDone = true;
        }

        if(shootDone)
        {
            Shoot();
        }
        if(inPlace)
        {
            OrbitaGrenade();
            foreach (var objOrbit in orbitObjectsList)
            {
                objOrbit.GetComponent<ObjetosOrbita>().Orbitar();
            }
        }
        else if(!inPlace)
        {
            foreach (var objOrbit in orbitObjectsList)
            {
                objOrbit.GetComponent<ObjetosOrbita>().StopOrbit();
            }
        }
    }
}
