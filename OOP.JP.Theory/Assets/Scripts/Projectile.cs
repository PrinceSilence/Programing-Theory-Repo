using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    private Rigidbody projectileRB;

    private void Awake()
    {
        speed = 40;
        projectileRB = gameObject.GetComponent<Rigidbody>();
        projectileRB.AddRelativeForce(Vector3.up * speed , ForceMode.Impulse);
        Destroy(gameObject, 5);
    }
}
