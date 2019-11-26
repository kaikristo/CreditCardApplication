using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreditCardTextReferences : MonoBehaviour
{
    public static int count = 0;
  
    [SerializeField]
    private Text cardNumber, cardBrand, cardValidity;

    public Text CardNumber { get => cardNumber; set => cardNumber = value; }
    public Text CardBrand { get => cardBrand; set => cardBrand = value; }
    public Text CardValidity { get => cardValidity; set => cardValidity = value; }

    private void Awake()
    {
        count++;
    }
    private void OnDestroy()
    {
        count--;   
    }


}
