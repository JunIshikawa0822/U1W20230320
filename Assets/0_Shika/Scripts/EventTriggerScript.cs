using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EventTriggerScript : MonoBehaviour
{
    GameObject DropArea;
    bool isCanvas;
    public static bool isTemplateDisplay = false;
    public static int TemplateNumber = 0;
    public static string[] pickWordsArray;
    public static string excuseWord;
    GameObject preParent;

    public void OnWordsPanelBeginDrag()
    {
        //Debug.Log("押された");       
        preParent = transform.parent.gameObject;
        isCanvas = true;
        //Debug.Log(isCanvas);
        transform.parent = GameObject.Find("Canvas").transform;
    }

    public void OnWordsPanelDrag()
    {
        transform.position = Input.mousePosition;
    }

    public void OnWordsPanelEndDrag()
    {
        //Debug.Log("終わった");

        PointerEventData pointer = new PointerEventData(EventSystem.current);

        //RaycastAllの結果格納用List RaycastAllはポイントに存在する全てのuGUIを取得できる(RaycastTargetがついているもののみ)
        List<RaycastResult> getUIList = new List<RaycastResult>();

        //PointerEventDataにマウスの位置をセット
        pointer.position = Input.mousePosition;
        //マウスの位置にあるuGUIを全て取得
        EventSystem.current.RaycastAll(pointer, getUIList);

        foreach (RaycastResult target in getUIList)
        {
            //Debug.Log(target.gameObject.name);
            if (target.gameObject.tag == "NounStartPanel")
            {
                StartPanelCheck(target, "NounWordsPanel");
                break;
            }

            else if (target.gameObject.tag == "VerbStartPanel")
            {
                StartPanelCheck(target, "VerbWordsPanel");
                break;
            }

            else if (target.gameObject.tag == "AdjStartPanel")
            {
                StartPanelCheck(target, "AdjWordsPanel");
                break;
            }

            else if (target.gameObject.tag == "NounObjectPanel")
            {
                ObjectPanelCheck(target, "NounWordsPanel");
                break;
            }
            else if(target.gameObject.tag == "VerbObjectPanel")
            {
                ObjectPanelCheck(target, "VerbWordsPanel");
                break;
            }
            else if (target.gameObject.tag == "AdjObjectPanel")
            {
                ObjectPanelCheck(target, "AdjWordsPanel");
                break;
            }

            else
            {
                DropArea = preParent;
                //Debug.Log("Canvas検知成功");
                //Debug.Log(preParent.name);
                transform.SetParent(DropArea.transform);
            }
        }

        //親子関係の設定
        if (isCanvas == false)
        {
            //Debug.Log("false発動！！");
            int index = DropArea.transform.childCount;
            //Debug.Log(DropArea.transform.childCount);
            for (int i = 0; i < DropArea.transform.childCount; i++)
            {
                if (transform.position.y > DropArea.transform.GetChild(i).position.y)
                {
                    index = i;
                    //Debug.Log("Index : " + index);
                    if (transform.GetSiblingIndex() < index)
                        index--;
                        //Debug.Log("now Index : " + index);

                    break;
                }
            }

            //Debug.Log("Finally Index : " + index);
            transform.SetParent(DropArea.transform);
            transform.SetSiblingIndex(index);
        }

        //Templateタグがついたオブジェクトを捕捉
        GameObject getTemplate = GameObject.FindGameObjectWithTag("Template");
        //Debug.Log(getTemplate.transform.childCount);

        for (int i = 0; i < getTemplate.transform.childCount - 1; i++)
        {
            //Debug.Log(string.Join(",", pickWordsArray));
            //取得したTemplateのi番目の子要素(ObjectPanel)にwordPanelが挿入されているか
            if (getTemplate.transform.GetChild(i).childCount > 0)
            {
                //子要素(ObjectPanel)を取得
                GameObject ObjectPanel = getTemplate.transform.GetChild(i).gameObject;
                //孫要素(WordPanel)を取得
                GameObject WordPanel = ObjectPanel.transform.GetChild(0).gameObject;
                Text text = WordPanel.GetComponentInChildren<Text>();
                pickWordsArray[i] = text.text.ToString();
                //Debug.Log(string.Join(",", pickWordsArray));
            }
            //挿入されていない場合
            else
            {
                pickWordsArray[i] = null;
            }
        }
    }

    public void OnTemplateMouseDown()
    {
        TemplateNumber = this.gameObject.transform.GetSiblingIndex();

        GameObject Templates = GameObject.Find("Templates");
        //Debug.Log(getTemplate.transform.childCount);

        for (int i = 0; i < Templates.transform.childCount; i++)
        {
            GameObject displayedTemplate = Templates.transform.GetChild(i).gameObject;
            //取得したTemplateのi番目の子要素(ObjectPanel)にwordPanelが挿入されているか
            if (i == TemplateNumber)
            {
                displayedTemplate.SetActive(true);
            }
            //挿入されていない場合
            else
            {
                displayedTemplate.SetActive(false);
            }
        }

        isTemplateDisplay = !isTemplateDisplay;
        //Debug.Log(TemplateNumber);
    }

    public void TemplateDisplaySwitcher()
    {
        isTemplateDisplay = !isTemplateDisplay;
    }

    private void StartPanelCheck(RaycastResult target, string wordPanelName)
    {
             
        if (this.gameObject.tag == wordPanelName)
        {
            DropArea = target.gameObject;
            transform.SetParent(DropArea.transform);
            isCanvas = false;
        }
        else
        {
            DropArea = preParent;
            transform.SetParent(DropArea.transform);
        }
        
    }

    private void ObjectPanelCheck(RaycastResult target, string wordPanelName)
    {
        DropArea = target.gameObject;
        if (DropArea.transform.childCount < 1 && this.gameObject.tag == wordPanelName)
        {
            transform.SetParent(DropArea.transform);
        }
        else
        {
            DropArea = preParent;
            transform.SetParent(DropArea.transform);
        }
    }

    public void OnDetermineButtonMouseDown()
    {
        List<string> excuseWordList = new List<string>
        {
            pickWordsArray[0] + "が" + pickWordsArray[1] + pickWordsArray[2] + "を" + pickWordsArray[3] + "たから",
            pickWordsArray[0] + "が" + pickWordsArray[1] + "のような" + pickWordsArray[2] + pickWordsArray[3] + "に" + pickWordsArray[4] + "たから",
            pickWordsArray[0] + "に" + pickWordsArray[1] + "ていたら" + pickWordsArray[2] + "が" + pickWordsArray[3] + "に" + pickWordsArray[4] + "たから",
            pickWordsArray[0] + pickWordsArray[1] + "が" + pickWordsArray[2] + "て" + pickWordsArray[3] + "が" + pickWordsArray[4] + "たから",
            pickWordsArray[0] + "が" + pickWordsArray[1] + "から" + pickWordsArray[2] + "が" + pickWordsArray[3] + pickWordsArray[4] + "を" +pickWordsArray[5] + "たから",
            pickWordsArray[0] + "を" + pickWordsArray[1] + "ながら" + pickWordsArray[2] + pickWordsArray[3] + "を" + pickWordsArray[4] + "たから",
            pickWordsArray[0] + pickWordsArray[1] + "が" + pickWordsArray[2] + "たら" + pickWordsArray[3] + pickWordsArray[4] + "が" + pickWordsArray[5] + "たから"
        };
       
        excuseWord = excuseWordList[TemplateNumber];
        //Debug.Log(excuseWordList[TemplateNumber]);
    }
}

