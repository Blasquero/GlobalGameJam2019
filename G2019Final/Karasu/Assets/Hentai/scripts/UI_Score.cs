using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{

    public int score;
    public GameObject slider;
    public GameObject generator;
    // Use this for initialization
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        slider.GetComponent<Slider>().value = score;

        if (score < (slider.GetComponent<Slider>().maxValue / 4))
        {
            generator.GetComponent<generator>().modo = 0;
        }
        else if (score < (2 * slider.GetComponent<Slider>().maxValue / 4))
        {
            generator.GetComponent<generator>().modo = 1;
        }
        else if (score < ( 3 * slider.GetComponent<Slider>().maxValue / 4))
        {
            generator.GetComponent<generator>().modo = 2;
        }
        else 
        {
            generator.GetComponent<generator>().modo = 3;
        }
    }
}