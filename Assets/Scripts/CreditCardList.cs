using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CreditCardApplication
{
    public class CreditCardList : MonoBehaviour
    {
        public static CreditCardList instance;
        private List<CreditCard> creditCards;

        public List<CreditCard> CreditCards { get => creditCards; set => creditCards = value; }

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
                //DontDestroyOnLoad(this);
            }
           
        }

        private void Start()
        {
            CreditCards = new List<CreditCard>();
        }
    }
}