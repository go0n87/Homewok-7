using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangerScript : MonoBehaviour
{

    public float timeTrainingPeasant;
    public float timeTrainingWarrior;

    public int coastPeasant;
    public int coastWarrior;
    public int peasantQuantity;
    public int warriorQuantity;

    [SerializeField] int wheatQuantity;


    void Start()
    {
        wheatQuantity = 100;
    }
    
    void Update()
    {
        
    }

    public bool checkCoastUnit(string UnitType)
    {
        if (UnitType == "Peasant")
        { 
            if (wheatQuantity > coastPeasant) 
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
            if (wheatQuantity > coastWarrior)
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
