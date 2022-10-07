using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCharacter : MonoBehaviour
{
    [SerializeField] Door door;
    public float velocidad;
    public Transform guiaPersonaje;
    public bool enPosicion = false;
    public GameObject camara;

    void Awake()
    {
        door = GameObject.Find("DoorMove").GetComponent<Door>();
    }
        

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "PuntoDeRuta")
        {
            enPosicion = true;
            door.OpenDoor();
            
            if(guiaPersonaje.GetComponent<Collider>())
            {
                guiaPersonaje.GetComponent<Collider>().enabled = false;
            }
        }
    }
    void Desplazamiento()
    {
        if(enPosicion == false)
        {
            float velocidadDesplazamiento = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, guiaPersonaje.position, velocidadDesplazamiento);
        }
    }
    void Observacion()
    {
        camara.GetComponent<MouseLook>().ActivarMouseLook();
    }

        void FixedUpdate()
    {
        Observacion();
        Desplazamiento();
    }
}
