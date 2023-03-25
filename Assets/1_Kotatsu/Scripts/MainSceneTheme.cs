using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneTheme : MonoBehaviour
{
    public List<Sprite> images;

    void Start()
    {
        GetComponent<Image>().sprite = images[ThemeRandom.index];
    }
}