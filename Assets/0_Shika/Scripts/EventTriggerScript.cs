using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class EventTriggerScript : MonoBehaviour
{
    GameObject DropArea;
    bool isCanvas;
    public static int TemplateNumber = 0;
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
            if (target.gameObject.name == "TestStartPanel" || target.gameObject.name == "TestEndPanel")
            {
                DropArea = target.gameObject;
                //Debug.Log("TestPanel検知成功");
                transform.SetParent(DropArea.transform);
                isCanvas = false;
            }

            if (target.gameObject.name == "ObjectPanel1" || target.gameObject.name == "ObjectPanel2")
            {
                DropArea = target.gameObject;
                if (DropArea.transform.childCount < 1)
                {
                    transform.SetParent(DropArea.transform);
                }
                else
                {
                    DropArea = preParent;
                    transform.SetParent(DropArea.transform);
                }
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
                //Debug.Log(i);
                //Debug.Log("私は" + transform.position.y);
                //Debug.Log(DropArea.transform.GetChild(i).position.y);
                //Debug.Log(isCanvas);
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
    }

    public void OnTemplateMouseDown()
    {
        TemplateNumber = this.gameObject.transform.GetSiblingIndex();
        //Debug.Log(TemplateNumber);
    }
}

