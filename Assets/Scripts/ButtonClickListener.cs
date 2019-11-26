using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace CreditCardApplication
{
    public class ButtonClickListener : MonoBehaviour
    {
        private Button select;
        private CreditCardTextReferences references;
        private void Start()
        {
            select = GetComponent<Button>();
            select.onClick.AddListener(() => { ChoseCard(); });
        }

        private void ChoseCard()
        {

            CreditCard card = GetComponent<CreditCardContainer>().GetCardReference();
            CreditCardDisplayer.instance.SetInfo(card);
            

        }
    }
}
