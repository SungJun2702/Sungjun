using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //IPointerDownHandler  를 쓰기위해 사용 
using UnityEngine.SceneManagement;

public class Dialloue : MonoBehaviour, IPointerDownHandler
{
    public static Dialloue instance;
    public Text DialogueText;
    public GameObject NextText;
    public CanvasGroup dialogueGroup; //CanvasGroup Alpa 를 사용하기위함

    public Queue<string> sentences; //선입선출 FIFO

    private string currentSentence;

    public float typingSpeed = 1f;
    private float fDestroyTime = 3f;
    private float testtime;
    //private OrtheManager theOrder;
    private bool istyping; //타이핑시 NextSentence 를 호출하면안됨

    // [SerializeField]
    //Image progressBar; 

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
            instance = this;
    }

    void Start()
    {

        sentences = new Queue<string>();
        //StartCoroutine(timeDial());
      //  theOrder = FindObjectOfType<OrtheManager>();
        InvokeRepeating("NextSentence", 3, 3);
      

    }

    public void Ondialougue(string[] lines)
    {
        sentences.Clear();
       
        foreach (string line in lines)
        {
            sentences.Enqueue(line); //큐의 Enqueue(var)메서드로 넣는다
        }
        dialogueGroup.alpha = 1;
        dialogueGroup.blocksRaycasts = true; //blocksRaycasts 가 true 일때는 마우스 이벤트 감지
        NextSentence();
       // theOrder.NotMove();
        // testtime += Time.deltaTime;
    }

    public void NextSentence()
    {
     
        if (sentences.Count != 0)
        {
            //Dequeue() 는 큐에 존재하는 데이터중 가장 먼저들어온 데이터를 반환하고 
            //큐에서 해당데이터를 제거 
            currentSentence = sentences.Dequeue(); //currentSentence라는 string 변수에 큐의 데이터 한개를 넣는다
            istyping = true;
            NextText.SetActive(false);
            StartCoroutine(Typing(currentSentence));
         
        }
        else
        {
            dialogueGroup.alpha = 0;
            dialogueGroup.blocksRaycasts = false;

        }

    }

    IEnumerator Typing(string line)
    {
        DialogueText.text = "";

        //ToCharArray 는 문자열을 Char 형 배열로 변환
        foreach (char letter in line.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        //대사창을 클릭하면 다음 대사로 넘어감 
        if (DialogueText.text.Equals(currentSentence))
        {
            if (testtime >= fDestroyTime)
            {
                NextText.SetActive(true);
                istyping = false;
               //  theOrder.Move();
            }
         
        }

    }

    //IPointerDownHandler 란 인터페이스 상속받음 
    //OnPointerDown 은 해당스크립트가 붙은 오브젝트에 클릭 ,터치가 있을경우호출

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!istyping)
            NextSentence();
    }

    /*
    public Text Text;
    public SpriteRenderer rendererDialogue;

    private List<string> listSentences;
    private List<Sprite> listDialogueWindow;

    private int count; // 대화진행 카운트 

    public Animator animDialogueWindow;

    public bool talking=false;

    private bool keyActivate = false;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        Text.text = "";
        listSentences = new List<string>();
        listDialogueWindow = new List<Sprite>();
    }

    public void ShowDialogue(Dialog dialog)
    {
        talking = true;
        for (int i = 0; i < dialog.sentences.Length; i++)
        {
            listSentences.Add(dialog.sentences[i]);
            listDialogueWindow.Add(dialog.dialogueWindow[i]);
        }
        animDialogueWindow.SetBool("Appar",true);
        StartCoroutine(StartDialogueCoroutine());

    }

    public void ExitDialogue()
    {
        Text.text = "";
        count = 0;
        listSentences.Clear();
        listDialogueWindow.Clear();
        animDialogueWindow.SetBool("Appar", false);
        talking = false;
    }

    IEnumerator StartDialogueCoroutine()
    {
        if (count > 0)
        {
            if (listDialogueWindow[count] != listDialogueWindow[count - 1])
            {
                animDialogueWindow.SetBool("Appar", false);
                yield return new WaitForSeconds(0.2f);
                rendererDialogue.GetComponent<SpriteRenderer>().sprite = listDialogueWindow[count];
                animDialogueWindow.SetBool("Appar", true);
            }
        }
        else
        {
            yield return new WaitForSeconds(0.05f);
            rendererDialogue.GetComponent<SpriteRenderer>().sprite = listDialogueWindow[count];
        }

        keyActivate = true;
        for (int i = 0; i < listSentences[count].Length; i++)
        {
            Text.text += listSentences[count][i];
            yield return new WaitForSeconds(0.01f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (talking && keyActivate)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                keyActivate = false;
                count++;
                Text.text = "";
                if (count == listSentences.Count)
                {
                    StopAllCoroutines();
                    ExitDialogue();
                }
                else
                {
                    StopAllCoroutines();
                    StartCoroutine(StartDialogueCoroutine());
                }
            }
        }
       
    }*/
}

//public SpriteRenderer rendererSprite;
//public List<Sprite> listSprite;
//public Animator animSprite;

//listSprite = new List<Sprite>();

/*
 *  for (int i = 0; i < dialog.sentences.Length; i++)
 *  {
 *  listSprite.Add(dialog.Sprite[i]);
 *  
 *  }
 *  animSprite.SetBool("Appar",true);
 *  
 *  코루틴 안에 
 *  if(listSprite[count]!= listSprite[count-1])
 *  {
 *  animSprite.SetBool("Cahnge",true);
 *  yield return new WaitForSeconds(0.1f);
 *  rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
 *  animSprite.SetBool("Cahnge",flase);
 *  }

 */
