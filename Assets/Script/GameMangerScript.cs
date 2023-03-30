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
    public Text CountWarriorText;

    public GameObject GameVictoryPanel;
    public GameObject GameOverPanel;

    public AudioSource track1;
    public AudioSource track2;
    public AudioSource track3;

    public float timeTrainingPeasant;
    public float timeTrainingWarrior;
    public float timeBeforeAttack;
    public float timeEatCycle;
    public float timeHarvestCycle;

    public int coastPeasant;
    public int coastWarrior;
    public int peasantQuantity;
    public int warriorQuantity;
    public int raidQuantity;
    public int wheatPerPeasant;
    public int wheatToWarrior;
    public int enemyGain;

    [SerializeField] int wheatQuantity;

    private AudioSource[] playList;

    private int raidRange;
    private int numberOfRaid;

    private float timeRaidTop;
    private float timeRaidDown;

    private float eatTimerkTop;
    private float eatTimerkDown;

    private float harvestTimerTop;
    private float harvestTimerDown;

    private bool tickBeforeAttack;
    private bool tickEatCycle;
    private bool tickHarvestCycle;    

    void Start()
    {


        tickBeforeAttack = false;
        tickEatCycle     = false;
        tickHarvestCycle = false;

        raidRange    = 1;
        numberOfRaid = 1;

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
        checkTimerAnimation(ref timeRaidTop    , ref timeRaidDown    , ref timeBeforeAttack, ImageRaidClockTop   , ImageRaidClockDown   , ref tickBeforeAttack);
        checkTimerAnimation(ref eatTimerkTop   , ref eatTimerkDown   , ref timeEatCycle    , ImageEatClockTop    , ImageEatClockDown    , ref tickEatCycle);
        checkTimerAnimation(ref harvestTimerTop, ref harvestTimerDown, ref timeHarvestCycle, ImageHarvestClockTop, ImageHarvestClockDown, ref tickHarvestCycle);

        if(tickBeforeAttack) 
        {
            eventAttack();
        }
        
        if(tickEatCycle)     
        {
            eventEatCycle();
        }
        
        if(tickHarvestCycle) 
        {
            eventHarvestCycle();
        }

        checkVictoryConditions();
        checkDefeatConditions();
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

    private void checkTimerAnimation(ref float timeClockTop, ref float timeClockDown, ref float totalTime, Image ImageSandClockTop, Image ImageSandClockDown, ref bool tickValue) 
    {
        timeClockTop  -= Time.deltaTime;
        timeClockDown += Time.deltaTime;

        if (timeClockTop <= 0)
        {
            tickValue = true;
        }
        else
        {
            ImageSandClockTop.fillAmount = timeClockTop / totalTime;
            ImageSandClockDown.fillAmount = timeClockDown / totalTime;

        }
    }

    private void eventAttack()
    {
        timeRaidTop = timeBeforeAttack;
        timeRaidDown = 0;


        warriorQuantity       -= Random.Range(raidRange, numberOfRaid);
        CountWarriorText.text = warriorQuantity.ToString();

        if (raidRange == 3)
        {
            raidRange = 1;
        }
        else
        {
            ++raidRange;
        }

        if (numberOfRaid == 3)
        {
            numberOfRaid = 1;
        }
        else
        {
            ++numberOfRaid;
        }
        
        tickBeforeAttack = false;
    }

    private void eventEatCycle()
    {
        eatTimerkTop = timeEatCycle;
        eatTimerkDown = 0;

        tickEatCycle = false;
    }

    private void eventHarvestCycle()
    {
        wheatQuantity += peasantQuantity * 2;
        quantityWheatText.text = wheatQuantity.ToString();

        harvestTimerTop = timeHarvestCycle;
        harvestTimerDown = 0;

        tickHarvestCycle = false;
    }

    private void checkDefeatConditions()
    {
        if (warriorQuantity < 0)
        {

             GameOverPanel.SetActive(true);
             Time.timeScale  = 0;
             warriorQuantity = 0;
            
        }
        
    }
    private void checkVictoryConditions()
    {
        if (warriorQuantity == 30 || wheatQuantity == 2000)
        {
            GameVictoryPanel.SetActive(true);
            Time.timeScale  = 0;
            warriorQuantity = 0;
            wheatQuantity   = 0;
        }        
    }

}
