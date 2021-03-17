using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
    [SerializeField]
    private int type;
    [SerializeField]
    private int money;


    public int Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }

    public int Money
    {
        get
        {
            return money;
        }

        set
        {
            if (value >= 0)
            {
                money = value;
            }
        }
    }


    public bool Trade()
    {
        switch (type)
        {
            case 1:
                return true;
                // break;
            case 2:
                return false;
            // break;
            case 3:
                return false;
            case 4:
                int random = Random.Range(0, 2);
                if (random == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 5:
                return false;
            default:
                return false;
                // break;
        }
    }
}
