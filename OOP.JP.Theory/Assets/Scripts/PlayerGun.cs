using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject firePoint;

    public GameObject bullet;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerCam = GameObject.Find("playerCam");
        firePoint = GameObject.Find("Shooter");
    }


    void Update()
    {
       // transform.position = player.transform.position + new Vector3(.365f, .379f, .668f);
        transform.rotation = playerCam.transform.rotation;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    //player y gun z bullet x
    virtual public void Shoot()
    {
        //bullet.transform.rotation = player.transform.rotation;
        //Quaternion rotation = Quaternion.Euler(90f, player.transform.rotation.y, player.transform.rotation.z);
        Instantiate(bullet, firePoint.transform.position,Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));//
        
    }
}
