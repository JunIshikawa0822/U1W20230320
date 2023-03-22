using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public List<string> excuseWordsList = new List<string>();
    public List<string> excuseTemplatesList = new List<string>();
    public string[] selectWordsArray = new string[5];

    public GameObject wordPanelPrefab, excusePanelPrefab,startPanel,svContent;
    // Start is called before the first frame update

    public void WordListInit()
    {
        excuseWordsList = new List<string>() { "犬", "猫", "石川", "矢野", "仲宗根", "加藤", "髙橋", "渡辺", "佐藤", "田中", "堀", "森永", "黒川", "伊藤", "中村" };
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
            Debug.Log(text.text);

            //canvasを親要素としてスクロールビューのContentに配置
            item.transform.SetParent(svContent.transform, true);
        }
    }
}
