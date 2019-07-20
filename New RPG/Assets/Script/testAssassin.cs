using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class testAssassin : MonoBehaviour
{
    private PlayerStat theStat;
    private Dialloue thedialloue;
   
   // private FlotingText theFloat;
    public GameObject gmAssasin;
    private string JOB_Assasin = "도적";
   // public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        thedialloue = FindObjectOfType<Dialloue>();
        theStat = FindObjectOfType<PlayerStat>();
       // theFloat = FindObjectOfType<FlotingText>();
        // GameObject gm = GameObject.Find("Npc_Assassin");
        gmAssasin = GameObject.FindObjectOfType<GameObject>();
    }

    public void Assasin()
    {
        theStat.JobText.text = JOB_Assasin;
        theStat.hp = 180;
        theStat.mp = 160;
        theStat.atk = 28;
        theStat.def = 27;
        theStat.currentHP = theStat.hp;
        theStat.currentMP = theStat.mp;
        theStat.hpText.text = theStat.currentHP + " / " + theStat.hp;
        theStat.mpText.text = theStat.currentMP + " / " + theStat.mp;
    }

    /*
    private void AssasinClick()
    {

        
    }
    */

    // Update is called once per frame


    void Update()
    {
        StartCoroutine(TestCoroutine());
    }

    //IPointerDownHandler 란 인터페이스 상속받음 
    //OnPointerDown 은 해당스크립트가 붙은 오브젝트에 클릭 ,터치가 있을경우호출
    /*
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Npc_Assassin")
        {
            Assasin();
            enabled = false;
        }
    }
    */
    IEnumerator TestCoroutine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            thedialloue.NextSentence();
            if (gameObject.name == "Npc_Assassin")
            {
                Assasin();
               //Instantiate(effect,vector, Quaternion.Euler(Vector3.zero));
               // Debug.Log("dd");
            }
            yield return new WaitForFixedUpdate();
        }
    }
       

}
