using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;
    private float speed;
    private Rigidbody projectileRB;

    private void Awake()
    {
        speed = 2;
        projectileRB = gameObject.GetComponent<Rigidbody>();
        projectileRB.AddRelativeForce(Vector3.up * speed * Time.deltaTime, ForceMode.Impulse);
    }
}
