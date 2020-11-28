using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPAnel : MonoBehaviour
{
    public GameObject panelOkrug;
    public GameObject panelOES;
    public GameObject panelOblasty;
    // Start is called before the first frame update
    void Start()
    {

        panelOkrug.SetActive(false);
        panelOES.SetActive(false);
        panelOblasty.SetActive(true);
    }

   public void SetPanel(int i)
    {
        switch (i)
        {
            case 0:
                panelOkrug.SetActive(true);
                panelOES.SetActive(false);
                panelOblasty.SetActive(false);
                break;
            case 1:
                panelOkrug.SetActive(false);
                panelOES.SetActive(true);
                panelOblasty.SetActive(false);
                break;
            case 2:
                panelOkrug.SetActive(false);
                panelOES.SetActive(false);
                panelOblasty.SetActive(true);
                break;

            default:
                break;
        }
    }
}
