using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeChatOption : MonoBehaviour
{
    private bool state;
    int liking = 0;
    // Start is called before the first frame update
    void Start()
    {
        state = false;
    }

    // Update is called once per frame
    void Update()
    {
        liking = Save.Liking;

        if(Input.GetMouseButtonDown(0))
        {
            if (liking == 100)
            {
                gameObject.SetActive(true);

                state = true;
            }
            else if (liking == 200)
            {
                gameObject.SetActive(true);

                state = true;
            }
            else if (liking == 300)
            {
                gameObject.SetActive(true);

                state = true;
            }
            else if (liking == 400)
            {
                gameObject.SetActive(true);

                state = true;
            }
            else if (liking == 500)
            {
                gameObject.SetActive(true);

                state = true;
            }
            else
            {
                gameObject.SetActive(false);

                state = false;
            }
        }
    }
}
