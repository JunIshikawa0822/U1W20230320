using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScript: MonoBehaviour
{
    public UIScript importUIScript;
    
    // Start is called before the first frame update
    void Start()
    {
        importUIScript.NounWordListInit();
        importUIScript.VerbWordListInit();
        importUIScript.AdjectiveWordsListInit();

        importUIScript.ExcuseTemplateInit();

        importUIScript.NounWordCardsInstantiate();
        importUIScript.VerbWordCardsInstantiate();
        importUIScript.AdjectiveWordCardsInstantiate();

        //importUIScript.WordCardsInstantiate(importUIScript.usableNounWordsArray, importUIScript.excuseNounWordsList);
        //importUIScript.WordCardsInstantiate(importUIScript.usableVerbWordsArray, importUIScript.excuseVerbWordsList);
        //importUIScript.WordCardsInstantiate(importUIScript.usableAdjectiveWordsArray, importUIScript.excuseAdjectiveWordsList);

        importUIScript.ExcuseTemplateInstantiate();

        EventTriggerScript.pickWordsArray = new string[6];
        //Debug.Log(ThemeRandom.index);
    }

    // Update is called once per frame
    void Update()
    {
        importUIScript.SwitcherTextSet(EventTriggerScript.TemplateNumber);
        importUIScript.TemplateDisplaySwitch(EventTriggerScript.isTemplateDisplay);       
    }
}
