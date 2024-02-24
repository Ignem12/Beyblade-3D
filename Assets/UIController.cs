using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public RevolveOnStadium script;
    public InputField targetBand;
    // Update is called once per frame
    public void OnButtonClick()
    {
        float target = float.Parse(targetBand.text);

        script.targetRadius = target / 10f;
        script.rotationSpeed = 10f - target + 1f;
    }
}
