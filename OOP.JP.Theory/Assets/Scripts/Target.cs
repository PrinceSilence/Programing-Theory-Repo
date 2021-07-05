using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int maxHealth;         
    private int currentHealth;

    public bool isMoveDir = false;
    public int randomSpeed;
    public int maxMoveRangeRandomX;

    private void Awake()
    {
        SetMaxHeath();
        SetCurrentHealthToMax();
        print(gameObject.name +" Health = " + currentHealth);

        SetRandomMoveSpeed();
        MaxMove();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Projectile")
        {
            TakeDamage(other.GetComponent<Projectile>().damage);
            print("Current Health = " + currentHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Update()
    {
        Move();
    }

    virtual public void SetMaxHeath()
    {
        maxHealth = 10;
    }
    private void SetCurrentHealthToMax()
    {
        currentHealth = maxHealth;
    }
    public int TakeDamage(int damage)
    {
        currentHealth -= damage;
        return currentHealth;
    }
    private void Die()
    {            
        print(gameObject.name + "was Destroyed");
        Destroy(gameObject);
    }


    //==================Movement==============//
    virtual public float MaxMove()
    {
        maxMoveRangeRandomX = Random.Range(0, 20);
        return maxMoveRangeRandomX;
    }

    virtual public int SetRandomMoveSpeed()
    {
        randomSpeed = Random.Range(5, 20);
        return randomSpeed;
    }

    virtual public void Move()
    {
        if (isMoveDir == false)//move left
        {

            if (-maxMoveRangeRandomX < transform.position.x)
            {
                transform.Translate(Vector3.right * Time.deltaTime * -1 * randomSpeed);
            }
            else if (-maxMoveRangeRandomX >= transform.position.x)
            {
                isMoveDir = true;
                MaxMove();
                SetRandomMoveSpeed();
            }
        }
        if (isMoveDir == true) //move right
        {
            if (maxMoveRangeRandomX > transform.position.x)
            {
                transform.Translate(Vector3.right * Time.deltaTime * randomSpeed);
            }
            else if (maxMoveRangeRandomX <= transform.position.x)
            {
                isMoveDir = false;
                MaxMove();
                SetRandomMoveSpeed();
            }
        }
    }

}
