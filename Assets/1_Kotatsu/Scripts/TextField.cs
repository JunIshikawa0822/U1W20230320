using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextField : MonoBehaviour
{

    //オブジェクトと結びつける
    public TMP_InputField inputField;
    public Text text;

    void Start()
    {
        //Componentを扱えるようにする
        inputField = inputField.GetComponent<TMP_InputField>();
        text = text.GetComponent<Text>();

    }

    public void InputText()
    {
        //テキストにinputFieldの内容を反映
        text.text = inputField.text;

    }

}
