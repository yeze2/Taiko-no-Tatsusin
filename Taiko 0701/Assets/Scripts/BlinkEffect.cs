using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkEffect : MonoBehaviour
{
    private float time;

    void Update()
    {
        if(time<0.5f)
        {
            GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1 - time);
        }
        else
        {
            GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, time);
            if(time>1f)
            {
                time = 0f;
            }
        }
        time += Time.deltaTime;
    }
}
