using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;

    IEnumerator FadeIn ()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime; //t를 프레임 단위 시간만큼 감소 
            yield return 0; //다음 프레임으로 넘어감
        }
    }
}
