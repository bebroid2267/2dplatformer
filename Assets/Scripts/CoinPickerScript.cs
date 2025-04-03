using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPickerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    private int countCoin;
    public TMP_Text coinText;

    private void Start()
    {
        coinText.text = "Собери все гемы!";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if ( collision.gameObject.tag == "gems")
        {
            countCoin++;
            coinText.text = countCoin.ToString() + " / 17";
            Destroy(collision.gameObject);
            if (countCoin == 17)
                Destroy(obj);
        }
       
        
    }

}
