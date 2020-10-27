using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnOffScript : MonoBehaviour
{
    public Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void OnToggle()
    {
        toggle.isOn = true;
        
    }
    public void OffToggle()
    {
        toggle.isOn = false;       

    }
}
