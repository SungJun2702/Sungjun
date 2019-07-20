using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCMove
{
    [Tooltip("NPC움직임")]
    public bool NPCmove;

    public string[] direction; // npc 움직일 방향

    [Range(1,5)]
    public int freequency; 
}

public class NPCManager : MonoBehaviour
{
    [SerializeField]
    public NPCMove npc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetMove()
    {

    }

    public void SetNotMove()
    {

    }
}
