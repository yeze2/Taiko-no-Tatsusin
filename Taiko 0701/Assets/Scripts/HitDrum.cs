using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDrum : MonoBehaviour
{
    public GameObject rightIn;
    public GameObject leftIn;
    public GameObject rightOut;
    public GameObject leftOut;
    public GameObject mobileRightIn;
    public GameObject mobileLeftOut;


    public void Start()
    {
        leftIn.SetActive(false);
        rightIn.SetActive(false);
        leftOut.SetActive(false);
        rightOut.SetActive(false);
    }
    public void Update()
    {
        PressKeys();

    }

    public void PressKeys()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            leftIn.SetActive(true);

        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            leftIn.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.J) || Input.GetMouseButtonDown(0))
        {
            rightIn.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.J) || Input.GetMouseButtonUp(0))
        {
            rightIn.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            leftOut.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            leftOut.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            rightOut.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            rightOut.SetActive(false);
        }
    }
}
