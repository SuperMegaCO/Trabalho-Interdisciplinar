using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int fire = 5;
    public static int water = 5;
    public static int earth = 5;
    public static int air = 5;
    public static bool[] ElementQueue = new bool[4];
    public KeyCode[] ElementCodes = {KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P};
    public enum elements {FIRE,WATER,EARTH,AIR}
    string currentmessage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ElementSelect(ElementQueue, ElementCodes);
        spellMachine();
        Debug.Log(currentmessage);
    }
    public void ElementSelect(bool[] queue, KeyCode[] keys)
    {
        if (ElementQueue[(int)elements.FIRE])
        {
            if (Input.GetKeyDown(keys[(int)elements.FIRE]))
            {

                currentmessage = "Fire Removed From Queue";
                ElementQueue[(int)elements.FIRE] = false;
            }

        }
        else if (Input.GetKeyDown(keys[(int)elements.FIRE]))
        {
            currentmessage = "Fire Added To Queue";
            ElementQueue[(int)elements.FIRE] = true;

        }
        if (ElementQueue[(int)elements.WATER])
        {
            if (Input.GetKeyDown(keys[(int)elements.WATER]))
            {

                currentmessage = "WATER Removed From Queue";
                ElementQueue[(int)elements.WATER] = false;
            }

        }
        else if (Input.GetKeyDown(keys[(int)elements.WATER]))
        {
            currentmessage = "WATER Added To Queue";
            ElementQueue[(int)elements.WATER] = true;
        }
    }
    public void spellMachine()
    {
        if (ElementQueue[(int)elements.FIRE] && ElementQueue[(int)elements.WATER])
        {
            currentmessage = "Steam is ready to cast";
        }
    }
}

