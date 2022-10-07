using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Camera cam;
    public GameObject mirilla, hitBall;
    public Transform parabolicGun, parabolicGunHand;
    public Transform atractGrenade, atractGrenadeHand;
    public Transform forceBat, forceBatHand;
    public bool pg = false, ag = false, fb = false;

    void Awake() 
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Ray rayo = cam.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
        RaycastHit hit = new RaycastHit();
        Debug.DrawRay (rayo.origin, rayo.direction, Color.red);
        if(Physics.Raycast(rayo, out hit))
        {
            var selection = hit.transform;

            if(selection.tag == "ParabolicGun")
            {
                if(Input.GetMouseButtonDown(0))
                {
                    pg = true;
                    parabolicGun.gameObject.SetActive(false);
                    parabolicGunHand.gameObject.SetActive(true);

                    atractGrenade.gameObject.SetActive(true);
                    atractGrenadeHand.gameObject.SetActive(false);

                    forceBat.gameObject.SetActive(true);
                    forceBatHand.gameObject.SetActive(false);
                    hitBall.gameObject.SetActive(false);
                }
            }

            if(selection.tag == "AtractGrenade")
            {
                if(Input.GetMouseButtonDown(0))
                {
                    ag = true;
                    atractGrenade.gameObject.SetActive(false);
                    atractGrenadeHand.gameObject.SetActive(true);

                    parabolicGun.gameObject.SetActive(true);
                    parabolicGunHand.gameObject.SetActive(false);

                    forceBat.gameObject.SetActive(true);
                    forceBatHand.gameObject.SetActive(false);
                    hitBall.gameObject.SetActive(false);
                }
            }

            if(selection.tag == "ForceBat")
            {
                if(Input.GetMouseButtonDown(0))
                {
                    fb = true;
                    forceBat.gameObject.SetActive(false);
                    forceBatHand.gameObject.SetActive(true);
                    hitBall.gameObject.SetActive(true);

                    atractGrenade.gameObject.SetActive(true);
                    atractGrenadeHand.gameObject.SetActive(false);

                    parabolicGun.gameObject.SetActive(true);
                    parabolicGunHand.gameObject.SetActive(false);
                }
            }
        }
    }
}
