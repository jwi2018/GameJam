using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDisplayMove : MonoBehaviour
{
    public int clickCount = 0;          // 0 = 전광판 상단 위치 . 1 = 전광판 하단 위치
    public RectTransform totalText;
    public RectTransform loveBar_Full;
    public RectTransform character_Full;
    public GameObject chatTextObject;
    public GameObject totalTextObject;

    void Start()
    {
        StartCoroutine("MoveDisplay");
    }
    
    IEnumerator MoveDisplay()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))        // 레이캐스트로 변경 . 콜라이더는 충돌체를 클릭하지 않을 경우 null 오류가 나타남
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 touchPos = new Vector2(worldPos.x, worldPos.y);
                Ray2D ray = new Ray2D(touchPos, Vector2.zero);
                RaycastHit2D rayHit = Physics2D.Raycast(ray.origin, ray.direction);

                //Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Vector2 clickPos = new Vector2(worldPos.x, worldPos.y);
                //Collider2D clickColl = Physics2D.OverlapPoint(clickPos);        

                //if (clickColl.gameObject.name == "TotalText")
                if(rayHit.collider != null)
                {
                    if (rayHit.collider.gameObject.name.Equals("TotalText"))
                    {
                        if (clickCount == 0)
                        {
                            chatTextObject.SetActive(false);

                            for (int pos = 0; pos < 72; pos++)
                            {
                                totalText.anchoredPosition = new Vector2(4f, totalText.anchoredPosition.y - 5f);
                                //character_Full.anchoredPosition = new Vector2(-57f, character_Full.anchoredPosition.y - 1f);
                                //loveBar_Full.anchoredPosition = new Vector2(-77f, loveBar_Full.anchoredPosition.y - 1f);
                                yield return new WaitForSecondsRealtime(0.01f);
                            }
                            yield return new WaitForSecondsRealtime(0.5f);
                            clickCount++;
                        }
                        else
                        {
                            chatTextObject.SetActive(true);

                            for (int pos = 0; pos < 72; pos++)
                            {
                                totalText.anchoredPosition = new Vector2(4f, totalText.anchoredPosition.y + 5f);
                                //character_Full.anchoredPosition = new Vector2(-57f, character_Full.anchoredPosition.y + 1f);
                                //loveBar_Full.anchoredPosition = new Vector2(-77f, loveBar_Full.anchoredPosition.y + 1f);
                                yield return new WaitForSecondsRealtime(0.01f);
                            }
                            yield return new WaitForSecondsRealtime(0.5f);
                            clickCount = 0;
                        }
                    }
                }
            }
            yield return null;
        }
    }
}
