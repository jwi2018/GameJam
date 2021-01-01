using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LovePointButClick : MonoBehaviour
{
    public Button LovePointButton;

    public List<Text> chatList;
    public List<Text> chatOptionList;

    int liking = 0;
    int ranId = 0;

    public Image cgImage0;

    public Image eventChatImg;
    public Text eventChatText;

    public Image characterType;
    public Sprite characterTypeA, characterTypeB, characterTypeC, characterTypeD, characterTypeE;

    float timer = 3f;
    int waitingTime = 3;

    void Start()
    {
        cgImage0.gameObject.SetActive(false);
        eventChatImg.gameObject.SetActive(false);

        //StartCoroutine("chatText");
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    public void OnClickCharChange()
    {
        if (timer > waitingTime)
        {
            ranId = Random.Range(0, 50);

            switch (CsvRead.doubleChatList[ranId, 2])       // 표정 변경 스위치 문 
            {
                case "0":
                    characterType.sprite = characterTypeA;
                    break;
                case "1":
                    characterType.sprite = characterTypeB;
                    break;
                case "2":
                    characterType.sprite = characterTypeC;
                    break;
                case "3":
                    characterType.sprite = characterTypeD;
                    break;
                case "4":
                    characterType.sprite = characterTypeE;
                    break;
            }
        }
    }

    /*
    IEnumerator chatText()
    {
        if(LovePointButton.onClick.AddListener(() => buttonCa))
        yield return null;
    }
    */
    public void OnClickChatText()
    {
        liking = Save.Liking;

        int RanChage = 1;

        if (RanChage == 1)
        {
            if (liking < 100)
            {
                Save.stringEventOption = 0;     // 옵션 값 0으로 변경.             초기에 값을 주기 위해 여기만 0으로 선언   // 2020 - 08 - 28 이벤트 구분 발생을 위함.

                int ranIdFirs = Random.Range(0, 10);

                if (timer > waitingTime)
                {
                    chatList[0].text = CsvRead.doubleChatList[ranIdFirs, 3];
                    timer = 0;
                }
            }
            else if (liking == 100)
            {
                Debug.Log("liking = 100");
                chatList[0].text = CsvRead.doubleChatList[51, 3];

                for (int num = 0; num < 2; num++)
                {
                    chatOptionList[num].text = CsvRead.doubleChatOptionList[0, num + 1];
                }
            }
            else if (liking > 101 && liking < 200)
            {
                int ranIdFirs = Random.Range(11, 20);

                if (timer > waitingTime)
                {
                    chatList[0].text = CsvRead.doubleChatList[ranIdFirs, 3];
                    timer = 0;
                }
            }
            else if (liking == 200)
            {
                chatList[0].text = CsvRead.doubleChatList[52, 3];
                for (int num = 0; num < 2; num++)
                {
                    chatOptionList[num].text = CsvRead.doubleChatOptionList[1, num + 1];
                }
            }
            else if (liking > 201 && liking < 300)
            {
                int ranIdFirs = Random.Range(21, 30);

                if (timer > waitingTime)
                {
                    chatList[0].text = CsvRead.doubleChatList[ranIdFirs, 3];
                    timer = 0;
                }
            }
            else if (liking == 300)
            {
                chatList[0].text = CsvRead.doubleChatList[53, 3];
                for (int num = 0; num < 2; num++)
                {
                    chatOptionList[num].text = CsvRead.doubleChatOptionList[2, num + 1];
                }
            }
            else if (liking > 301 && liking < 400)
            {
                int ranIdFirs = Random.Range(31, 40);

                if (timer > waitingTime)
                {
                    chatList[0].text = CsvRead.doubleChatList[ranIdFirs, 3];
                    timer = 0;
                }
            }
            else if (liking == 400)
            {
                chatList[0].text = CsvRead.doubleChatList[54, 3];
                for (int num = 0; num < 2; num++)
                {
                    chatOptionList[num].text = CsvRead.doubleChatOptionList[3, num + 1];
                }
            }
            else if (liking > 401 && liking < 500)
            {
                int ranIdFirs = Random.Range(41, 50);

                if (timer > waitingTime)
                {
                    chatList[0].text = CsvRead.doubleChatList[ranIdFirs, 3];
                    timer = 0;
                }
            }
            else if (liking == 500)
            {
                if (Save.optionPoint == 1)
                {
                    GameManager.stringEndingOption = 1;
                }
                else if (Save.optionPoint == 3)
                {
                    GameManager.stringEndingOption = 2;
                }
                else if (Save.optionPoint == 5)
                {
                    GameManager.stringEndingOption = 3;
                }

                Save.stringEventOption = 5;
                Save.eventStartPoint = 1;

                chatList[0].text = CsvRead.doubleChatList[50, 3];
            }
        }

    }

}
