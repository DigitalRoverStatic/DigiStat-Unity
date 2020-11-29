using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public GameObject MAP;
    public GameObject MAP2;
    public GameObject Sliders;
    public GameObject Graphs;
    public TMP_Text TextHeader;

    public Image img1;
    public Image img2;

    private bool isMap = false;

    private bool first = true;
    public void OnAnalButtonClick()
    {
        if (MAP.activeSelf)
        {
            isMap = true;
        }
        else
        {
            isMap = false;
        }
        MAP.SetActive(false);
        MAP2.SetActive(false);
        Sliders.SetActive(false);
        Graphs.SetActive(true);
        
    }
    
    public void OnMainButtonClick()
    {
        if (isMap)
        {
            MAP.SetActive(true); 
        }
        else
        {
            MAP2.SetActive(true);
        }

        Sliders.SetActive(true);
        Graphs.SetActive(false);
    }
}
