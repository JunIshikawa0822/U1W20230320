using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    List<string> excuseNounWordsList = new List<string>();
    List<string> excuseVerbWordsList = new List<string>();
    List<string> excuseAdjectiveWordsList = new List<string>();

    List<string> excuseTemplatesList = new List<string>();
    List<string> themeList = new List<string>();

    string[] usableNounWordsArray = new string[5];
    string[] usableVerbWordsArray = new string[5];
    string[] usableAdjectiveWordsArray = new string[5];

    //public string[] pickWordsArray;

    //public GameObject[] templateArray;

    public GameObject[] PartofSpeechPanelArray = new GameObject[3];
    public GameObject[] StartPanelArray = new GameObject[3];

    public GameObject excusePanelPrefab, exTemplateContent, TemplateDisplayswitcher, exTemplateScrollView;
    
    // Start is called before the first frame update

    public void NounWordListInit()
    {
        excuseNounWordsList = new List<string>()
        {
            "僕", "お母さん", "彼女", "犬", "おじいさん", "おばあさん", 
            "ご飯", "ゲーム機", "お茶", "スマホ", "コップ",
            "定期券", "お金", "新聞", "風邪", "熱", "病気", "電車", "信号",
            "道路", "車", "バス", "タクシー", "バイク", "自転車", "踏切", "フェリー",
            "交差点", "ブレーキ", "パトカー", "バス停", "乗り換え", "自動運転", "トンネル",
            "橋","田んぼ","溝","信号無視","一時停止","交通規制","煽り運転","運転見合わせ",
            "駅前","駅ビル","レンタカー","リツイート","ジャンクフード","インフルエンサー",
            "第二種電気工事士","タスク","フィットネスジム", "ビッグデータ", "秘書", "着ぐるみ",
            "タコス","トラック","写生大会", "寿司","椅子","先輩","のど飴","廿日市市","ワンタイムパスワード",
            "時間","学校","映画","旅行","お菓子","色","健康","政治家","街頭演説","ティッシュ配り",
            "バンジージャンプ","ハイジャック","新規事業開発", "就活", "研究", "教授", "蛾"
        };
    }

    public void VerbWordListInit()
    {
        excuseVerbWordsList = new List<string>()
        {
            "走っ", "壊し", "無視し", "拾っ",
            "投げ", "座っ", "持っ", "倒し",
            "寝", "見", "買っ", "調べ", "こぼし", "逃げ",
            "忘れ", "聞い", "のぞい", "巻き込まれ",
            "かかっ", "冷え", "終わっ", "変わっ", "負け",
            "助け", "壊れ", "損ね", "逃し", "燃え", "揺れ",
         　  "捕まっ", "絡まれ", "怯え", "傷つい", "ぶつけ",
            "驚い", "なっ", "し", "見てい", "出会っ", "遅れ", "失っ"
        };
    }

    public void AdjectiveWordsListInit()
    {
        excuseAdjectiveWordsList = new List<string>()
        {
            "可愛い", "忙しい", "危ない", "怪しい", "痛い",
            "いやらしい", "胡散臭い", "薄い", "疑わしい", "うまい",
            "うるさい", "大きな", "おかしい", "おそい", "恐ろしい",
            "重たい", "かたい", "かゆい", "汚い", "きわどい",
            "臭い", "くらい", "けばけばしい", "けわしい", "怖い", "寒い",
            "しつこい", "ずるい", "せこい", "せまい", "高い", "だるい", "ちなまぐさい",
            "つまらない", "つらい", "とうとい", "とんでもない", "ない", "ながい", "ながったらしい",
            "貴重な", "古い", 
        };
    }

    public void ExcuseTemplateInit()
    {
        excuseTemplatesList = new List<string>()
        {
            "「名詞」が「形容詞」「名詞」に「動詞」たから",
            "「名詞」が「名詞」のような「形容詞」「名詞」に「動詞」たから",
            "「名詞」に「動詞」ていたら「名詞」が「名詞」に「動詞」たから",
            "「形容詞」「名詞」が「動詞」て「名詞」が「動詞」たから",
            "「名詞」が「形容詞」から「名詞」が「形容詞」「名詞」を「動詞」たから",
            "「名詞」を「動詞」ながら「形容詞」「名詞」を「動詞」たから",
            "「形容詞」「名詞」が「動詞」たら「形容詞」「名詞」が「動詞」たから"
        };
        //templateArray = new GameObject[excuseTemplatesList.Count];
    }

    public void ThemeInit()
    {
        themeList = new List<string>()
        {　
            "会社の重要な会議に出られなかった！！　上司に怒られる！！",
            "隣の家のおばさんのねこを踏んじゃった！！　おばさんに怒られる！！",          
            "今日までの宿題ができてない！！　先生に怒られる！！",
            "大学院を卒業するための研究が全く進んでいない！！　教授に怒られる！！",
            "成績が下がってしまった！！　お母さんに怒られる！！",
            "交際相手に浮気がばれてしまった！！　交際相手に怒られる！！",
            "割り勘なのに所持金が足りない！！　友達に怒られる！！",
            "エーミールが大事にしている貴重な蛾を潰してしまった！！　エーミールに怒られる！！"
        };
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

            //スクロールビューのContentに配置
            item.transform.SetParent(exTemplateContent.transform, true);
        }
    }

    public void SwitcherTextSet(int number)
    {
        Text text = TemplateDisplayswitcher.GetComponentInChildren<Text>();
        text.text = excuseTemplatesList[number].ToString();
    }

    public void TemplateDisplaySwitch(bool istemplate)
    {
        if (istemplate)
        {
            exTemplateScrollView.SetActive(true);
        }
        else
        {
            exTemplateScrollView.SetActive(false);
        }
    }

    public void WordCardsInstantiate(string[] arrayName, List<string> listName, int number)
    {
        for (int i = 0; i < arrayName.Length; i++)
        {
            //excuseWordsListからランダムに一つを取得してusableWordsArrayに入れる
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
