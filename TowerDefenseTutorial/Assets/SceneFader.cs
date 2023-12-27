using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn ()
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
}
