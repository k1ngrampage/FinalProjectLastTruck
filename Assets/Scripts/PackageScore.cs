using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageScore : MonoBehaviour
{
    public static int packages = 0;
    public Text packageText;
    // public Text packageText;


    // Start is called before the first frame update
    void Start()
    {
        //palletText = GetComponent<Text>();
        packageText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //palletText.text = "Pallets Loaded: " + score;
        packageText.text = "Packages: " + packages;
    }
}
