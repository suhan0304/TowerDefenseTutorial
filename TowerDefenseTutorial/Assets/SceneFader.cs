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
    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime; //t�� ������ ���� �ð���ŭ ���� 
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a); //������ a�� ���� (������ animationCurve�� ���� ����)
            yield return 0; //���� ���������� �Ѿ
        }
    }
    IEnumerator FadeOut() //FadeIn �ݴ�� ����
    {
        float t = 0f;

        while (t < 1f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a); 
            yield return 0; 
        }
    }
}
