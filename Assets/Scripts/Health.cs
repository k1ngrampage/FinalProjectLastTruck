using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    Image Healthbar;
    float healthCapacity = 100f;
    public static float health;

    // Start is called before the first frame update
    void Start()
    {
        Healthbar = GetComponent<Image>();
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.fillAmount = health / healthCapacity;

        if (health == 0f)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
