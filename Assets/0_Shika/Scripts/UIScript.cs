using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public List<string> excuseWordsList = new List<string>();
    public List<string> excuseTemplatesList = new List<string>();

    public string[] selectWordsArray = new string[5];

    public string[] pickWordsArray = new string[3];

    //public GameObject[] templateArray;

    public GameObject wordPanelPrefab, excusePanelPrefab, startPanel, svContent;

    public GameObject ObjectPanel1, ObjectPanel2;
    // Start is called before the first frame update

    public void WordListInit()
    {
        excuseWordsList = new List<string>()
        {
            "犬", "猫", "石川", "矢野", "仲宗根",
            "加藤", "髙橋", "渡辺", "佐藤", "田中",
            "堀", "森永", "黒川", "伊藤", "中村",
            "山口", "保科", "寺内", "磯", "三合",
            "井上", "伝", "多田", "中川", "房安", "藤堂"
        };
    }

    public void ExcuseTemplateInit()
    {
        excuseTemplatesList = new List<string>()
        {
            "〇〇が〇〇だから",
            "〇〇していたから",
            "〇〇のような〇〇を〇〇したから",
            "〇〇を〇〇したから"
        };
        //templateArray = new GameObject[excuseTemplatesList.Count];
    }

    public void WordCardsInstantiate()
    {
        for(int i = 0; i < selectWordsArray.Length; i++)
        {
            //excuseWordsListからランダムに一つを取得してselectWordsArrayに入れる
            int n = Random.Range(0, excuseWordsList.Count);
            string t = excuseWordsList[n];
            selectWordsArray[i] = t;

            //入れたワードをexcuseWordsListから削除して被りが起こらないようにする
            excuseWordsList.RemoveAt(n);

            //パネルを生成し、ワードをセット
            GameObject item = Instantiate(wordPanelPrefab);
            Text text = item.GetComponentInChildren<Text>();
            text.text = selectWordsArray[i].ToString();

            //Panelを親要素としてPanelに配置
            item.transform.SetParent(startPanel.transform, true);          
        }
    }

    public void ExcuseTemplateInstantiate()
    {
        for (int i = 0; i < excuseTemplatesList.Count; i++)
        {
            //パネルを生成し、ワードをセット
            GameObject item = Instantiate(excusePanelPrefab);
            Text text = item.GetComponentInChildren<Text>();
            text.text = excuseTemplatesList[i].ToString();
            //Debug.Log(text.text);

            //canvasを親要素としてスクロールビューのContentに配置
            item.transform.SetParent(svContent.transform, true);
        }
    }

    public void ExcuseWords()
    {
        if(ObjectPanel1.transform.childCount > 0)
        {
            GameObject Panel1 = ObjectPanel1.transform.GetChild(0).gameObject;
            Text text1 = Panel1.GetComponentInChildren<Text>();
            pickWordsArray[0] = text1.text.ToString();
            Debug.Log(string.Join(",", pickWordsArray));
        }
        else
        {
            pickWordsArray[0] = null;
            Debug.Log(string.Join(",", pickWordsArray));
        }

        if (ObjectPanel2.transform.childCount > 0)
        {
            GameObject Panel2 = ObjectPanel2.transform.GetChild(0).gameObject;
            Text text2 = Panel2.GetComponentInChildren<Text>();
            pickWordsArray[1] = text2.text.ToString();
            Debug.Log(string.Join(",", pickWordsArray));
        }
        else
        {
            pickWordsArray[1] = null;
            Debug.Log(string.Join(",", pickWordsArray));
        }

        //if (ObjectPanel3.transform.childCount > 0)
        //{
        //    GameObject Panel1 = ObjectPanel1.transform.GetChild(0).gameObject;
        //    Text text1 = Panel1.GetComponentInChildren<Text>();
        //    pickWordsArray[0] = text1.ToString();
        //}
        //else
        //{
        //    pickWordsArray[0] = null;
        //}
    }
}
