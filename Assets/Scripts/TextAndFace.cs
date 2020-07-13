using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAndFace : MonoBehaviour
{
    //string[,] chatArr;
    //string[,] chatOptionArr;

    public List<Text> chatList;
    public List<Text> chatOptionList;

    int ranId = 0;
    string likePhase = "0";
    int liking = 0;
    public Image face;
    int op = 0;
    int option = 0;

    public Image cgImage0;
    public Image eventChatImg;

    public Text eventChatText;

    public Sprite faceTypeA, faceTypeB, faceTypeC, faceTypeD, faceTypeE;

    void Start()
    {
        cgImage0.gameObject.SetActive(false);
        eventChatImg.gameObject.SetActive(false);

        StartCoroutine("StartLoveToAssignment");
    }

    public IEnumerator StartLoveToAssignment()
    {
        //yield return new WaitForSeconds(0.5f);
        StartCoroutine("ChatText");
        StartCoroutine("ChatFace");
        yield return null;              // 스위치문 때문에 null 사용
    }
    
    IEnumerator ChatFace()     // 얼굴 타입 별 표정 변화
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ranId = Random.Range(0, 50);
                likePhase = Save.Liking_phase.ToString();

                switch (CsvRead.doubleChatList[ranId, 2])       // 표정 변경 스위치 문 
                {
                    case "0":
                        face.sprite = faceTypeA;
                        break;
                    case "1":
                        face.sprite = faceTypeB;
                        break;
                    case "2":
                        face.sprite = faceTypeC;
                        break;
                    case "3":
                        face.sprite = faceTypeD;
                        break;
                    case "4":
                        face.sprite = faceTypeE;
                        break;
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator ChatText()      // 대사 출력
    {
        while (true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                liking = Save.Liking;
                op = Save.optionPoint;
                option = Save.stringEventOption;

                Debug.Log(liking);
                //Debug.Log(option);

                int RanChage = Random.Range(0, 2);

                if (RanChage == 1)
                {
                    if (liking < 100)
                    {
                        Save.stringEventOption = 0;     // 옵션 값 0으로 변경.
                        int ranIdFirs = Random.Range(0, 9);
                        chatList[0].text = CsvRead.doubleChatList[ranIdFirs, 3];
                    }
                    else if (liking == 100)
                    {
                        Save.stringEventOption = 1;     // 옵션 값 1으로 변경.

                        chatList[0].text = CsvRead.doubleChatList[10, 3];
                        for (int num = 0; num < 2; num++)
                        {
                            chatOptionList[num].text = CsvRead.doubleChatOptionList[0, num + 1];
                        }
                    }
                    else if (liking > 101 && liking < 200)
                    {
                        Save.stringEventOption = 0;

                        int ranIdFirs = Random.Range(11, 19);
                        chatList[0].text = CsvRead.doubleChatList[ranIdFirs, 3];
                    }
                    else if (liking == 200)
                    {
                        Save.stringEventOption = 2;
                        chatList[0].text = CsvRead.doubleChatList[20, 3];
                        for (int num = 0; num < 2; num++)
                        {
                            chatOptionList[num].text = CsvRead.doubleChatOptionList[1, num + 1];
                        }
                    }
                    else if (liking > 201 && liking < 300)
                    {
                        Save.stringEventOption = 0;
                        int ranIdFirs = Random.Range(21, 29);
                        chatList[0].text = CsvRead.doubleChatList[ranIdFirs, 3];
                    }
                    else if (liking == 300)
                    {
                        Save.stringEventOption = 3;
                        chatList[0].text = CsvRead.doubleChatList[30, 3];
                        for (int num = 0; num < 2; num++)
                        {
                            chatOptionList[num].text = CsvRead.doubleChatOptionList[2, num + 1];
                        }
                    }
                    else if (liking > 301 && liking < 400)
                    {
                        Save.stringEventOption = 0;
                        int ranIdFirs = Random.Range(31, 39);
                        chatList[0].text = CsvRead.doubleChatList[ranIdFirs, 3];
                    }
                    else if (liking == 400)
                    {
                        Save.stringEventOption = 4;
                        chatList[0].text = CsvRead.doubleChatList[40, 3];
                        for (int num = 0; num < 2; num++)
                        {
                            chatOptionList[num].text = CsvRead.doubleChatOptionList[3, num + 1];
                        }
                    }
                    else if (liking > 401 && liking < 500)
                    {
                        Save.stringEventOption = 0;
                        int ranIdFirs = Random.Range(41, 49);
                        chatList[0].text = CsvRead.doubleChatList[ranIdFirs, 3];
                    }
                    else if (liking == 500)
                    {
                        Save.stringEventOption = 5;
                        chatList[0].text = CsvRead.doubleChatList[50, 3];
                        for (int num = 0; num < 2; num++)
                        {
                            chatOptionList[num].text = CsvRead.doubleChatOptionList[4, num + 1];
                        }
                    } 
                }
            }
            yield return new WaitForSeconds(0.001f);
        }
    }

    /*
    IEnumerator CsvReadChatText()           //  채팅 CSV 파일 다 읽어와서 2차 배열에 입력. 
    {
        chatArr = new string[CsvRead.chatTableId, 6];
        chatOptionArr = new string[CsvRead.chatOptionTableId, 7];

        for (int chatId = 0; chatId < CsvRead.chatTableId; chatId++)        // 2차원 배열 사용시 
        {
            for (int chatTxt = 0; chatTxt < 6; chatTxt++)
            {
                chatArr[chatId, chatTxt] = CsvRead.doubleChatList[chatId, chatTxt];
            }
        }

        for (int chatOpId = 0; chatOpId < CsvRead.chatOptionTableId; chatOpId++)        // 2차원 배열 사용시 
        {
            for (int chatOpTxt = 0; chatOpTxt < 7; chatOpTxt++)
            {
                chatOptionArr[chatOpId, chatOpTxt] = CsvRead.doubleChatOptionList[chatOpId, chatOpTxt];
            }
        }
        yield return new WaitForSeconds(1f);
    }
    */

    /*
    public IEnumerator FaceAndText()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                loveChatId = 0;
                likePhase = Save.Liking_phase.ToString();
                StartCoroutine("LoveToAssignment");
                //randText = Random.Range(0, 9);
                randText = Random.Range(0, 50);

                loveText.text = loveTypeCsv[randText, 3];

                switch (loveTypeCsv[randText, 2])
                {
                    case "0":
                        face.sprite = faceTypeA;
                        break;
                    case "1":
                        face.sprite = faceTypeB;
                        break;
                    case "2":
                        face.sprite = faceTypeC;
                        break;
                    case "3":
                        face.sprite = faceTypeD;
                        break;
                    case "4":
                        face.sprite = faceTypeE;
                        break;
                }
                yield return new WaitForSecondsRealtime(3.0f);
            }
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
  
    IEnumerator LoveToAssignment()
    {
        for (int chatId = 0; chatId < CsvRead.chatTableId; chatId++)//배열 최대값 구하기
        {
            if (CsvRead.doubleChatList[chatId, 1] == likePhase)
            {
                loveChatId++;
            }
        }

        loveTypeCsv = new string[loveChatId, 5];
        int loveId = 0;

        for (int chatId = 0; chatId < CsvRead.chatTableId; chatId++)
        {
            if (CsvRead.doubleChatList[chatId, 1] == likePhase)
            {
                for (int chatTxt = 0; chatTxt < 5; chatTxt++)
                {
                    loveTypeCsv[loveId, chatTxt] = CsvRead.doubleChatList[chatId, chatTxt];
                }
                loveId++;
            }
        }
        yield return null;
    }
    */
}