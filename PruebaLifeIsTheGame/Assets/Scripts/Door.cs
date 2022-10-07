using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator doorAnim;

    void Awake()
    {
        doorAnim = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        doorAnim.SetTrigger("Open");
    }
}
