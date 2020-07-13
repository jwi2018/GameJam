using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrint : MonoBehaviour
{
    //텍스트 펑션 기능
    // ex) 텍스트 펑션일 경우 그 밸류값이 스트링 테이블의 id값과 동일하며 그 id값의 text를 출력한다.
    public static TextPrint textPrint;

    public Text stringEventText;
    //string[,] eventTextListArr = new string[CsvRead.eventTextTableId, 5];
    string[,] eventTextListArr = new string[19, 5];

    void Start()
    {
        stringEventText.gameObject.SetActive(false);
        StartCoroutine("EventTextListArr");
    }
    
    IEnumerator EventTextListArr()
    {
        // 이벤트 전용 스트링 테이블
        for (int eventTextId = 0; eventTextId < CsvRead.eventTextTableId; eventTextId++)
        {
            for (int eventTextTxt = 0; eventTextTxt < 5; eventTextTxt++)
            {
                eventTextListArr[eventTextId, eventTextTxt] = CsvRead.doubleEventTextList[eventTextId, eventTextTxt];
            }
        }
        yield return null;
    }
    
    public void EventTextPrint()
    {
        string eventTextArrId = CsvRead.doubleEventList[GameManager.eventListId, 3];
        int eventTextArrIdInt = int.Parse(eventTextArrId);
        stringEventText.text = eventTextListArr[eventTextArrIdInt, 3];
        stringEventText.gameObject.SetActive(true);
    }
}
