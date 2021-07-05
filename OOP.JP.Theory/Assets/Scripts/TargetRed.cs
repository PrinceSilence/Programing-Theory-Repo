using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRed : Target
{
    private int maxMoveRangeRandomY;

    public override void SetMaxHeath()
    {
        maxHealth = 1;
    }

    public override void Move()
    {
        if (isMoveDir == false)//move left
        {

            if (-maxMoveRangeRandomY < transform.position.y)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -1 * randomSpeed);
            }
            else if (-maxMoveRangeRandomY >= transform.position.y)
            {
                isMoveDir = true;
                MaxMove();
                SetRandomMoveSpeed();
            }
        }
        if (isMoveDir == true) //move right
        {
            if (maxMoveRangeRandomY > transform.position.y)
            {
                transform.Translate(Vector3.up * Time.deltaTime * randomSpeed);
            }
            else if (maxMoveRangeRandomY <= transform.position.y)
            {
                isMoveDir = false;
                MaxMove();
                SetRandomMoveSpeed();
            }

        }
    }
    public override float MaxMove()
    {
        maxMoveRangeRandomY = Random.Range(2, 12);
        return maxMoveRangeRandomY;
    }
}
