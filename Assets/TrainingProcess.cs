using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingProcess : MonoBehaviour
{
    public Button CurrentButton;
    public Image CurrentImage;
    public GameObject GameManager;

    public string UnitType;

    private float currentTime;
    private float MaxTime;

    private bool trainingIsActive;    

    private void Start()
    {
        trainingIsActive = false;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (trainingIsActive)
        {            

            if (currentTime <= 0)
            {
                trainingIsActive = false;
                CurrentButton.enabled = true;
                CurrentImage.gameObject.SetActive(false);

                if (UnitType == "Peasant")
                {
                    GameManager.GetComponent<GameMangerScript>().peasantQuantity++;                    
                }
                else
                {
                    GameManager.GetComponent<GameMangerScript>().warriorQuantity++;
                }
            }
            else
            {
                CurrentImage.fillAmount = currentTime / MaxTime;
 
            }            
        }
        
    }

    public void buttonTrainingClick()
    {

        trainingIsActive = GameManager.GetComponent<GameMangerScript>().checkCoastUnit(UnitType);

        if (trainingIsActive)
        {            

            if (UnitType == "Peasant")
            {
                MaxTime     = GameManager.GetComponent<GameMangerScript>().timeTrainingPeasant;
                
            }
            else
            {
                MaxTime = GameManager.GetComponent<GameMangerScript>().timeTrainingWarrior;
            }

            CurrentButton.enabled = false;
            CurrentImage.gameObject.SetActive(true);
            currentTime = MaxTime;
        }
    }
}
