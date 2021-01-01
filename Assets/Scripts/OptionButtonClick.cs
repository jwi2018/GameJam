using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButtonClick : MonoBehaviour
{
    // 첫번째 버튼 변수들
    int loveIntFir = 0;
    int pointIntFir = 0;
    string loveStringFir = "0";
    string pointStringFir = "0";

    // 두번째 버튼 변수들
    int loveIntSec = 0;
    int pointIntSec = 0;
    string loveStringSec = "0";
    string pointStringSec = "0";

    // UI 및 오브젝트들
    public Button optionButtonFir;
    public Button optionButtonSec;
    public Image stringEventTextImage;
    public Text stringEventText;
    public Image cgImage;
    public Image cgImageBg;
    public GameObject LovePointButton;

    public void OnClickFirOptionButton()        // 1번째 버튼 클릭 시 발생해야 하는 상황
    {
        loveStringFir = CsvRead.doubleChatOptionList[GameManager.optionPlusNum, 3];
        loveIntFir = int.Parse(loveStringFir);
        pointStringFir = CsvRead.doubleChatOptionList[GameManager.optionPlusNum, 5];
        pointIntFir = int.Parse(pointStringFir);

        Save.Liking += loveIntFir;
        LoveBarContraller.curLike += loveIntFir;

        if (Save.eventStartPoint == 0)
        {
            Save.optionPoint += pointIntFir;        // 엔딩 구분 옵션값
        }
        else
        {
            Save.optionPoint += 0;
        }

        if (GameManager.optionPlusNum < 3)
        {
            GameManager.optionPlusNum++;
        }
        else
        {
            GameManager.optionPlusNum = 3;
        }

        LovePointButton.SetActive(true);

        stringEventTextImage.gameObject.SetActive(true);
        stringEventText.gameObject.SetActive(true);
        cgImage.gameObject.SetActive(true);
        cgImageBg.gameObject.SetActive(true);

        GameManager.divEventInt = 1;        // 첫번째 버튼 클릭 시 구분값

        Save.stringEventOption = GameManager.stringOption;

        GameManager.stringOption++;

        Save.eventStartPoint = 1;       // 1일때 이벤트 실행, 0일때 이벤트 종료
    }

    public void OnClickSecOptionButton()       // 2번째 버튼 클릭 시 발생해야 하는 상황
    {
        loveStringSec = CsvRead.doubleChatOptionList[GameManager.optionPlusNum, 4];
        loveIntSec = int.Parse(loveStringSec);

        pointStringSec = CsvRead.doubleChatOptionList[GameManager.optionPlusNum, 6];
        pointIntSec = int.Parse(pointStringSec);

        Save.Liking += loveIntSec;
        LoveBarContraller.curLike += loveIntSec;

        if (Save.eventStartPoint == 0)
        {
            Save.optionPoint += pointIntSec;        // 엔딩 구분 옵션값
        }
        else
        {
            Save.optionPoint += 0;
        }    

        if (GameManager.optionPlusNum < 3)
        {
            GameManager.optionPlusNum++;
        }
        else
        {
            GameManager.optionPlusNum = 3;
        }

        LovePointButton.SetActive(true);

        stringEventTextImage.gameObject.SetActive(true);
        stringEventText.gameObject.SetActive(true);
        cgImage.gameObject.SetActive(true);
        cgImageBg.gameObject.SetActive(true);

        GameManager.divEventInt = 2;    // 두번째 버튼 클릭 시 구분값

        Save.stringEventOption = GameManager.stringOption;

        GameManager.stringOption++;

        Save.eventStartPoint = 1;
    }
}
