using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreditCardApplication
{
    public class CreditCardListDisplayer : MonoBehaviour
    {

        public static CreditCardListDisplayer instance;

        [SerializeField]
        GameObject cardPref;
        [SerializeField]
        GameObject cardListContainer;

        private CreditCardFilter filter = new CreditCardFilter();


        private bool onConstruct = false;

        public CreditCardFilter Filter { get => filter;}

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

        public void DisplayList()
        {
         
            List<CreditCard> filteredList = filter.GetList(CreditCardList.instance.CreditCards);
            DestroyList();
            // foreach (var item in CreditCardList.instance.CreditCards)
            if (filteredList.Count == 0) return;
            foreach (var item in filteredList)
            {
                GameObject newRecord = Instantiate(cardPref, cardListContainer.transform);
                CreditCardTextReferences info = newRecord.GetComponent<CreditCardTextReferences>();
                info.CardNumber.text = item.GetCardNumber();
                info.CardBrand.text = item.GetBrand();
                info.CardValidity.text = item.GetValidity().ToString();
                newRecord.name = item.GetCardNumber();
                newRecord.GetComponent<CreditCardContainer>().SetCardReference(item);
            }
            onConstruct = false;
        }

        private void DestroyList()
        {
            foreach (var record in cardListContainer.GetComponentsInChildren<CreditCardTextReferences>())
            {
                Destroy(record.gameObject);
            }
        }

        private void FixedUpdate()
        {
        }
    }
}
