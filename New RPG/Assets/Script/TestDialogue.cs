using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    [SerializeField]
    public Dialog dialog;

    private DialogManager theDM;


    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //theDM.ShowDialogue(dialog);
        }
    }
}
