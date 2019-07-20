using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;
    public GameObject target; //카메라가 따라갈 대상
    public float moveSpeed; // 카메라가 얼마나 빠른속도로 대상을 따라가냐 
    private Vector3 targetPosition; //대상의 현재 위치값
    
    public BoxCollider2D bound;
    private Vector3 minbound;
    private Vector3 maxbound;
    //박스 콜라이더 영역의 최소 최대 xyz값을 지님 

    private float halfWidth; //카메라의 반너비
    private float halfHeight; //카메라의 반높이

    private Camera theCamera; //카메라의 반높이 값을 구할 속성을 이용하기위함

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        theCamera = GetComponent<Camera>();
        minbound = bound.bounds.min;
        maxbound = bound.bounds.max;
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            // 1초에 무브스피드 만큼 이동
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            float clampedX = Mathf.Clamp(this.transform.position.x, minbound.x + halfWidth, maxbound.x - halfWidth);
            float clampedY = Mathf.Clamp(this.transform.position.y, minbound.y + halfHeight, maxbound.y - halfHeight);

            this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);

        }
    }

    public void SetBound(BoxCollider2D newBound)
    {
        bound = newBound;
        minbound = bound.bounds.min;
        maxbound = bound.bounds.max;
    }
}
