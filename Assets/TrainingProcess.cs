using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingProcess : MonoBehaviour
{
    public Button CurrentButton;
    public Image CurrentImage;

    public float MaxTime;

    private float currentTime;
    private bool trainingIsActive;

    private void Start()
    {
        trainingIsActive = false;
    }

    void Update()
    {
        if (trainingIsActive)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                trainingIsActive = false;
                CurrentButton.enabled = true;
                CurrentImage.gameObject.SetActive(false);
            }
            else
            {
                CurrentImage.fillAmount = currentTime / MaxTime;
            }            
        }
        
    }

    public void buttonTrainingClick()
    {
        trainingIsActive    = true;
        currentTime         = MaxTime;
        
    }
}
