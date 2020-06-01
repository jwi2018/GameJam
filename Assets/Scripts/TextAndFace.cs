using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAndFace : MonoBehaviour
{
    string[,] chatArr;
    string[,] chatOptionArr;

    public List<Text> chatList;
    public List<Text> chatOptionList;

    int ranId = 0;
    string likePhase = "0";
    int liking = 0;
    //public Text loveText;
    //public Text option1;
    //public Text option2;
    public Image face;

    public Sprite faceTypeA, faceTypeB, faceTypeC, faceTypeD, faceTypeE;

    void Start()
    {
        StartCoroutine("StartLoveToAssignment");
    }

    public IEnumerator StartLoveToAssignment()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("CsvReadChatText");
        StartCoroutine("ChatText");
        StartCoroutine("ChatFace");
        yield return null;              // 스위치문 때문에 null 사용
    }

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

    IEnumerator ChatFace()     // 얼굴 타입 별 표정 변화
    {
        while (true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                ranId = Random.Range(0, 50);
                likePhase = Save.Liking_phase.ToString();

                switch (chatArr[ranId, 2])       // 표정 변경 스위치 문 
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

    IEnumerator ChatText()      // 대사
    {
        while (true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                liking = Save.Liking;

                Debug.Log("2");
                Debug.Log(liking);

                if (liking < 100)
                {
                    int ranIdFirs = Random.Range(0, 9);
                    //loveText.text = chatArr[ranIdFirs, 3];
                    chatList[0].text = chatArr[ranIdFirs, 3];
                }
                else if(liking == 100)
                {          
                    //loveText.text = chatArr[10, 3];
                    //option1.text = chatOptionArr[0, 1];
                    //option2.text = chatOptionArr[0, 2];
                }
                else if (liking > 101 && liking < 200)
                {
                    int ranIdFirs = Random.Range(11, 19);
                    //loveText.text = chatArr[ranIdFirs, 3];
                }
                else if (liking == 200)
                {
                    //loveText.text = chatArr[20, 3];
                    //option1.text = chatOptionArr[1, 1];
                    //option2.text = chatOptionArr[1, 2];
                }
                else if (liking > 201 && liking < 300)
                {
                    int ranIdFirs = Random.Range(21, 29);
                    //loveText.text = chatArr[ranIdFirs, 3];
                }
                else if (liking == 300)
                {
                    //loveText.text = chatArr[30, 3];
                    //option1.text = chatOptionArr[2, 1];
                    //option2.text = chatOptionArr[2, 2];
                }
                else if (liking > 301 && liking < 400)
                {
                    int ranIdFirs = Random.Range(31, 39);              
                    //loveText.text = chatArr[ranIdFirs, 3];
                }
                else if (liking == 400)
                {
                    //loveText.text = chatArr[30, 3];
                    //option1.text = chatOptionArr[3, 1];
                    //option2.text = chatOptionArr[3, 2];
                }
                else if (liking > 401 && liking < 500)
                {
                    int ranIdFirs = Random.Range(41, 49);
                    //loveText.text = chatArr[ranIdFirs, 3];
                }
                else if (liking == 500)
                {
                    //loveText.text = chatArr[50, 3];
                    //option1.text = chatOptionArr[4, 1];
                    //option2.text = chatOptionArr[4, 2];
                }

            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    
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