using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeRandom : MonoBehaviour
{
    public List<Sprite> images;
    public static int index;

    void Start()
    {
        index = Random.Range(0, images.Count);
        Debug.Log(index);

        GetComponent<Image>().sprite = images[index];
    }
}