using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CreditCardApplication
{
    public class CreditCardFilter
    {
        //filters
        private string brand;
        private string bank;
        //should we use validity filter?
        private bool validFilter;
        private bool validValue;

        public CreditCardFilter()
        {
            this.brand = "";
            this.bank = "";
            this.validFilter = false;
            this.validValue = false;
        }

        public void SetFilter(string brand, string bank, bool validFilter, bool validValue)
        {
            this.brand = brand;
            this.bank = bank;
            this.validFilter = validFilter;
            this.validValue = validValue;
        }


        //getting filtered result
        public List<CreditCard> GetList(List<CreditCard> creditCards)
        {
            if (creditCards.Count == 0) return null;
            List<CreditCard> filteredList = new List<CreditCard>();
            foreach (var item in creditCards)
            {
                bool res = true;
                
                
                res &= brand.Length > 0 ? brand == item.GetBrand() : true;
                res &= bank.Length > 0 ? bank == item.GetBankName() : true;
                res &= validFilter ? validValue == item.GetValidity() : true;
                 if (res)
                {
                    filteredList.Add(item); 
                }

            }
            return filteredList;
        }
    }
}
