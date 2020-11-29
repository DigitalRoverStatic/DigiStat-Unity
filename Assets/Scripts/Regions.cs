using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Regions : MonoBehaviour
{
    private Toggle toggle;

    public TMP_Text Text;
    
    public Color ColorIsOn;
    public Color ColorIsOff;
    public UIControl ui;
    
    private void Start()
    {
        ui = FindObjectOfType<UIControl>();
        Text.color = ColorIsOff;
    }

    public void OnValueChange(bool isOn)
    {
        if (isOn)
        {
            Text.color = ColorIsOn;
            var sprite1 = Resources.Load<Sprite>("g1/" + Text.text);
            var sprite2 = Resources.Load<Sprite>("g2/" + Text.text);
            ui.img1.sprite = sprite1 == null ? Resources.Load<Sprite>("1"): sprite1;
            ui.img2.sprite = sprite2 == null ? Resources.Load<Sprite>("1"): sprite2;
            ui.TextHeader.text = Text.text;
        }
        else
        {
            Text.color = ColorIsOff;
        }
        
    }
}
