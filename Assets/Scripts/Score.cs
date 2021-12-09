using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int score = 0;
    //public static int packages = 0;
    public Text palletText;
    // public Text packageText;
    public string targetLevel;


    // Start is called before the first frame update
    void Start()
    {
        palletText = GetComponent<Text>();
        //packageText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        palletText.text = "Pallets Loaded: " + score;
       // packageText.text = "Packages" + packages;

        if (score == 3)
        {
            SwitchLevel(false, targetLevel);
        }
    }

    static public void SwitchLevel(bool restartCurrent, string level = "")
    {
        if (restartCurrent)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            SceneManager.LoadScene(level);
    }
}
