using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    private void Start() //시작 시에 자동으로 FadeIn 효과 한번 실행
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene) //특정 씬으로 넘어가는 함수
    {
        StartCoroutine(FadeOut(scene));

    }
    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime; //t를 프레임 단위 시간만큼 감소 
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a); //투명도를 a로 설정 (투명도가 animationCurve를 따라 감소)
            yield return 0; //다음 프레임으로 넘어감
        }
    }
    IEnumerator FadeOut(string scene) //FadeIn 반대로 설정
    {
        float t = 0f;

        while (t < 1f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a); 
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
