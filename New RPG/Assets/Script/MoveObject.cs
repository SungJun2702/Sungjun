using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public LayerMask layerMask; //통과불가능 판단 레이어 

    public float speed; //캐릭터 스피드 
    protected Vector3 vector;
    public int WalkCount;
    protected int currentWallkCount;
    public Animator animator;
}

