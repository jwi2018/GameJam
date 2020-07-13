using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public static int Liking;//호감도를 저장합니다.
    public static Save save;
    public static int Liking_phase;
    public static int optionPoint;
    public static int stringEventOption;
    public static int eventStartPoint;

    private void Awake()//초기화후 먼저 실행 
    {
        save = this;
        Liking = PlayerPrefs.GetInt("liking"); //호감도 불러오기
        optionPoint = PlayerPrefs.GetInt("Point");
        stringEventOption = PlayerPrefs.GetInt("Option");
        eventStartPoint = PlayerPrefs.GetInt("StartOption");
        StartCoroutine("AutoSave");
    }

    void Update()
    {
        LikeSplit();

        if (Input.GetKeyDown(KeyCode.Escape))//뒤로가기를 눌렀을때 세이브 코루틴 저장
        {
            LoveSave();
            PointSave();
            EventOption();
            EventStartOption();
            Application.Quit();
        }
    }

    void LikeSplit()
    {
      if (Liking >900)
        {
            Liking_phase = 9;
        }
      else if(Liking >800)
        {
            Liking_phase = 8;
        }
        else if (Liking > 700)
        {
            Liking_phase = 7;
        }
        else if (Liking > 600)
        {
            Liking_phase = 6;
        }
        else if (Liking > 500)
        {
            Liking_phase = 5;
        }
        else if (Liking > 400)
        {
            Liking_phase = 4;
        }
        else if (Liking > 300)
        {
            Liking_phase = 3;
        }
        else if (Liking > 200)
        {
            Liking_phase = 2;
        }
        else if (Liking > 100)
        {
            Liking_phase = 1;
        }
        else
        {
            Liking_phase = 0;
        }
    }
    //public void ClickLiking()//클릭했을때 호감도 1증가 
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //       // Clik이라는 오브젝트를 만들어서 클릭시 사라지면서 호감도가 오르면서 대사가 나오게
    //        Liking += 1;
    //        Debug.Log(Liking);

    //    }
    //}
    public void LoveSave()//호감도 저장
    {
        PlayerPrefs.SetInt("liking", (int)Liking);
    }

    public void PointSave()
    {
        PlayerPrefs.SetInt("Point", (int)optionPoint);
    }

    public void EventOption()
    {
        PlayerPrefs.SetInt("Option", (int)stringEventOption);
    }

    public void EventStartOption()
    {
        PlayerPrefs.SetInt("StartOption", (int)eventStartPoint);
    }

    void OnApplicationPause()//잠시 멈추고 화면을 나갈때 저장합니다.
    {
        LoveSave();
        PointSave();
        EventOption();
        EventStartOption();
    }

    private void OnApplicationQuit()
    {
        LoveSave();
        PointSave();
        EventOption();
        EventStartOption();
    }

    IEnumerator AutoSave()
    {//일정 시간마다 자동으로 저장을 합니다.
        while (true)
        {
            yield return new WaitForSeconds(30f);
            StartCoroutine("Saving");
        }
    }

    IEnumerator Saving()
    {//프리팹으로 저장합니다.
        PlayerPrefs.SetInt("liking", (int)Liking);
        PlayerPrefs.SetInt("Point", (int)optionPoint);
        PlayerPrefs.SetInt("Option", (int)stringEventOption);
        PlayerPrefs.SetInt("StartOption", (int)eventStartPoint);
        yield break;
    }
}