using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndingChartBtnManager : MonoBehaviour
{
    public TMP_Text toastMessage;
    public GameObject[]endingHideImage;
    public float fadeInOutTime = 0.3f;
    public string[] endingExplain;
    
   
    private void Start()
    {
        for (int i = 0; i < GameManager.I.ending.Length; i++)
        {
            if (GameManager.I.ending[i]) //해당씬 방문했다면 까만이미지(비활 이미지) 지움
            {
                endingHideImage[i].SetActive(false);
            }
        }
    }

    
    // 엔딩 모아보기1 버튼
    public void BtnEnding1()
    {
        if (GameManager.I.ending[0])
        {
            StartCoroutine(showMessageCoroutine(endingExplain[0],1.0f));
        }
    }

    public void BtnEnding2()
    {
        if (GameManager.I.ending[1]) 
        {
            StartCoroutine(showMessageCoroutine(endingExplain[1], 1.0f));
        }
    }

    public void BtnEnding3()
    {
        if (GameManager.I.ending[2])
        {
            StartCoroutine(showMessageCoroutine(endingExplain[2], 1.0f));
        }
    }

    public void BtnEnding4()
    {
        if (GameManager.I.ending[3])
        {
            StartCoroutine(showMessageCoroutine(endingExplain[3], 1.0f));
        }
    }


    public void BtnEnding5()
    {
        if (GameManager.I.ending[4])
        {
            StartCoroutine(showMessageCoroutine(endingExplain[4], 1.0f));
        }
    }

    public void BtnEnding6()
    {
        if (GameManager.I.ending[5])
        {
            StartCoroutine(showMessageCoroutine(endingExplain[5], 1.0f));
        }
    }

    public void BtnEnding7()
    {
        if (GameManager.I.ending[6])
        {
            StartCoroutine(showMessageCoroutine(endingExplain[6], 1.0f));
        }
    }

    public void BtnEnding8()
    {
        if (GameManager.I.ending[7])
        {
            StartCoroutine(showMessageCoroutine(endingExplain[7], 1.0f));
        }
    }

    public void BtnEnding9()
    {
        if (GameManager.I.ending[8])
        {
            StartCoroutine(showMessageCoroutine(endingExplain[8], 1.0f));
        }
    }


    IEnumerator ToastMessageFade(TMP_Text toastMessage, float durationTime, bool inOut)
    {
        float start, end;
        if (inOut)
        {
            start = 0.0f;
            end = 1.0f;
        }
        else
        {
            start = 1.0f;
            end = 0f;
        }

        Color current = Color.white;
        float elapsedTime = 0.0f;

        while (elapsedTime < durationTime)
        {
            float alpha = Mathf.Lerp(start, end, elapsedTime / durationTime);

            toastMessage.color = new Color(current.r, current.g, current.b, alpha);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

    }

    private IEnumerator showMessageCoroutine(string msg, float durationTime)
    {
        Color32 originalColor = toastMessage.color;
        toastMessage.text = msg;
        toastMessage.enabled = true;

        yield return ToastMessageFade(toastMessage, fadeInOutTime, true);

        float elapsedTime = 0.0f;
        while (elapsedTime < durationTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return ToastMessageFade(toastMessage, fadeInOutTime, false);

        toastMessage.enabled = false;
        toastMessage.color = originalColor;
    }
}
