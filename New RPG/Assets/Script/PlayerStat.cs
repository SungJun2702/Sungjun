using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat instance;

    public int character_Lv;
    public int[] needExp;// 레벨업 경험치
    public int Exp;
    public int currentExp; //현재경험치

    public int hp;
    public int currentHP;
    public int mp;
    public int currentMP;

    public Slider hpSlider;
    public Slider mpSlider;
    public Slider ExpSlider;

    [SerializeField]
    public Text hpText;

    [SerializeField]
    public Text mpText;

    [SerializeField]
    private Text LvText;
    
    public int atk;
    public int def;

    [SerializeField]
    public Text JobText;

    // public Animator LvEffectAnim;

    //public GameObject prefabs_Floating_text; // 대미지를입었을때 나오는 텍스트
    //public GameObject parent;
    public GameObject effect;
    // Start is called before the first frame update

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
        //instance = this;
    }

    void Start()
    {
        instance = this;
        currentHP = hp;
        currentMP = mp;
        currentExp = Exp;
    }

    public void Hit(int _enemyAtk)
    {
        int dmg;
        if (def >= _enemyAtk)
            dmg = 1;
        else
            dmg = _enemyAtk - def;

        currentHP -= dmg;
        if (currentHP <= 0)
            Debug.Log("체력 0미만, 게임오버");

        //플로팅 텍스트 
        //Vector3 vector = this.transform.position;
        //Instantiate(effect, vector, Quaternion.Euler(Vector3.zero));
        //vector.y += 60;

        // GameObject clone = Instantiate(prefabs_Floating_text, vector, Quaternion.Euler(Vector3.zero));
        // clone.GetComponent<FloatingText>().text.text = dmg.ToString();
        // clone.GetComponent<FloatingText>().text.color = Color.red;
        // clone.GetComponent<FloatingText>().text.fontSize = 25;
        // clone.transform.SetParent(parent.transform);
        // StopAllCoroutines();
        // StartCoroutine(HitCoroutine());
    }

    /*
    IEnumerator HitCoroutine()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        color.a = 0;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 1f;

        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 0f;

        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 1f;

        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 0f;

        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 1f;
        GetComponent<SpriteRenderer>().color = color;
    }*/

    // Update is called once per frame
    void Update()
    {

        hpSlider.maxValue = hp;
        mpSlider.maxValue = mp;
        ExpSlider.maxValue = Exp;

        hpSlider.value = currentHP;
        mpSlider.value = currentMP;
        ExpSlider.value = currentExp;

        hpText.text = currentHP + " / " + hp;
        mpText.text = currentMP + " / " + mp;

        if (currentExp >= needExp[character_Lv])
        {
            LvText.text += character_Lv;

            // 나중에 몬스터 만들어서 래벨업시 동작하는지 확인해보기 
            // 레벨업 이펙트 
            Vector3 vector2 = this.transform.position;
            Instantiate(effect, vector2, Quaternion.Euler(Vector3.zero));
            vector2.y += 10;
            currentExp = Exp;
            
            hp += character_Lv * 2;
            mp += character_Lv * 2;

            currentHP = hp;
            currentMP = mp;

            atk++;
            def++;
        }
    }
}
