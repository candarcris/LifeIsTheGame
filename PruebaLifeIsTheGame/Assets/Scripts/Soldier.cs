using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public Animator anim;
    public int selectDance = 0;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        Dance(Manager.instance.selectDance);
    }

    public void Dance(int type)
    {
        switch (type)
        {
            case 1:
            anim.SetTrigger("House");
            selectDance = 1;
            Manager.instance.selectDance = selectDance;
            break;

            case 2:
            anim.SetTrigger("Macarena");
            selectDance = 2;
            Manager.instance.selectDance = selectDance;
            break;

            case 3:
            anim.SetTrigger("HipHop");
            selectDance = 3;
            Manager.instance.selectDance = selectDance;
            break;
        }
    }

    void Update()
    {
        
    }
}
