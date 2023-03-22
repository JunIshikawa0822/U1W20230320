using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScript: MonoBehaviour
{
    public UIScript importUIScript;
    // Start is called before the first frame update
    void Start()
    {
        importUIScript.WordListInit();
        importUIScript.ExcuseTemplateInit();

        importUIScript.WordCardsInstantiate();
        importUIScript.ExcuseTemplateInstantiate();
    }

    // Update is called once per frame
    void Update()
    {
        importUIScript.ExcuseWords();

        Debug.Log(EventTriggerScript.TemplateNumber);
        if(EventTriggerScript.TemplateNumber == 0)
        {
            Debug.Log(importUIScript.pickWordsArray[0] + "が" + importUIScript.pickWordsArray[1] + "だから");
        }        
    }
}
