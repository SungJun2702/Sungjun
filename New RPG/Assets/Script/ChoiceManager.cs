using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    public static ChoiceManager instance;

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

    private string quesion;//choice 에있는 quesion 를담는다
    private List<string> answerList;//choice 에있는 answerList 를담는다

    public GameObject go; // 평소 비활성화 시킬 목적으로 선언 .setActive

    public Text question_Text;
    public Text[] answer_Text;

    public GameObject[] answer_Panel; //선택된 오브젝트

    public Animator anim;

    public bool choiceing; // 대기 ()=>!choiceing
    private bool keyInput; // 키처리 활성화 비 활성화

    private int count; //배열의 크기 
    private int result; //선택한 결과창

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);
    // Start is called before the first frame update
    void Start()
    {
        answerList = new List<string>();
        for (int i = 0; i < answer_Text.Length; i++)
        {
            answer_Text[i].text = "";
            answer_Panel[i].SetActive(false);
        }
        question_Text.text = "";
    }

    public void ShowChoice(Choice _choiece)
    {
        choiceing = true;
        go.SetActive(true);
        result = 0;
        quesion = _choiece.question;
        for (int i = 0; i < _choiece.answers.Length; i++)
        {
            answerList.Add(_choiece.answers[i]);
            answer_Panel[i].SetActive(true);
            count = i;
        }
        anim.SetBool("Appear", true);
        Selection();
        StartCoroutine(ChoiceCorountine());
    }

    //결정된 것을 반환
    public int GetResult()
    {
        return result;
        //go.setActive(flase); 도 가능
    }

    public void ExitChoice()
    {
        question_Text.text = "";
        answerList.Clear();
        for (int i = 0; i <= count; i++)
        {
            answer_Text[i].text = "";
            answer_Panel[i].SetActive(false);
        }
      
        anim.SetBool("Appear", false);
        choiceing = false;
        go.SetActive(false);

    }

    IEnumerator ChoiceCorountine()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(TypingQuestion());
        StartCoroutine(TypingAnswer_0());
        if (count >= 1)
            StartCoroutine(TypingAnswer_1());

        yield return new WaitForSeconds(0.5f);
        keyInput = true;
    }

    // for 문 을 이용하여 질문 을 한글자씩 출력
    IEnumerator TypingQuestion()
    {
        for (int i = 0; i < quesion.Length; i++)
        {
            question_Text.text += quesion[i];
            yield return waitTime;
        }
    }

    // Typing 코루틴 을 계속 만드는 이유 
    // 동시에 질문과 대답 (1~2) 텍스트를 출력하기때문에
    // 코루틴을 계속해서 추가 
    //하나의 코루틴으로 하나씩 출력하고싶으면 
    // 그 코루틴에 파라미터로 넘겨주면 된다.
    IEnumerator TypingAnswer_0()
    {
        yield return new WaitForSeconds(0.4f);
        for (int i = 0; i < answerList[0].Length; i++)
        {
            answer_Text[0].text += answerList[0][i];
            yield return waitTime;
        }
    }
    IEnumerator TypingAnswer_1()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < answerList[1].Length; i++)
        {
            answer_Text[1].text += answerList[1][i];
            yield return waitTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (keyInput)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (result > 0)
                        result--;
                    else
                        result = count;
                    Selection();
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (result < count)
                        result++;
                    else
                        result = 0;
                    Selection();
                }
                else if (Input.GetKeyDown(KeyCode.Z))
                {
                    keyInput = false;
                    ExitChoice();
                }
            }
        }
      
    }

    public void Selection()
    {
        //전체적인 투명도를 줌
        Color color = answer_Panel[0].GetComponent<Image>().color;
        color.a = 0.75f;
        for (int i = 0; i <= count; i++)
        {
            answer_Panel[i].GetComponent<Image>().color = color;
        }
        //선택된 것만 color 로 표시함
        color.a=1f;
        answer_Panel[result].GetComponent<Image>().color = color;
    }
}
