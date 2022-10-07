using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosOrbita : MonoBehaviour
{
    public float velRotacion = 50f;
    private float vel = 0.01f;
    public Transform campoOrbita;
    public Transform pivote;
    Rigidbody rb;
    [SerializeField] Collider coll;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CampoGrav")
        {
            vel = 0;
        }
    }
    public void Orbitar()
    {
        transform.position = Vector3.MoveTowards(transform.position, campoOrbita.position, vel);
        rb.useGravity = false;
        //rb.mass = 0;
        this.transform.RotateAround(pivote.transform.position, Vector3.up, velRotacion * Time.deltaTime);
    }

    public void StopOrbit()
    {
        rb.useGravity = true;
        vel = 0.01f;
    }
}
