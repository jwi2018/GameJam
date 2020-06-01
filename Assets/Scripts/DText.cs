using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DText : MonoBehaviour
{
    public List<Text> waitText;                // 텍스트 박스 지정 전 대기 텍스트

    private int ranId = 0;
    private int ranTxt = 0;

    public Text displayText0;
    public Text displayText1;           // 1줄짜리 대사
    public Text displayText2;
    public Text displayText3;
    public Text displayText4;
    public Text displayText5;

    public Text displayNameText1;
    public Text displayNameText2;
    public Text displayNameText3;
    public Text displayNameText4;
    public Text displayNameText5;
    public Text displayNameText6;

    public Text colon1;
    public Text colon2;
    public Text colon3;
    public Text colon4;
    public Text colon5;
    public Text colon6;

    public Text displayTwoText1;        // 2줄짜리 대사
    public Text displayTwoText2;
    public Text displayTwoText3;
    public Text displayTwoText4;
    public Text displayTwoText5;

    public Text displayThreeText1;      // 3줄짜리 대사
    public Text displayThreeText2;
    public Text displayThreeText3;
    public Text displayThreeText4;
    // ranTxt = 1    --  애기븝미 대사
    // ranTxt = 2    --  캐릭터 대사

    void Start()
    {
        StartCoroutine("TextMove");
    }

    IEnumerator TextMove()
    {
        yield return new WaitForSeconds(0.5f);

        for (int num = 0; num < waitText.Count; num++)
        {
            ranId = Random.Range(0, 40);
            ranTxt = Random.Range(1, 3);
            waitText[num].text = CsvRead.doubleDisplayList[ranId, ranTxt];
            int TextLength = waitText[num].text.Length;

            if(TextLength < 24)
            {
                displayText0.text = waitText[num].text;

                if (ranTxt == 1)
                {
                    displayNameText1.text = "븝미";
                }
                else if (ranTxt == 2)
                {
                    displayNameText1.text = "플레이어";
                }
                colon1.text = ":";
            }
            else if(TextLength >= 24 && TextLength < 47)
            {
                displayTwoText1.text = waitText[num].text;

                if (ranTxt == 1)
                {
                    displayNameText2.text = "븝미";
                }
                else if (ranTxt == 2)
                {
                    displayNameText2.text = "플레이어";
                }
                colon2.text = ":";
            }
            else
            {
                displayThreeText1.text = waitText[num].text;

                if (ranTxt == 1)
                {
                    displayNameText3.text = "븝미";
                }
                else if (ranTxt == 2)
                {
                    displayNameText3.text = "플레이어";
                }
                colon3.text = ":";
            }

            //displayMidText[num].text = CsvRead.doubleDisplayList[ranId, ranTxt];
            
            yield return new WaitForSeconds(3f);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (displayText0.text != null)
            {
                // 1줄짜리만 온 경우
                ranId = Random.Range(0, 40);
                ranTxt = Random.Range(1, 3);
                waitText[num].text = CsvRead.doubleDisplayList[ranId, ranTxt];

                if (TextLength < 24)
                {
                    displayText1.text = displayText0.text;
                    displayNameText2.text = displayNameText1.text;
                    colon2.text = colon1.text;
                    displayText0.text = waitText[num].text;

                    if (ranTxt == 1)
                    {
                        displayNameText1.text = "븝미";
                    }
                    else if (ranTxt == 2)
                    {
                        displayNameText1.text = "플레이어";
                    }
                    colon1.text = ":";
                }
                else if (TextLength >= 24 && TextLength < 47)
                {
                    displayText2.text = displayText0.text;
                    displayNameText3.text = displayNameText2.text;
                    colon3.text = colon1.text;
                    displayTwoText1.text = waitText[num].text;

                    if (ranTxt == 1)
                    {
                        displayNameText2.text = "븝미";
                    }
                    else if (ranTxt == 2)
                    {
                        displayNameText2.text = "플레이어";
                    }
                    colon2.text = ":";
                }
                else
                {
                    displayText3.text = displayText0.text;
                    displayNameText4.text = displayNameText3.text;
                    colon4.text = colon3.text;
                    displayThreeText1.text = waitText[num].text;

                    if (ranTxt == 1)
                    {
                        displayNameText3.text = "븝미";
                    }
                    else if (ranTxt == 2)
                    {
                        displayNameText3.text = "플레이어";
                    }
                    colon3.text = ":";
                }

                ////////////////////////////////////////////////////////////////////////////////////////

                displayText1.text = waitText[num].text;
                displayNameText2.text = displayNameText1.text;
                colon2.text = colon1.text;
                ranId = Random.Range(0, 40);
                ranTxt = Random.Range(1, 3);
                waitText[num].text = CsvRead.doubleDisplayList[ranId, ranTxt];

                yield return new WaitForSeconds(3f);

                if (displayText1.text != null)
                {
                    displayText2.text = displayText1.text;
                    displayNameText3.text = displayNameText2.text;
                    colon3.text = colon2.text;
                    displayText1.text = waitText[num].text;
                    displayNameText2.text = displayNameText1.text;
                    colon2.text = colon1.text;
                    ranId = Random.Range(0, 40);
                    ranTxt = Random.Range(1, 3);
                    waitText[num].text = CsvRead.doubleDisplayList[ranId, ranTxt];
                    colon1.text = ":";

                    if (ranTxt == 1)
                    {
                        displayNameText1.text = "븝미";
                    }
                    else if (ranTxt == 2)
                    {
                        displayNameText1.text = "플레이어";
                    }

                    yield return new WaitForSeconds(3f);

                    if (displayText2.text != null)
                    {
                        displayText3.text = displayText2.text;
                        displayNameText4.text = displayNameText3.text;
                        colon4.text = colon3.text;
                        displayText2.text = displayText1.text;
                        displayNameText3.text = displayNameText2.text;
                        colon3.text = colon2.text;
                        displayText1.text = waitText[num].text;
                        displayNameText2.text = displayNameText1.text;
                        colon2.text = colon1.text;
                        ranId = Random.Range(0, 40);
                        ranTxt = Random.Range(1, 3);
                        waitText[num].text = CsvRead.doubleDisplayList[ranId, ranTxt];
                        colon1.text = ":";

                        if (ranTxt == 1)
                        {
                            displayNameText1.text = "븝미";
                        }
                        else if (ranTxt == 2)
                        {
                            displayNameText1.text = "플레이어";
                        }

                        yield return new WaitForSeconds(3f);

                        if (displayText3.text != null)
                        {
                            displayText4.text = displayText3.text;
                            displayNameText5.text = displayNameText4.text;
                            colon5.text = colon4.text;
                            displayText3.text = displayText2.text;
                            displayNameText4.text = displayNameText3.text;
                            colon4.text = colon3.text;
                            displayText2.text = displayText1.text;
                            displayNameText3.text = displayNameText2.text;
                            colon3.text = colon2.text;
                            displayText1.text = waitText[num].text;
                            displayNameText2.text = displayNameText1.text;
                            colon2.text = colon1.text;
                            ranId = Random.Range(0, 40);
                            ranTxt = Random.Range(1, 3);
                            waitText[num].text = CsvRead.doubleDisplayList[ranId, ranTxt];
                            colon1.text = ":";

                            if (ranTxt == 1)
                            {
                                displayNameText1.text = "븝미";
                            }
                            else if (ranTxt == 2)
                            {
                                displayNameText1.text = "플레이어";
                            }

                            yield return new WaitForSeconds(3f);

                            if (displayText4.text != null)
                            {
                                displayText5.text = displayText4.text;
                                displayNameText6.text = displayNameText5.text;
                                colon6.text = colon5.text;
                                displayText4.text = displayText3.text;
                                displayNameText5.text = displayNameText4.text;
                                colon5.text = colon4.text;
                                displayText3.text = displayText2.text;
                                displayNameText4.text = displayNameText3.text;
                                colon4.text = colon3.text;
                                displayText2.text = displayText1.text;
                                displayNameText3.text = displayNameText2.text;
                                colon3.text = colon2.text;
                                displayText1.text = waitText[num].text;
                                displayNameText2.text = displayNameText1.text;
                                colon2.text = colon1.text;
                                ranId = Random.Range(0, 40);
                                ranTxt = Random.Range(1, 3);
                                waitText[num].text = CsvRead.doubleDisplayList[ranId, ranTxt];
                                colon1.text = ":";

                                if (ranTxt == 1)
                                {
                                    displayNameText1.text = "븝미";
                                }
                                else if (ranTxt == 2)
                                {
                                    displayNameText1.text = "플레이어";
                                }

                                yield return new WaitForSeconds(3f);

                                if (displayText5.text != null)
                                {

                                    while (true)
                                    {
                                        displayText5.text = displayText4.text;
                                        displayNameText6.text = displayNameText5.text;
                                        colon6.text = colon5.text;
                                        displayText4.text = displayText3.text;
                                        displayNameText5.text = displayNameText4.text;
                                        colon5.text = colon4.text;
                                        displayText3.text = displayText2.text;
                                        displayNameText4.text = displayNameText3.text;
                                        colon4.text = colon3.text;
                                        displayText2.text = displayText1.text;
                                        displayNameText3.text = displayNameText2.text;
                                        colon3.text = colon2.text;
                                        displayText1.text = waitText[num].text;
                                        displayNameText2.text = displayNameText1.text;
                                        colon2.text = colon1.text;
                                        ranId = Random.Range(0, 40);
                                        ranTxt = Random.Range(1, 3);
                                        waitText[num].text = CsvRead.doubleDisplayList[ranId, ranTxt];
                                        colon1.text = ":";

                                        if (ranTxt == 1)
                                        {
                                            displayNameText1.text = "븝미";
                                        }
                                        else if (ranTxt == 2)
                                        {
                                            displayNameText1.text = "플레이어";
                                        }

                                        yield return new WaitForSeconds(3f);
                                    }                               
                                }
                                yield return new WaitForSeconds(3f);
                            }
                        }
                    }
                }
            }
            //displayMidText[num].text = " ";
            //displayMidText[0].text = "0번째 입니다."; // 맨 위 MidText_1
            //displayMidText[1].text = "1번째 입니다."; // MidText_2
            //displayMidText[2].text = "2번째 입니다."; // MidText_3
            //displayMidText[3].text = "3번째 입니다."; // MidText_4
            //displayMidText[4].text = "4번째 입니다."; // MidText_5
            //displayMidText[5].text = "5번째 입니다."; // MidText_6
        }
        yield return new WaitForSeconds(3f);
    }
}