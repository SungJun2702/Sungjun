using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaidManager : MonoBehaviour
{
    private DialogManager theDial;
    public Image Panel;
    float time = 0f; //0~1 까지 deltaTime 을 계속더해서 지속시간으로 사용
    float F_time = 1f; //몇초간 지속되는지 설정 하는 값

   
    public void Fade()
    {
        theDial = FindObjectOfType<DialogManager>();

        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            //매 프레임 deltatime  을 F_time 으로 나눈값을 time에 더해준다
            time += Time.deltaTime / F_time;

            //Mathf.lerp 를 써서 0부터 1까지 부드럽게 변하게 만들어준다
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;
        yield return new WaitForSeconds(1f);
        while (alpha.a > 0f)
        {
            //매 프레임 deltatitme  을 F_time 으로 나눈값을 time에 더해준다
            time += Time.deltaTime / F_time;

            //Mathf.lerp 를 써서 0부터 1까지 부드럽게 변하게 만들어준다
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }
}
