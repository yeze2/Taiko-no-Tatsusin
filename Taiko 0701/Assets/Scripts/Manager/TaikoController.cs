using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TaikoController : MonoBehaviour
{
    TimingManager timing;
    public static bool isHitMobileCtr;
    private void Start()
    {
        timing = FindObjectOfType<TimingManager>();
        isHitMobileCtr = false;
    }

    public void RightinTouch()
    {
        timing.CheckTiming();
    }
    public void LeftinTouch()
    {
        timing.CheckTiming();
    }
}
