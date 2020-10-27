using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public float maxenergy;
    public float minenergy;
    public float currentenergy;
    [SerializeField]
    private float vis;
    public Image bar;
   
    

    void Start()
    {
        currentenergy = minenergy;
        vis = currentenergy;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentenergy < 100)
        {
            currentenergy -= 9f * Time.deltaTime;
            if (currentenergy < 1)
                currentenergy = 1;
        }
        if (currentenergy < 1)
            currentenergy = 1;
        if (currentenergy >= 100)
            currentenergy = 100;
        bar.fillAmount =  currentenergy/maxenergy ;
        vis = currentenergy;
    }

    public void AddEnergy(int plusenergy)
    {
        currentenergy += plusenergy;
    }
}
