using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public List<string> excuseNounWordsList = new List<string>();
    public List<string> excuseVerbWordsList = new List<string>();
    public List<string> excuseAdjectiveWordsList = new List<string>();

    public List<string> excuseTemplatesList = new List<string>();

    public string[] usableNounWordsArray = new string[5];
    public string[] usableVerbWordsArray = new string[5];
    public string[] usableAdjectiveWordsArray = new string[5];

    public string[] pickWordsArray = new string[3];

    //public GameObject[] templateArray;

    public GameObject[] PartofSpeechPanelArray = new GameObject[3];
    public GameObject[] StartPanelArray = new GameObject[3];

    public GameObject excusePanelPrefab, exTemplateContent;
    //nounWordsPanelPrefab, verbWordsPanelPrefab, adjectiveWordsPanelPrefab
    //nounWordsStartPanel, verbWordsStartPanel, adjectiveWordsStartPanel

    GameObject NounPanel1, NounPanel2, VerbPanel1, VerbPanel2, AdjPanel1, AdjPanel2;
    // Start is called before the first frame update

    public void NounWordListInit()
    {
        excuseNounWordsList = new List<string>()
        {
            "僕", "お母さん", "彼女", "犬", "おじいちゃん",
            "ご飯", "ゲーム機", "お茶", "スマホ", "コップ",
            "定期券"
        };
    }

    public void VerbWordListInit()
    {
        excuseVerbWordsList = new List<string>()
        {
            "走った", "壊した", "転んだ", "無視した", "拾った",
            "投げた", "座った", "泳いだ", "持った", "倒した",
            "寝た", "見た", "買った", "調べた", "こぼした"
        };
    }

    public void AdjectiveWordsListInit()
    {
        excuseAdjectiveWordsList = new List<string>()
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

    public void NounWordCardsInstantiate()
    {
        WordCardsInstantiate(usableNounWordsArray, excuseNounWordsList, 0);
    }

    public void VerbWordCardsInstantiate()
    {
        WordCardsInstantiate(usableVerbWordsArray, excuseVerbWordsList, 1);
    }

    public void AdjectiveWordCardsInstantiate()
    {
        WordCardsInstantiate(usableAdjectiveWordsArray, excuseAdjectiveWordsList, 2);
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
            item.transform.SetParent(exTemplateContent.transform, true);
        }
    }

    public void ExcuseWords()
    {
        GameObject getTemplate = GameObject.FindGameObjectWithTag("Template");
        Debug.Log(getTemplate.name);
        for(int i = 0; i < getTemplate.transform.childCount - 1; i++)
        {
            //取得したTemplateのi番目の子要素(ObjectPanel)にwordPanelが挿入されているか
            if (getTemplate.transform.GetChild(i).gameObject.transform.childCount > 0)
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
                //Debug.Log(string.Join(",", pickWordsArray));
            }
        }
        //GameObject[] getVerbObjectPanelArray = GameObject.FindGameObjectsWithTag("VerbObjectPanel");
        //GameObject[] getAdjObjectPanelArray = GameObject.FindGameObjectsWithTag("AdjObjectPanel");

        //int wordArrayTotalLength = getNounObjectPanelArray.Length + getVerbObjectPanelArray.Length + getAdjObjectPanelArray.Length;
        //int pickWordindex = wordArrayTotalLength;
        //for(int i = 0; i < wordArrayTotalLength; i++)
        //{
        //    if (getAdjObjectPanelArray[i].transform.position.x < )
        //}

        //{
        //    if (getNounObjectPanelArray[i].transform.childCount > 0)
        //    {
        //        GameObject Panel = getNounObjectPanelArray[i].transform.GetChild(0).gameObject;
        //        Text text1 = Panel.GetComponentInChildren<Text>();
        //        pickWordsArray[0] = text1.text.ToString();
        //        Debug.Log(string.Join(",", pickWordsArray));
        //    }
        //    else
        //    {
        //        pickWordsArray[i] = null;
        //        Debug.Log(string.Join(",", pickWordsArray));
        //    }
        //}
    }

    public void WordCardsInstantiate(string[] arrayName, List<string> listName, int number)
    {
        for (int i = 0; i < arrayName.Length; i++)
        {
            //excuseWordsListからランダムに一つを取得してselectWordsArrayに入れる
            int n = Random.Range(0, listName.Count);
            string t = listName[n];
            arrayName[i] = t;

            //入れたワードをexcuseWordsListから削除して被りが起こらないようにする
            listName.RemoveAt(n);

            //パネルを生成し、ワードをセット
            GameObject item = Instantiate(PartofSpeechPanelArray[number]);
            Text text = item.GetComponentInChildren<Text>();
            text.text = arrayName[i].ToString();

            //Panelを親要素としてPanelに配置
            item.transform.SetParent(StartPanelArray[number].transform, true);
        }
    }
}
