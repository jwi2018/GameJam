using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveBarContraller : MonoBehaviour
{
    public static int curLike; 
    public Image curLikeper1, nextLikeper2, curLikeper3, nextLikeper4;
    public int likeSlider = 100;
    public int MAXLike = 1000;
    public List<Color> colors;
    //public List<Image> images;

    public static LoveBarContraller loveBarContraller;

    //public GameObject LovePointButton;

    public Button LovePointButton;

    void Start()
    {
        curLike = Save.Liking;
        ClickLiking();
        LovePointButton.gameObject.SetActive(true);
    }

    void Update()
    {
        Refresh();
    }

    public void OnClickLovePointUp()
    {
        Debug.Log("클릭하기 전");
        Debug.Log(Save.Liking);

        curLike += 10;
        Save.Liking = curLike;

        if (Save.Liking == 100 || Save.Liking == 200 || Save.Liking == 300 || Save.Liking == 400 || Save.Liking >= 500 || Save.eventStartPoint == 1)
        {
            LovePointButton.gameObject.SetActive(false);
            // Clik이라는 오브젝트를 만들어서 클릭시 사라지면서 호감도가 오르면서 대사가 나오게
            Save.optionPoint += 0;
            curLike += 0;
            Save.Liking = curLike;
        }
        Debug.Log("클릭했을때 후");
        Debug.Log(Save.Liking);
    }


    
    public void ClickLiking() //클릭했을때 호감도 1증가 
    {
        StartCoroutine("ClickLikingCou");
        /*
        if (Save.Liking == 100 || Save.Liking == 200 || Save.Liking == 300 || Save.Liking == 400 || Save.Liking >= 500 || Save.eventStartPoint == 1)
        {
            // Clik이라는 오브젝트를 만들어서 클릭시 사라지면서 호감도가 오르면서 대사가 나오게
            LovePointButton.gameObject.SetActive(false);
            // Clik이라는 오브젝트를 만들어서 클릭시 사라지면서 호감도가 오르면서 대사가 나오게
            Save.optionPoint += 0;
            curLike += 0;
            Save.Liking = curLike;
        }
        else
        {
            curLike += 0;       // 여기 호감도는 건드리지 말 것. 건드린 수치만큼 초기에 올라가있음. 2020 - 09 - 25
            Save.Liking = curLike;
        }
        Debug.Log("ClickLiking");
        Debug.Log(Save.Liking);
        */
    }
    
    IEnumerator ClickLikingCou()
    {
        Debug.Log("클릭했을때 코루틴");
        Debug.Log(Save.Liking);
        if (Save.Liking == 100 || Save.Liking == 200 || Save.Liking == 300 || Save.Liking == 400 || Save.Liking >= 500 || Save.eventStartPoint == 1)
        {
            // Clik이라는 오브젝트를 만들어서 클릭시 사라지면서 호감도가 오르면서 대사가 나오게
            LovePointButton.gameObject.SetActive(false);
            // Clik이라는 오브젝트를 만들어서 클릭시 사라지면서 호감도가 오르면서 대사가 나오게
            Save.optionPoint += 0;
            curLike += 0;
            Save.Liking = curLike;
        }
        else
        {
            curLike += 0;       // 여기 호감도는 건드리지 말 것. 건드린 수치만큼 초기에 올라가있음. 2020 - 09 - 25
            Save.Liking = curLike;
        }

        yield return null;
    }

    /*
	public void ClickLiking()//클릭했을때 호감도 1증가 
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 touchPos = new Vector2(worldPos.x, worldPos.y);
			Ray2D ray = new Ray2D(touchPos, Vector2.zero);
			RaycastHit2D rayHit = Physics2D.Raycast(ray.origin, ray.direction);

			if (rayHit.collider != null)
			{
				if (rayHit.collider.gameObject.name.Equals("LovePointButton"))
				{
					if (Save.Liking == 100 || Save.Liking == 200 || Save.Liking == 300 || Save.Liking == 400 || Save.Liking >= 500 || Save.eventStartPoint == 1)
					{
						LovePointButton.SetActive(false);
						// Clik이라는 오브젝트를 만들어서 클릭시 사라지면서 호감도가 오르면서 대사가 나오게
						Save.optionPoint += 0;
						curLike += 0;
						Save.Liking = curLike;
					}
					else
					{
						curLike += 10;
						Save.Liking = curLike;
					}
				}
			}
		}
	}
	*/

    void Refresh()
    {
        nextLikeper2.rectTransform.sizeDelta = new Vector2(curLikeper1.rectTransform.sizeDelta.x * GetLike(curLike), curLikeper1.rectTransform.sizeDelta.y);        // 여기 x, y축 고쳐야될수도
        curLikeper1.color = Getcolor(curLike - likeSlider);
        nextLikeper2.color = Getcolor(curLike);
        nextLikeper4.rectTransform.sizeDelta = new Vector2(curLikeper3.rectTransform.sizeDelta.x, curLikeper3.rectTransform.sizeDelta.y * GetLike(curLike));        // 여기 x, y축 고쳐야될수도
        curLikeper3.color = Getcolor(curLike - likeSlider);
        nextLikeper4.color = Getcolor(curLike);
    }

    float GetLike(int tarlike)
    {
        float resultRatio = 0;

        if (tarlike > 0)
        {
            float divided = (float)tarlike / likeSlider;
            if (divided == (int)divided)
            {
                resultRatio = 1;
            }
            else
            {
                float moduled = tarlike % likeSlider;
                resultRatio = moduled / likeSlider;
            }
        }
        else
        {
            resultRatio = 0;
        }
        return resultRatio;
    }

    Color Getcolor(int tarlike)
    {
        Color result = Color.black;
        if (tarlike > 0)
        {
            float divided = (float)tarlike / likeSlider;
            int index = (int)divided;
            if (divided == (int)divided)
            {
                index--;
            }
            result = colors[index % colors.Count];
        }
        return result;
    }
}