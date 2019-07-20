using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MoveObject
{
    static public PlayerManager instance;

    public string currenMapName; //transferMap 스크립트에 있는 transferMapName 변수의 값을 저장
    private bool canMove = true;
    private bool notCoroutine;
    public Queue<string> queue; //FIFO ,선입선출 자료구조
    public bool notMove = false;

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
    public void Move(string _dir, int _frequency = 5)
    {
        queue.Enqueue(_dir);
        if (!notCoroutine)
        {
            notCoroutine = true;

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    IEnumerator MoveCoroutine()
    {
        while (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0&& !notMove)
        {
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

            if (vector.x != 0)
                vector.y = 0;

            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);

            /* 이동불가 소스 */
            RaycastHit2D hit;

            Vector2 start = transform.position; //캐릭터 현재위치
            Vector2 end = start + new Vector2(vector.x * speed * WalkCount, vector.y * speed * WalkCount); // 캐릭터가 이동하고자하는 위치값

            boxCollider.enabled = false;
            hit = Physics2D.Linecast(start, end, layerMask);
            boxCollider.enabled = true;

            if (hit.transform != null)
                break;
            /* 이동불가 소스 */

            animator.SetBool("Walking", true);


            while (currentWallkCount < WalkCount)
            {
                if (vector.x != 0)
                {
                    transform.Translate(vector.x * speed, 0, 0);
                }
                else if (vector.y != 0)
                {
                    transform.Translate(0, vector.y * speed, 0);

                }
                currentWallkCount++;
                yield return new WaitForSeconds(0.01f);
            }
            currentWallkCount = 0;

        }
        animator.SetBool("Walking", false);
        canMove = true;

        boxCollider.offset = new Vector2(vector.x * 0.7f * speed * WalkCount, vector.y * 0.7f * speed * WalkCount);

        /*
        while (currentWallkCount < WalkCount)
        {
            transform.Translate(vector.x * speed, vector.y * speed, 0); //캐릭터 움직임 
            currentWallkCount++;
            // NPC 의 박스콜라이더가 움직이고 12픽셀쯤 갔을때 다시 원래대로 돌아옴
            if (currentWallkCount == WalkCount * 0.5f + 2)
                boxCollider.offset = Vector2.zero;
            yield return new WaitForSeconds(0.01f); //1초 멈춤
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && !notMove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }
        }

    }

    /*
    protected bool CheckCollsion()
    {
        RaycastHit2D hit;
        //A지점 -> B 지점 레이저 발사
        // hit=null (성공)
        // hit=방해물(실패),즉 충돌
        Vector2 start = transform.position; // A지점,캐릭터의 현재위치값
        Vector2 end = start + new Vector2(vector.x * speed * WalkCount, vector.y * speed * WalkCount);// B지점, 캐릭터가 이동하고자 하는 위치값

        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, layerMask);//레이저 발사
        boxCollider.enabled = true;

        if (hit.transform != null)
            return true; //앞에 물체가있다 true 반환
        return false; //앞에 물체가 없다 false 반환
    }
    */
}