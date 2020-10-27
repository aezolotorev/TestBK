using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleColor : MonoBehaviour
{
    public Toggle toggleuse;
    public Toggle togglechange;
    public Color normacolor;
    public ToggleGroup toggleGroup;

    private void Start()
    {
        normacolor = togglechange.GetComponentInChildren<Image>().color;
        
    }
    void Update()
    {
        if (toggleuse.isOn)
        {
            togglechange.GetComponentInChildren<Image>().color = Color.blue;
            
        }
        if (!toggleuse.isOn)
        {
            togglechange.GetComponentInChildren<Image>().color = normacolor;

        }
    }
}
