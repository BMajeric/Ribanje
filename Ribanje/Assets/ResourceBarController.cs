using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBarController : MonoBehaviour
{

    public Slider resourceSlider;

    public void SetResourceMaxValue(int value)
    {
        resourceSlider.maxValue = value;
        resourceSlider.value = value;
    }

    public void SetResourceAmount(int amount)
    {
        resourceSlider.value = amount;
    }
}
