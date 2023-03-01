using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public Button PeasantButton;

    void Update()
    {

        Debug.Log(PeasantButton.enabled);
      
    }
}
