using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class testKnight : MonoBehaviour
{
    private PlayerStat theStat;
    private Dialloue thedialloue;
    public GameObject Npc_Warrior;
    private string JOB_Knight = "전사";
    // Start is called before the first frame update
    void Start()
    {
        theStat = FindObjectOfType<PlayerStat>();
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

    void Update()
    {
        StartCoroutine(WarriorCoroutine());
    }
    IEnumerator WarriorCoroutine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.name == "Npc_Warrior")
            {
                KnightStat();
                Debug.Log("dd");
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
