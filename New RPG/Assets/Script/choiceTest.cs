using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choiceTest : MonoBehaviour
{
    [SerializeField]
    public Choice choice;
    private ChoiceManager theChoice;
    private OrtheManager theorder;
    public bool flag;
    // Start is called before the first frame update
    void Start()
    {
        theChoice = FindObjectOfType<ChoiceManager>();
        theorder = FindObjectOfType<OrtheManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!flag)
        {
            StartCoroutine(ACotoutine());
        }
    }
    IEnumerator ACotoutine()
    {
        flag = true;
        theorder.NotMove();
        theChoice.ShowChoice(choice);
        yield return new WaitUntil(() => theChoice.choiceing);
        theorder.Move();
        Debug.Log(theChoice.GetResult());
    }

}
