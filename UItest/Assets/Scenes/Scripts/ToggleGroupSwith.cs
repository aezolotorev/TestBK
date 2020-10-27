using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleGroupSwith : MonoBehaviour
{
    
    public Toggle toggleAll;
   

    void Start()
    {
        toggleAll = GetComponent<Toggle>();
        toggleAll.onValueChanged.AddListener((value)=>ChangeValue(value));
    }

    // Update is called once per frame
    public void ChangeValue(bool isOn)
    {
        if (isOn)
        {
            var toggles = GameObject.FindGameObjectsWithTag("Toggle");
            foreach(var tog in toggles)
            {
                tog.SendMessage("OnToggle");                
            }

        }

        else if (!isOn)
        {
            var toggles = GameObject.FindGameObjectsWithTag("Toggle");
            foreach (var tog in toggles)
            {
                tog.SendMessage("OffToggle");
            }
        }
    }
}
 