using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class JobManager : MonoBehaviour
{

    private PlayerStat theStat;
    private Dialloue thedialloue;
    private string JOB_Knight = "전사";
    private string JOB_Archer = "궁수";
    private string JOB_Assasin = "도적";
   //int tPlayer;
    public GameObject Npc_Warrior;
    public GameObject Npc_Assasin;
    public GameObject Npc_Archer;


    private void Start()
    {
        theStat = FindObjectOfType<PlayerStat>();
        //theStat = GetComponent<PlayerStat>();
        thedialloue = FindObjectOfType<Dialloue>();

    }

    public void KnightStat()
    {
        theStat.JobText.text = JOB_Knight;
        theStat.hp = 260;
        theStat.mp = 100;
        theStat.atk = 30;
        theStat.def = 35;
        theStat.currentHP = theStat.hp;
        theStat.currentMP = theStat.mp;
        theStat.hpText.text = theStat.currentHP + " / " + theStat.hp;
        theStat.mpText.text = theStat.currentMP + " / " + theStat.mp;
    }
    public void ArcherStat()
    {
        theStat.JobText.text = JOB_Archer;
        theStat.hp = 150;
        theStat.mp = 150;
        theStat.atk = 25;
        theStat.def = 20;
        theStat. currentHP = theStat.hp;
        theStat. currentMP = theStat.mp;
        theStat. hpText.text = theStat.currentHP + " / " + theStat.hp;
        theStat.mpText.text = theStat.currentMP + " / " + theStat.mp;
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
    
  
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == GameObject.FindWithTag("Warrior"))
        {
            KnightStat();
        }
        else if (Input.GetMouseButtonDown(0) == GameObject.FindWithTag("Archer"))
        {
            ArcherStat();
        }
        else if (Input.GetMouseButtonDown(0) == GameObject.FindWithTag("Assassin"))
        {
            Assasin();
        }
    }

}
/*
       if (Input.GetMouseButtonDown(0))
       {
           CastRay();
           if (Npc_Warrior.Equals(gameObject))
           {
               KnightStat();
               Debug.Log("전사");
           }
       }
       */

/*
   void CastRay()
   {
       Npc_Warrior = null;
       Npc_Archer = null;
       Npc_thief = null;

       Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);


       if (hit.collider != null)
       { //히트되었다면 여기서 실행

          // Debug.Log (hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나옵니다. 

           Npc_Warrior = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
           Npc_Archer = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
           Npc_thief = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정

       }


   }
   */


/*
public void Job_Select()
{
   if (Input.GetMouseButtonDown(0))
   {
       //CastRay();
       if (Npc_Warrior == this.gameObject)
       { 
         //  theStat.JobText.text = JOB_Knight;
           KnightStat();

       }
       else if (Npc_Archer == this.gameObject)
       {
           //theStat.JobText.text = JOB_Archer;
           ArcherStat();

       }
       else if (Npc_thief == this.gameObject)
       {
           //theStat.JobText.text = JOB_Theif;
           TheifStat();
       }
   }



}


public void OnPointerDown(PointerEventData eventData)
{
   if (Npc_Warrior == this.gameObject)
   {
       //  theStat.JobText.text = JOB_Knight;
       KnightStat();
       Debug.Log("전사");
   }
}
*/
