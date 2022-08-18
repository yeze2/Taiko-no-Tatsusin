using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeManager : MonoBehaviour
{
    public GameObject tamashi;
    public RectTransform gaugeTran;
    public RectTransform yGaugeTran;
    public int bpm;
    public float unit = 17.5f;

    public GameObject yellowGauge;

    private bool isChangedtoYG;
    private int oneGaugeBar=34; //들고올수잇으면 난이도 따라서 얘도

    public void Awake()
    {
        gaugeTran = GetComponent<RectTransform>();
        yGaugeTran = GetComponent<RectTransform>();
        yellowGauge.SetActive(false);
    }
    public void Set(int gauge)
    {
        if(!isChangedtoYG)
        { 
            gaugeTran.sizeDelta = new Vector2(gauge * unit, gaugeTran.sizeDelta.y);
        }

        if(gauge > oneGaugeBar)
        {
            yellowGauge.SetActive(true);
            isChangedtoYG = true;
        }
        else if(gauge< oneGaugeBar)
        {
            yellowGauge.SetActive(false);
            isChangedtoYG = false;
        }
    }
}
