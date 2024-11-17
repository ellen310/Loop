using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlowChartBtnManager : MonoBehaviour
{
    public Text toastMessage;
    public float fadeInOutTime = 0.3f;
    public GameObject[] activateImage;

    private void Start()
    {
        for (int i = 0; i < GameManager.I.isVisit.Length; i++)
        {
            if (GameManager.I.isVisit[i]) //해당씬 방문했다면 활성화된 이미지를 띄움
            {
                activateImage[i].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1); //.SetActive(true);
            }
        }
    }
    
    // 엔딩 모아보기2 버튼
    public void BtnScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void BtnScene2()
    {
        if (GameManager.I.isVisit[1])
        {
            SceneManager.LoadScene("Scene2");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }        
    }

    public void BtnBranch1A()
    {
        if (GameManager.I.isVisit[2])
        {
            SceneManager.LoadScene("Branch1A");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch1B()
    {
        if (GameManager.I.isVisit[3])
        {
            SceneManager.LoadScene("Branch1B_CastAway");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch2A()
    {
        if (GameManager.I.isVisit[4])
        {
            SceneManager.LoadScene("Branch2A_Nirvana");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch2B()
    {
        if (GameManager.I.isVisit[5])
        {
            SceneManager.LoadScene("Branch2B");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }



    public void BtnBranch3A()
    {
        if (GameManager.I.isVisit[6])
        {
            SceneManager.LoadScene("Branch3A_ExpectedEnding");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch3B()
    {
        if (GameManager.I.isVisit[7])
        {
            SceneManager.LoadScene("Branch3B");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch4A()
    {
        if (GameManager.I.isVisit[8])
        {
            SceneManager.LoadScene("Branch4A");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch4B()
    {
        if (GameManager.I.isVisit[9])
        {
            SceneManager.LoadScene("Branch4B_FlyMeToTheMoon");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch5A()
    {
        if (GameManager.I.isVisit[10])
        {
            SceneManager.LoadScene("Branch5A");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch5B()
    {
        if (GameManager.I.isVisit[11])
        {
            SceneManager.LoadScene("Branch5B_LastChance");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnScene5()
    {
        if (GameManager.I.isVisit[12])
        {
            SceneManager.LoadScene("Scene5");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch6A()
    {
        if (GameManager.I.isVisit[13])
        {
            SceneManager.LoadScene("Branch6A");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch6B()
    {
        if (GameManager.I.isVisit[14])
        {
            SceneManager.LoadScene("Branch6B_Cliche");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch7A()
    {
        if (GameManager.I.isVisit[15])
        {
            SceneManager.LoadScene("Branch7A");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch7B()
    {
        if (GameManager.I.isVisit[16])
        {
            SceneManager.LoadScene("Branch7B");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch7C()
    {
        if (GameManager.I.isVisit[17])
        {
            SceneManager.LoadScene("Branch7C_Sisyphus");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch7AB()
    {
        if (GameManager.I.isVisit[18])
        {
            SceneManager.LoadScene("Branch7AB_EmilSinclair");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch7C_2()
    {
        if (GameManager.I.isVisit[19])
        {
            SceneManager.LoadScene("Branch7C_Sisyphus");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }

    public void BtnBranch7BB()
    {
        if (GameManager.I.isVisit[20])
        {
            SceneManager.LoadScene("Branch7BB_LifeIsButADream");
        }
        else
        {
            StartCoroutine(showMessageCoroutine(1.0f));
        }
    }


    IEnumerator ToastMessageFade(Text toastMessage, float durationTime, bool inOut)
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

    private IEnumerator showMessageCoroutine(float durationTime)
    {
        Color originalColor = toastMessage.color;
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
