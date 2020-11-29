using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonParce : MonoBehaviour
{
    public TextAsset ta_vvpipc;
    public TextAsset ta_kof;

    public KOEFS Koefs;
    public VVP_IPC VvpIpc;
    public List<RegionPoint> RegionsPoints = new List<RegionPoint>();


    public UILineRenderer LineRenderer;
    
    
    void Start()
    {
        // Debug.Log(kof.text);
        Koefs = JsonUtility.FromJson<KOEFS>(ta_kof.text);
        VvpIpc = JsonUtility.FromJson<VVP_IPC>(ta_vvpipc.text);
        Debug.Log(JsonUtility.ToJson(VvpIpc));
        StartCoroutine(FindNumber());
        
    }

    // ВВП на коэфиницнт А  и ИПЦ на коэфиницнт B домножаете. и складываете.
    public IEnumerator FindNumber()
    {
        foreach (var koef in Koefs.koef)
        {
            var regionPoint = new RegionPoint();
            regionPoint.region = koef.region;
            var points = new List<Point>();
            for (int i = 0; i < VvpIpc.index.Length; i++)
            {
                var point = new Point
                {
                    year = VvpIpc.index[i],
                    number = VvpIpc.data[i].vvp * koef.vvp_ipc_koef[1] + VvpIpc.data[i].ipc * koef.vvp_ipc_koef[0] +
                             koef.vvp_ipc_koef[2]
                };
                points.Add(point);
            }

            regionPoint.points = points;
            RegionsPoints.Add(regionPoint);
            yield return null;
        }

        double minN = int.MaxValue;
        double maxN = int.MinValue;
        foreach (var point in GetPointByRegion("Архангельская область"))
        {
            if (minN > point.number)
            {
                minN = point.number;
            }
            if (maxN < point.number)
            {
                maxN = point.number;
            }
            //LineRenderer.points.Add(new Vector2((float)point.year, (float)point.number));
        }
        
        foreach (var point in GetPointByRegion("Архангельская область"))
        {
            var s = maxN - minN;
            //LineRenderer.points.Add(new Vector2((float)point.year-2015, (float)point.number-(float)minN));
        }

    }

    public List<Point> GetPointByRegion(string region)
    {
        foreach (var regionPoint in RegionsPoints)
        {
            if (regionPoint.region.Equals(region))
            {
                return regionPoint.points;
            }
        }

        return null;
    }
}

[Serializable]
public class RegionPoint
{
    public string region;
    public List<Point> points;
}

[Serializable]
public class Point
{
    public int year;
    public double number;
}

[Serializable]
public class KOEFS
{
    public KOEF[] koef;
}

[Serializable]
public class KOEF
{
    public string region;
    public double[] vvp_ipc_koef;
}

[Serializable]
public class VVP_IPC
{
    public string[] columns;
    public int[] index;
    public Data[] data;
}

[Serializable]
public class Data
{
    public float vvp;
    public float ipc;
}