using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pallet : MonoBehaviour
{
    public static int palletScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        palletScore = Score.score;

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
            Score.score += 1;
        }
    }
}
