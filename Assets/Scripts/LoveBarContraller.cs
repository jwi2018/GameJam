using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveBarContraller : MonoBehaviour
{
	public static int curLike ;
	public Image curLikeper1, nextLikeper2;
	public int likeSlider = 100;
	public int MAXLike = 1000;
	public List<Color> colors;

	public static LoveBarContraller loveBarContraller;

	void Start()
	{
		curLike = Save.Liking;
	}

	void Update()
	{
		ClickLiking();
		Refresh();
	}

	public void ClickLiking()//클릭했을때 호감도 1증가 
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (Save.Liking == 100 || Save.Liking == 200 || Save.Liking == 300 || Save.Liking == 400 || Save.Liking == 500 || Save.eventStartPoint == 1)
			{
				// Clik이라는 오브젝트를 만들어서 클릭시 사라지면서 호감도가 오르면서 대사가 나오게
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

	void Refresh()
	{
		nextLikeper2.rectTransform.sizeDelta = new Vector2(curLikeper1.rectTransform.sizeDelta.x , curLikeper1.rectTransform.sizeDelta.y *GetLike(curLike));
		curLikeper1.color = Getcolor(curLike - likeSlider);
		nextLikeper2.color = Getcolor(curLike);
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
				resultRatio = moduled/likeSlider;
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