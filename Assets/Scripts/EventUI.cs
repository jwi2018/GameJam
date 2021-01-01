using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class EventUI : MonoBehaviour
{
    // 이벤트 재 실행 UI
    //public Image EventUIImage;
    public GameObject eventUIOpenButton;    // 이벤트 UI 오픈하는 버튼
    public Button eventUICloseButton;   // 이벤트 UI 닫는 버튼
    public Image eventUIBG;

    public Button eventUIFirEventButton;    // 첫번째 엔딩 보여주는 버튼
    public Button eventUISecEventButton;    // 두번째 엔딩 보여주는 버튼
    public Button eventUIThrEventButton;    // 세번째 엔딩 보여주는 버튼

    public Button endingMessageButton;     // 이벤트 엔딩 못볼때 나오는 텍스트 배경 버튼
    public Text endingMessage;          // 이벤트 엔딩 못볼때 나오는 텍스트

    public Image stringEndingTextImage;
    public Text stringEndingText;       // 엔딩 텍스트 나오는 부분

    public Image cgEndingImage;       // 엔딩 이미지 나오는 부분
    public Image cgEndingImageBg;

    public SpriteAtlas eventCg;

    string[,] eventEndingArr;

    public int eventFirEndingUIListId = 0;
    public int eventSecEndingUIListId = 7;
    public int eventThrEndingUIListId = 14;

    void Start()
    {
        eventEndingArr = new string[CsvRead.eventEndingTableId, 5];
        StartCoroutine("EventEndingList");

        eventUIOpenButton.gameObject.SetActive(true);
        eventUIBG.gameObject.SetActive(false);

        /*
        Save.eventUIFirEnding = 1;
        Save.eventUISecEnding = 1;
        Save.eventUIThrEnding = 1;
        */

    }

    public void OnClickOpenEventUIBut()     // 이벤트 UI 오픈 버튼
    {
        StartCoroutine("OpenEventUI");

        //Debug.Log("이벤트 오픈");
        //eventUIOpenButton.gameObject.SetActive(false);
        //eventUIBG.gameObject.SetActive(true);
        //endingMessageButton.gameObject.SetActive(true);
        //Debug.Log("이벤트 오픈2");
    }
    
    IEnumerator OpenEventUI()
    {
        eventUIOpenButton.gameObject.SetActive(false);
        eventUIBG.gameObject.SetActive(true);
        endingMessageButton.gameObject.SetActive(true);
        yield return null;
    }

    public void OnClickCloseEventUIBut()    // 이벤트 UI 클로즈 버튼
    {
        eventUIOpenButton.gameObject.SetActive(true);
        eventUIBG.gameObject.SetActive(false);
        endingMessageButton.gameObject.SetActive(false);
    }

    public void OnClickFirEndingStartBut()     // FirEnding 이벤트 실행버튼
    {
        if(Save.eventUIFirEnding == 0)  
        {
            StartCoroutine("NotEnding");
        }
        else if(Save.eventUIFirEnding == 1) 
        {
            StartCoroutine("EventUIFirEnding");
        }
    }

    public void OnClickSecEndingStartBut()     // SecEnding 이벤트 실행버튼
    {
        if (Save.eventUISecEnding == 0)  
        {
            StartCoroutine("NotEnding");
        }
        else if (Save.eventUISecEnding == 1) 
        {
            StartCoroutine("EventUISecEnding");
        }
    }

    public void OnClickThrEndingStartBut()     // ThrEnding 이벤트 실행버튼
    {
        if (Save.eventUIThrEnding == 0)  
        {
            StartCoroutine("NotEnding");
        }
        else if (Save.eventUIThrEnding == 1) 
        {
            StartCoroutine("EventUIThrEnding");
        }
    }

    IEnumerator EventEndingList()
    {
        for (int eventEndingId = 0; eventEndingId < CsvRead.eventEndingTableId; eventEndingId++)
        {
            for (int eventEndingTxt = 0; eventEndingTxt < 5; eventEndingTxt++)
            {
                eventEndingArr[eventEndingId, eventEndingTxt] = CsvRead.doubleEventEndingList[eventEndingId, eventEndingTxt];
            }
        }
        yield return null;
    }

    IEnumerator NotEnding()
    {
        endingMessageButton.gameObject.SetActive(true);
        endingMessage.text = "아직 보지 못한 엔딩입니다.";

        yield return new WaitForSeconds(3f);

        endingMessageButton.gameObject.SetActive(false);
    }

    IEnumerator EventUIFirEnding()
    {
        for (eventFirEndingUIListId = 0; eventFirEndingUIListId < 7; eventFirEndingUIListId++)
        {
            if (eventEndingArr[eventFirEndingUIListId, 2] == "text_print")
            {
                string eventFirEndingUIStr = eventEndingArr[eventFirEndingUIListId, 3];
                Debug.Log(eventFirEndingUIStr);
                int eventFirEndingUIInt = int.Parse(eventFirEndingUIStr);
                int eventFirEndingUIIntShow = eventFirEndingUIInt - 500;
                stringEndingText.text = CsvRead.doubleEventTextList[eventFirEndingUIIntShow, 3];

                yield return new WaitForSeconds(3f);
            }
            else if (eventEndingArr[eventFirEndingUIListId, 2] == "cg_play")
            {
                string eventFirEndingCgName = eventEndingArr[eventFirEndingUIListId, 3];
                cgEndingImage.sprite = eventCg.GetSprite(eventFirEndingCgName);

                yield return new WaitForSeconds(3f);
            }
        }
        yield return null;
    }

    IEnumerator EventUISecEnding()
    {
        for (eventSecEndingUIListId = 7; eventSecEndingUIListId < 14; eventSecEndingUIListId++)
        {
            if (eventEndingArr[eventSecEndingUIListId, 2] == "text_print")
            {
                string eventSecEndingUIStr = eventEndingArr[eventSecEndingUIListId, 3];
                int eventSecEndingUIInt = int.Parse(eventSecEndingUIStr);
                int eventSecEndingUIIntShow = eventSecEndingUIInt - 500;
                stringEndingText.text = CsvRead.doubleEventTextList[eventSecEndingUIIntShow, 3];

                yield return new WaitForSeconds(3f);
            }
            else if (eventEndingArr[eventSecEndingUIListId, 2] == "cg_play")
            {
                string eventSecEndingCgName = eventEndingArr[eventSecEndingUIListId, 3];
                cgEndingImage.sprite = eventCg.GetSprite(eventSecEndingCgName);

                yield return new WaitForSeconds(3f);
            }
        }
        yield return null;
    }

    IEnumerator EventUIThrEnding()
    {
        for (eventThrEndingUIListId = 14; eventThrEndingUIListId < 23; eventThrEndingUIListId++)
        {
            if (eventEndingArr[eventThrEndingUIListId, 2] == "text_print")
            {
                string eventThrEndingUIStr = eventEndingArr[eventThrEndingUIListId, 3];
                int eventThrEndingUIInt = int.Parse(eventThrEndingUIStr);
                int eventThrEndingUIIntShow = eventThrEndingUIInt - 500;
                stringEndingText.text = CsvRead.doubleEventTextList[eventThrEndingUIIntShow, 3];

                yield return new WaitForSeconds(3f);
            }
            else if (eventEndingArr[eventThrEndingUIListId, 2] == "cg_play")
            {
                string eventThrEndingCgName = eventEndingArr[eventThrEndingUIListId, 3];
                cgEndingImage.sprite = eventCg.GetSprite(eventThrEndingCgName);

                yield return new WaitForSeconds(3f);
            }
        }
        yield return null;
    }
}
