using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMangerScript : MonoBehaviour
{
    public Image ImageSandClockDown;
    public Image ImageSandClockTop;

    public float timeTrainingPeasant;
    public float timeTrainingWarrior;
    public float timeBeforeAttack;

    public int coastPeasant;
    public int coastWarrior;
    public int peasantQuantity;
    public int warriorQuantity;

    [SerializeField] int wheatQuantity;

    private float timeClockTop;
    private float timeClockDown;

    void Start()
    {
        wheatQuantity   = 100;
        timeClockTop    = timeBeforeAttack;
        timeClockDown   = 0;
    }
    
    void Update()
    {
        timeClockTop    -= Time.deltaTime;
        timeClockDown   += Time.deltaTime;

        if (timeClockTop <= 0)
        { 
        
        }
        else 
        {
            ImageSandClockTop.fillAmount  = timeClockTop / timeBeforeAttack;
            ImageSandClockDown.fillAmount = timeClockDown / timeBeforeAttack;

        }
    }

    public bool checkCoastUnit(string UnitType)
    {
        if (UnitType == "Peasant")
        { 
            if (wheatQuantity >= coastPeasant) 
            {
                wheatQuantity = wheatQuantity - coastPeasant;
                return true;
            }
            else 
            {                
                return false; 
            }
        }
        else 
        {
            if (wheatQuantity >= coastWarrior)
            {
                wheatQuantity = wheatQuantity - coastWarrior;
                return true;
            }
            else
            {
                return false;
            }
        }      
    }

}
