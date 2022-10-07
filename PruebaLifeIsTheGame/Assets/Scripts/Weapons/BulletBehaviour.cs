using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletBehaviour : MonoBehaviour
{   
    [SerializeField] private Rigidbody bulletRb;
    [SerializeField] private GameObject objectiveTransform;
    private float gravity = -9.8f;
    

    void Awake()
    {
        bulletRb = GetComponent<Rigidbody>();
        objectiveTransform = GameObject.Find("BulletObjective");
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Blanco"))
        {
            gameObject.SetActive(false);
        }
    }
    void OnEnable()
    {
        Physics.gravity = Vector3.up * gravity;
        bulletRb.velocity = CalcularVelInicial();
    }

    Vector3 CalcularVelInicial()
    {
        Vector3 desplazamP = objectiveTransform.transform.position - transform.position;
        float velY, velX, velZ;

        velY = Mathf.Sqrt(-2 * gravity * 1.5f);
        velX = desplazamP.x / ((-velY / gravity) + Mathf.Sqrt(2 * (desplazamP.y - 1.5f) / gravity)); 
        velZ = desplazamP.z / ((-velY / gravity) + Mathf.Sqrt(2 * (desplazamP.y - 1.5f) / gravity)); 

        return new Vector3(velX, velY, velZ);
    }

    void FixedUpdate()
    {
        
    }
}
