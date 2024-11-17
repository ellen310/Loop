using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public GameObject video;
    public TMP_Text optionBtn1, optionBtn2;
    public Animation backGroundUp;
    public float time;
    public Slider slTimer;
    public bool isVideoEnd, isClickedBack;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.I.isVisit[0] = true;

        if (GameObject.Find("Video Player") != null)
        {
            video = GameObject.Find("Video Player");

        }

        if (GameObject.Find("BranchImage") != null)
        {
            backGroundUp = GameObject.Find("BranchImage").GetComponent<Animation>();
            slTimer = GameObject.Find("BranchImage").transform.Find("Slider").GetComponent<Slider>();
        }
    }

    private void Update()
    {
        if (video != null && SceneManager.GetActiveScene().name != "Main")
        {
            if (video.GetComponent<VideoPlayer>().length - 10 <= video.GetComponent<VideoPlayer>().time)
            {
                if (!isVideoEnd)
                {
                    if (backGroundUp != null)
                    {
                        backGroundUp.Play();
                    }
                    else
                    {
                            Invoke("endingSceneMove", 10f);
                    }
                }
                StartCoroutine(AppearBtn());
            }

            if (!isVideoEnd)
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow))
                {
                    video.GetComponent<VideoPlayer>().time = video.GetComponent<VideoPlayer>().time - 10;
                }
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
                {
                    video.GetComponent<VideoPlayer>().time = video.GetComponent<VideoPlayer>().time + 10;
                }
            }
        }
        
        
        //�Ѱ����� ��,�쿡 <<�̳� >> �� ���UI���� ǥ�õǰ� �߰��ϸ� ���� ��.
    }

    void endingSceneMove()
    {

        SceneManager.LoadScene("State");
    }


    //�б��� Ÿ�̸�
    IEnumerator AppearBtn()
    {
        isVideoEnd = true;
        yield return new WaitForSeconds(1.5f);

        if(slTimer != null)
        {

            if (time < 3f)
            {
                if (optionBtn1 != null)
                    optionBtn1.color = new Color(1, 1, 1, time / 3);
                if (optionBtn2 != null)
                    optionBtn2.color = new Color(1, 1, 1, time / 3);
            }
            time += Time.deltaTime;

            if (slTimer.value < 1.0f)
            {
                slTimer.value += Time.deltaTime / 10.0f;
            }

            //�б��� ���� �ð����� ������ ������� 
            if (slTimer.value == 1.0f) //�ش� ������ �б��� ���� ��ư���� �±׷� ã�Ƴ���. ���� ������ �� Ŭ��ó���Ѵ�.
            {
                GameObject[] branchBtn = GameObject.FindGameObjectsWithTag("BranchBtn");
                if (branchBtn[Random.Range(0, 2)] == null) //��ư�� 1���� ���� �ֱ� ������
                {
                    branchBtn[0].gameObject.GetComponent<Button>().onClick.Invoke();
                }
                else
                {
                    branchBtn[Random.Range(0, 2)].gameObject.GetComponent<Button>().onClick.Invoke();       //Random.Range : 0������, 2�� ����. 0~1 �� ���� ��
                }

                isVideoEnd = false;
            }
        }

    }

    // ���� ȭ���� ��ư��
    public void StateBtn()
    {
        SceneManager.LoadScene("State");
    }

    public void State2Btn()
    {
        SceneManager.LoadScene("State2");
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void ConvertBtn()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "State")
        {
            SceneManager.LoadScene("State2");
        }
        else
        {
            SceneManager.LoadScene("State");
        }
        
    }

    public void CreditBtn()
    {
        SceneManager.LoadScene("Credit");
    }


    //����-�����ϱ� ~ ������ �б��� �� ���� ��ư
    public void StartBtn() //BtnScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void Scene2()
    {
        GameManager.I.isVisit[1] = true;
        SceneManager.LoadScene("Scene2");
    }

    public void Branch1A()  
    {
        GameManager.I.isVisit[2] = true;
        SceneManager.LoadScene("Branch1A");
    }

    public void Branch1B() // Ending - CastAway
    {
        GameManager.I.isVisit[3] = true;
        GameManager.I.ending[0] = true;
        SceneManager.LoadScene("Branch1B_CastAway");
    }

    public void Branch2A() // Ending - Nirvana
    {
        GameManager.I.isVisit[4] = true;
        GameManager.I.ending[1] = true;
        SceneManager.LoadScene("Branch2A_Nirvana");
    }

    public void Branch2B()
    {
        GameManager.I.isVisit[5] = true;
        SceneManager.LoadScene("Branch2B");
    }

    public void Branch3A() // Ending - ExpectedEnding
    {
        GameManager.I.isVisit[6] = true;
        GameManager.I.ending[2] = true;
        SceneManager.LoadScene("Branch3A_ExpectedEnding");
    }

    public void Branch3B()
    {
        GameManager.I.isVisit[7] = true;
        SceneManager.LoadScene("Branch3B");
    }

    public void Branch4A()
    {
        GameManager.I.isVisit[8] = true;
        SceneManager.LoadScene("Branch4A");
    }

    public void Branch4B() // Ending - FlyMeToTheMoon
    {
        GameManager.I.isVisit[9] = true;
        GameManager.I.ending[3] = true;
        SceneManager.LoadScene("Branch4B_FlyMeToTheMoon");
    }

    public void Branch5A()
    {
        GameManager.I.isVisit[10] = true;
        SceneManager.LoadScene("Branch5A");
    }

    public void Branch5B() // Ending - Last Chance
    {
        GameManager.I.isVisit[11] = true;
        GameManager.I.ending[4] = true;
        SceneManager.LoadScene("Branch5B_LastChance");
    }

    public void Scene5()
    {
        GameManager.I.isVisit[12] = true;
        SceneManager.LoadScene("Scene5");
    }

    public void Branch6A()
    {
        GameManager.I.isVisit[13] = true;
        SceneManager.LoadScene("Branch6A");
    }

    public void Branch6B() // Ending - Cliche
    {
        GameManager.I.isVisit[14] = true;
        GameManager.I.ending[5] = true;
        SceneManager.LoadScene("Branch6B_Cliche");
    }

    public void Branch7A()
    {
        GameManager.I.isVisit[15] = true;
        SceneManager.LoadScene("Branch7A");
    }

    public void Branch7B()
    {
        GameManager.I.isVisit[16] = true;
        SceneManager.LoadScene("Branch7B");
    }

    public void Branch7C() // Ending - Sisyphus
    {
        GameManager.I.isVisit[17] = true;
        GameManager.I.ending[6] = true;
        SceneManager.LoadScene("Branch7C_Sisyphus");
    }

    public void Branch7AB() // Ending - ���� ���� ���� ���´�
    {
        GameManager.I.isVisit[18] = true;
        GameManager.I.ending[8] = true;
        SceneManager.LoadScene("Branch7AB_EmilSinclair");
    }

    public void Branch7C_2() // Ending - Sisyphus
    {
        GameManager.I.isVisit[19] = true;
        GameManager.I.ending[6] = true;
        SceneManager.LoadScene("Branch7C_Sisyphus");
    }

    public void Branch7BB() // Ending - ȣ������
    {
        GameManager.I.isVisit[20] = true;
        GameManager.I.ending[7] = true;
        SceneManager.LoadScene("Branch7BB_LifeIsButADream");
    }

}

