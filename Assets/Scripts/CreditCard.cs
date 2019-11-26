using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CreditCardApplication
{
    public class CreditCard
    {
        

        private CreditCardInfo info;

        private string bin;
        private bool validity;

      
        public void SetCardInformation(string bin, CreditCardInfo values)
        {
            this.bin = bin;
            info = values;
        }

        public string GetBrand()
        {
            if (info.scheme != null)
                return info.scheme;
            else
                return "unknown";
        }

        public string GetBankName()
        {
           
            if (info.bank != null)
                return info.bank.name;
            else
                return "unknown";
           
        }

        public string GetCardNumber()
        {
            return bin;
        }

        public bool GetValidity()
        {
            validity = (bin.Length >= 12) && (bin.Length <= 19) && (info.number.luhn) && bin[0] != '0';
            return validity;
        }

        // Declare the list
        List<Action> actions = new List<Action>();

        // Add two delegates to the list that point to 'SomeMethod' and 'SomeMethod2'

        /*
         * put nessesary getters here
         */



    }
}