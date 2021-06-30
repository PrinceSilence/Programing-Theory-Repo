using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int maxHealth = 10;         
    public int currentHealth;          
    public float moveSpeed = 10;        

    private void Awake()
    {
        setCurrentHealth();
        print("startHP" + currentHealth);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Projectile")
        {
            TakeDamage(other.GetComponent<Projectile>().damage);
            print("Current Health = " + currentHealth);
        }
    }
    virtual public void setCurrentHealth()
    {
        currentHealth = maxHealth;
    }
    public int TakeDamage(int damage)
    {
        currentHealth -= damage;
        return currentHealth;
    }
}
