using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public List<string> excuseWordsList = new List<string>();
    public string[] selectWordsArray = new string[5];

    public GameObject panelPrefab, svContent;
    // Start is called before the first frame update

    public void WordListInit()
    {
        excuseWordsList = new List<string>() { "犬", "猫", "石川", "矢野", "仲宗根", "加藤", "髙橋", "渡辺", "佐藤", "田中", "堀", "森永", "黒川", "伊藤", "中村" };
    }

    public void CardInstantiate()
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
            GameObject item = Instantiate(panelPrefab);
            Text text = item.GetComponentInChildren<Text>();
            text.text = selectWordsArray[i].ToString();

            //canvasを親要素としてスクロールビューのContentに配置
            item.transform.SetParent(svContent.transform, true);          
        }
    }
}
