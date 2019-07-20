using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrtheManager : MonoBehaviour
{
    private PlayerManager thePlayer;
    private List<MoveObject> characters;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
    }

    public void PreLoadCharacter()
    {
        characters = ToList();
    }
    public List<MoveObject> ToList()
    {
        List<MoveObject> tempList = new List<MoveObject>();
        MoveObject[] temp = FindObjectsOfType<MoveObject>();

        for (int i = 0; i < temp.Length; i++)
        {
            tempList.Add(temp[i]);
        }
        return tempList;
    }

    public void NotMove()
    {
        thePlayer.notMove = true;
    }
    public void Move()
    {
        thePlayer.notMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
