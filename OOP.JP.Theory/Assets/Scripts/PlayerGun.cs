using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject firePoint;

    public GameObject bullet;

    private void Awake()
    {
        playerCam = GameObject.Find("playerCam");
        firePoint = GameObject.Find("Shooter");
    }

    void Update()
    {
        //transform.rotation = playerCam.transform.rotation;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    virtual public void Shoot()
    {
        Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
    }
}
