using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IpcVvpSliders : MonoBehaviour
{
    public Slider[] Sliders;
    public JsonParce JsonParce;
    public bool isVVP = false;

    public bool wasRegion = false;
    public double min = Int32.MaxValue;
    public double max = Int32.MinValue;

    IEnumerator Start()
    {
        Sliders = GetComponentsInChildren<Slider>();
        yield return new WaitForSeconds(0.5f);
        foreach (var vvpipc in JsonParce.VvpIpc.data)
        {
            if (isVVP)
            {
                if (vvpipc.vvp > max)
                {
                    max = vvpipc.vvp;
                }

                if (vvpipc.vvp < min)
                {
                    min = vvpipc.vvp;
                }
            }
            else
            {
                if (vvpipc.ipc > max)
                {
                    max = vvpipc.ipc;
                }

                if (vvpipc.ipc < min)
                {
                    min = vvpipc.ipc;
                }
            }
        }

        foreach (var slider in Sliders)
        {
            slider.minValue = (float) min * 0.9f;
            slider.maxValue = (float) max * 1.1f;
        }

        yield return null;
        int indexSlider = 0;
        for (int i = 0; i < JsonParce.VvpIpc.index.Length; i++)
        {
            if (JsonParce.VvpIpc.index[i] >= 2020 && JsonParce.VvpIpc.index[i] <= 2034)
            {
                if (isVVP)
                {
                    Sliders[indexSlider].value = JsonParce.VvpIpc.data[i].vvp;
                }
                else
                {
                    Sliders[indexSlider].value = JsonParce.VvpIpc.data[i].ipc;
                }

                indexSlider++;
            }
        }
    }
}