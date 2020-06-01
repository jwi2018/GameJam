using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMove : MonoBehaviour
{
    public RectTransform top;//북쪽끝(터치시 상태
    public RectTransform bot;//남쪽끝(비터치
    public RectTransform totalText;//uiobject
    public GameObject chatText;

    private int moveStart = 0;//초 재기

    void Start()
    {
        StartCoroutine("MoveText");
    }
   
    IEnumerator MoveText()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                chatText.SetActive(true);
                moveStart = 0;

                while (true)
                {
                    if (totalText.anchoredPosition.y >= top.anchoredPosition.y)
                    {
                        yield return new WaitForSecondsRealtime(10.0f);
                        break;
                    }
                    totalText.anchoredPosition = new Vector2(0, totalText.anchoredPosition.y + 3.0f);
                   
                    yield return null;
                }
            }
            else
            {
                moveStart++;
                
                yield return null;
            }
            if (moveStart >= 3f)
            {
                chatText.SetActive(false);
                
                if (totalText.anchoredPosition.y> bot.anchoredPosition.y)
                {
                    totalText.anchoredPosition = new Vector2(0, totalText.anchoredPosition.y - 3.0f);
                }
                else if (totalText.anchoredPosition.y <= bot.anchoredPosition.y)
                {
                    totalText.anchoredPosition = bot.anchoredPosition;
                }
                //else if (Input.GetMouseButtonDown(0))
                //{
                //    moveStart = 0;
                //    Debug.Log("변수초기화");

                //    while (true)
                //    {
                //        moveStart = 0;
                //        if (textf.anchoredPosition.y <= bot.anchoredPosition.y)
                //        {
                //            break;
                //        }
                //        textf.anchoredPosition = new Vector2(0, textf.anchoredPosition.y - 10.0f);
                //        moveStart = 0;
                //        yield return new WaitForSeconds(0.01f);

                //    }
                //}
                //else
                //{
                //    moveStart++;
                //    Debug.Log(moveStart);
                //    yield return new WaitForSeconds(0.1f);
                //}
            }
        }
    }
}