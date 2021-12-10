using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildPallet : MonoBehaviour
{
    public GameObject otherPalletText;
    public GameObject incPallet;
    public GameObject packageCountText;
    public GameObject onePackageCountText;
    public GameObject twoPackageCountText;

    //AudioSource soundEffect2;

    // Start is called before the first frame update
    void Start()
    {
        //otherPalletText = GetComponent<Text>();
        incPallet.SetActive(false);
        otherPalletText.SetActive(false);
        packageCountText.SetActive(false);
        onePackageCountText.SetActive(false);
        twoPackageCountText.SetActive(false);

       // soundEffect2 = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerControls.packageProgress == 3)
        {
            incPallet.SetActive(true);
            //soundEffect2.Play();
            Destroy(gameObject);
            Destroy(otherPalletText);
            Destroy(packageCountText);
            Destroy(onePackageCountText);
            Destroy(twoPackageCountText);
            
            PlayerControls.packageProgress = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            otherPalletText.SetActive(true);
            //packageCountText.SetActive(true);
            Invoke("UndoActive", 5);

            if (PlayerControls.packageProgress == 1)
            {
                onePackageCountText.SetActive(true);
            }

            else if (PlayerControls.packageProgress == 2)
            {
                twoPackageCountText.SetActive(true);
            }

            else
            {
                packageCountText.SetActive(true);
            }


            /*  if (Input.GetKeyDown(KeyCode.E))
              {
                  formPallet();
              } */
        }
    }

    void UndoActive()
    {
        otherPalletText.SetActive(false);
        packageCountText.SetActive(false);
        onePackageCountText.SetActive(false);
        twoPackageCountText.SetActive(false);
    }

    /*void formPallet()
    {
        Debug.Log("Pallet is being built.");
    } */
}
