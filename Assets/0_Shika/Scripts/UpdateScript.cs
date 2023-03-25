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
    }

    // Update is called once per frame
    void Update()
    {
        importUIScript.SwitcherTextSet(EventTriggerScript.TemplateNumber);
        importUIScript.TemplateDisplaySwitch(EventTriggerScript.isTemplateDisplay);

        importUIScript.ExcuseWords();

        //Debug.Log(EventTriggerScript.TemplateNumber);
        if(EventTriggerScript.TemplateNumber == 0)
        {
            Debug.Log
                (importUIScript.pickWordsArray[0] + " , "
                +  importUIScript.pickWordsArray[1] + " , "
                + importUIScript.pickWordsArray[2]);
        }        
    }
}
