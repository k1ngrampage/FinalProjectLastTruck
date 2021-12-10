using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ClockType
{
    TimeOfDay,
    GameTime,
    Countdown
}

public class Clock : MonoBehaviour
{
    public Text timerText;
    public ClockType type;
    public float initialCountdownTime;
    float currentCountdownTime;

    // Start is called before the first frame update
    void Start()
    {
        currentCountdownTime = initialCountdownTime;
        StartCoroutine(UpdateTime());
    }

    // Update is called once per frame
    IEnumerator UpdateTime()
    {
        if (type == ClockType.Countdown)
        {
            Display(currentCountdownTime);
            yield return new WaitForSeconds(1);

            while (currentCountdownTime > 0)
            {
                currentCountdownTime--;
                Display(currentCountdownTime);
                yield return new WaitForSeconds(1);

            }
            Debug.Log("Times Up");
            //Placeholder Exit
            SceneManager.LoadScene("Menu");
        }
        else
        {
            while (true)
            {
                switch (type)
                {
                    case ClockType.TimeOfDay:
                        timerText.text = DateTime.Now.ToString();
                        break;
                    case ClockType.GameTime:
                        timerText.text = Time.time.ToString();
                        break;
                }
                yield return new WaitForSeconds(.5f);//check often enough to not skip a number but not every frame.
            }
        }
    }

    void Display(float displayTime)
    {
        if (displayTime < 0)
        {
            displayTime = 0;
        }

        float min = Mathf.FloorToInt(displayTime / 60);
        float sec = Mathf.FloorToInt(displayTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
