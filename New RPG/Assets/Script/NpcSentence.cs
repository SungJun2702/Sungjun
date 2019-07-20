using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NpcSentence : MonoBehaviour
{
   //public static NpcSentence instance;
    [TextArea(1, 2)]
    public string[] sentences;
   
  
    private void OnMouseDown()
    {
        if (DialogManager.instance.dialogueGroup.alpha == 0)
        {
            DialogManager.instance.Ondialougue(sentences);

        }

    }
}
   
   

