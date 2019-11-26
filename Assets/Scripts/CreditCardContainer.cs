using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreditCardApplication
{
    public class CreditCardContainer : MonoBehaviour
    {
        //reference to card in list
        private CreditCard card;

        public void SetCardReference(CreditCard cardReference)
        {
            card = cardReference;
        }
        public CreditCard GetCardReference()
        {
            return card;
        }
    }
}
