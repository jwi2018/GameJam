using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDisplayMove : MonoBehaviour
{
    public int clickCount = 0;          // 0 = 전광판 상단 위치 . 1 = 전광판 하단 위치
    public RectTransform totalText;
    public RectTransform loveBar_Full;
    public RectTransform character_Full;

    public RectTransform LovePointArea;
    //public GameObject LovePointAreaObj;

    public GameObject chatTextObject;
    public GameObject totalTextObject;

    public GameObject LoveBarFull;

    public int ShopUICount = 0;
    public GameObject ShopUIOpenObject;     // 2020 - 08 - 13
    public GameObject ShopUIObject;
    public GameObject ShopUICloseObject;

    public int ShopEventCount = 0;
    public GameObject ShopEventOpenObject;
    public GameObject ShopEventObject;
    public GameObject ShopEventCloseObject;

    public int ShopOptionCount = 0;
    public GameObject ShopOptionOpenObject;
    public GameObject ShopOptionObject;
    public GameObject ShopOptionCloseObject;

    void Start()
    {
        ShopUIObject.SetActive(false);
        ShopUIOpenObject.SetActive(true);

        ShopEventOpenObject.SetActive(true);
        ShopEventObject.SetActive(false);

        ShopOptionOpenObject.SetActive(true);
        ShopOptionObject.SetActive(false);

        StartCoroutine("MoveDisplay");
    }
    //bool modeset = true;
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
                            LoveBarFull.SetActive(false);

                            for (int pos = 0; pos < 72; pos++)
                            {
                                totalText.anchoredPosition = new Vector2(0, totalText.anchoredPosition.y - 5f);
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
                            LoveBarFull.SetActive(true);

                            for (int pos = 0; pos < 72; pos++)
                            {
                                totalText.anchoredPosition = new Vector2(0, totalText.anchoredPosition.y + 5f);
                                //character_Full.anchoredPosition = new Vector2(-57f, character_Full.anchoredPosition.y + 1f);
                                //loveBar_Full.anchoredPosition = new Vector2(-77f, loveBar_Full.anchoredPosition.y + 1f);
                                yield return new WaitForSecondsRealtime(0.01f);
                            }
                            yield return new WaitForSecondsRealtime(0.5f);
                            clickCount = 0;
                        }
                    }
                    //else if (rayHit.collider.gameObject.name.Equals("ShopUIOpen"))
                    //{
                    //    if (ShopUICount == 0)
                    //    {
                    //        ShopUIOpenObject.SetActive(false);
                    //        ShopUIObject.SetActive(true);

                    //        ShopEventOpenObject.SetActive(false);
                    //        ShopOptionOpenObject.SetActive(false);

                    //        yield return new WaitForSeconds(0.01f);
                    //        ShopUICount++;
                    //    }
                    //}
                    //else if (rayHit.collider.gameObject.name.Equals("ShopUIClose"))
                    //{
                    //    if(ShopUICount == 1)
                    //    {
                    //        ShopUIOpenObject.SetActive(true);
                    //        ShopUIObject.SetActive(false);

                    //        ShopEventOpenObject.SetActive(true);
                    //        ShopOptionOpenObject.SetActive(true);

                    //        yield return new WaitForSeconds(0.01f);
                    //        ShopUICount = 0;
                    //    }
                    //}
                    //else if (rayHit.collider.gameObject.name.Equals("ShopEventOpen"))
                    //{
                    //    if(ShopEventCount == 0)
                    //    {
                    //        ShopEventOpenObject.SetActive(false);
                    //        ShopEventObject.SetActive(true);

                    //        ShopOptionOpenObject.SetActive(false);
                    //        ShopUIOpenObject.SetActive(false);

                    //        yield return new WaitForSeconds(0.01f);
                    //        ShopEventCount++;
                    //    }
                    //}
                    //else if (rayHit.collider.gameObject.name.Equals("ShopEventClose"))
                    //{
                    //    if(ShopEventCount == 1)
                    //    {
                    //        ShopEventOpenObject.SetActive(true);
                    //        ShopEventObject.SetActive(false);

                    //        ShopOptionOpenObject.SetActive(true);
                    //        ShopUIOpenObject.SetActive(true);

                    //        yield return new WaitForSeconds(0.01f);
                    //        ShopEventCount = 0;
                    //    }
                    //}
                    //else if (rayHit.collider.gameObject.name.Equals("ShopOptionOpen"))
                    //{
                    //    if (ShopOptionCount == 0)
                    //    {
                    //        ShopOptionOpenObject.SetActive(false);
                    //        ShopOptionObject.SetActive(true);

                    //        ShopEventOpenObject.SetActive(false);
                    //        ShopUIOpenObject.SetActive(false);

                    //        yield return new WaitForSeconds(0.01f);
                    //        ShopOptionCount++;
                    //    }
                    //}
                    //else if (rayHit.collider.gameObject.name.Equals("ShopOptionClose"))
                    //{
                    //    if (ShopOptionCount == 1)
                    //    {
                    //        ShopOptionOpenObject.SetActive(true);
                    //        ShopOptionObject.SetActive(false);

                    //        ShopEventOpenObject.SetActive(true);
                    //        ShopUIOpenObject.SetActive(true);

                    //        yield return new WaitForSeconds(0.01f);
                    //        ShopOptionCount = 0;
                    //    }
                    //}
                }
            }
            yield return null;
        }
    }
}
