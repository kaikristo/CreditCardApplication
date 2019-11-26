using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CreditCardApplication
{
    public class CreditCardDisplayer : MonoBehaviour
    {
        [SerializeField]
        private Text numberText, brandText, validityText, bankText;

        public static CreditCardDisplayer instance;

        void Awake()
        {
            if (instance != null)
            {
                if (instance != this)
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {
                instance = this;
                
            }
        }

        public void SetInfo(CreditCard card)
        {
            numberText.text = card.GetCardNumber();
            brandText.text = card.GetBrand();
            validityText.text = card.GetValidity().ToString();
            bankText.text = card.GetBankName();
        }
    }
}