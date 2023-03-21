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
        importUIScript.CardInstantiate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
