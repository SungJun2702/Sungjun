using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSentencsd : MonoBehaviour
{
    public static NPCSentencsd instance;


    [TextArea(1, 2)]
    public string[] sentences;

 
    /*
        private void Awake()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(this.gameObject);
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
      */
    private void OnMouseDown()
    {
        if (Dialloue.instance.dialogueGroup.alpha == 0)
        {
            Dialloue.instance.Ondialougue(sentences);
       
        }
     

    }
}
