using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parallex : MonoBehaviour
{
    private Image sprite;
    public float animationSpeed = 0.5f;


    private void Awake()
    {
        sprite = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
