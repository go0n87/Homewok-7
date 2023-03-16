using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMangerScript : MonoBehaviour
{
    public Image ImageRaidClockTop;
    public Image ImageRaidClockDown;

    public Image ImageEatClockTop;
    public Image ImageEatClockDown;

    public Image ImageHarvestClockTop;
    public Image ImageHarvestClockDown;

    public Text quantityWheatText;
    public Text quantityPeasantText;

    public float timeTrainingPeasant;
    public float timeTrainingWarrior;
    public float timeBeforeAttack;
    public float timeEatCycle;
    public float timeHarvestCycle;

    public int coastPeasant;
    public int coastWarrior;
    public int peasantQuantity;
    public int warriorQuantity;
    public int wheatPerPeasant;
    public int wheatToWarrior;

    public int enemyGain;

    [SerializeField] int wheatQuantity;

    private float timeRaidTop;
    private float timeRaidDown;

    private float eatTimerkTop;
    private float eatTimerkDown;

    private float harvestTimerTop;
    private float harvestTimerDown;

    void Start()
    {

        timeRaidTop = timeBeforeAttack;
        timeRaidDown = 0;

        eatTimerkTop = timeEatCycle;
        eatTimerkDown = 0;

        harvestTimerTop = timeHarvestCycle;
        harvestTimerDown = 0;

        quantityWheatText.text      = wheatQuantity.ToString();
        quantityPeasantText.text    = peasantQuantity.ToString();    


    }
    
    void Update()
    {
        checkTimerAnimation(ref timeRaidTop    , ref timeRaidDown    , ref timeBeforeAttack, ImageRaidClockTop   , ImageRaidClockDown);
        checkTimerAnimation(ref eatTimerkTop   , ref eatTimerkDown   , ref timeEatCycle    , ImageEatClockTop    , ImageEatClockDown);
        checkTimerAnimation(ref harvestTimerTop, ref harvestTimerDown, ref timeHarvestCycle, ImageHarvestClockTop, ImageHarvestClockDown);

    }

    public bool checkCoastUnit(string UnitType)
    {
        if (UnitType == "Peasant")
        { 
            if (wheatQuantity >= coastPeasant) 
            {
                wheatQuantity = wheatQuantity - coastPeasant;
                quantityWheatText.text = wheatQuantity.ToString();
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
                quantityWheatText.text = wheatQuantity.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }      
    }

    private void checkTimerAnimation(ref float timeClockTop, ref float timeClockDown, ref float totalTime,Image ImageSandClockTop, Image ImageSandClockDown) 
    {
        timeClockTop  -= Time.deltaTime;
        timeClockDown += Time.deltaTime;

        if (timeClockTop <= 0)
        {

        }
        else
        {
            ImageSandClockTop.fillAmount = timeClockTop / totalTime;
            ImageSandClockDown.fillAmount = timeClockDown / totalTime;

        }
    }
}
