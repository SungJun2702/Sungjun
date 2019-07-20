using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testArcher : MonoBehaviour
{
    private PlayerStat theStat;
    private Dialloue thedialloue;
    public GameObject Npc_Archer;
    private string JOB_Archer = "궁수";
    // Start is called before the first frame update
    void Start()
    {
        thedialloue = FindObjectOfType<Dialloue>();
        theStat = FindObjectOfType<PlayerStat>();
      
    }
    public void ArcherStat()
    {
        theStat.JobText.text = JOB_Archer;
        theStat.hp = 150;
        theStat.mp = 150;
        theStat.atk = 25;
        theStat.def = 20;
        theStat.currentHP = theStat.hp;
        theStat.currentMP = theStat.mp;
        theStat.hpText.text = theStat.currentHP + " / " + theStat.hp;
        theStat.mpText.text = theStat.currentMP + " / " + theStat.mp;
    }

    /*
    private void ArcherClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.Find("Npc_Archer"))
            {
                ArcherStat();
            }
        }
    }
    */
    // Update is called once per frame
    
    void Update()
    {
        StartCoroutine(ArcherCoroutine());
    }

    IEnumerator ArcherCoroutine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.name == "Npc_Archer")
            {
                ArcherStat();
                Debug.Log("dd");
            }
            yield return new WaitForFixedUpdate();
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (collision.gameObject.name == "Npc_Archer")
            {
                ArcherStat();
            }
        }
    }
    */
    /*
           Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           Ray2D ray = new Ray2D(touch, Vector2.zero);
           RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

           if (hit.collider != null)
               Debug.Log(hit.collider.name);
           /*
           if(this.gameObject.name == "Npc_Archer")
           {
               ArcherStat();
           }
           */

}
