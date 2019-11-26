using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CreditCardApplication
{
    /*
     * JSON format from binlist.net
     */
    [Serializable]
    public class CreditCardInfo
    {
        public Number number;
        public string scheme;
        public string type;
        public string brand;
        public bool prepaid;
        public Country country;
        public Bank bank;

      

        

    }
    [Serializable]
    public class Number
    {
        public int length;
        public bool luhn;
    }
    [Serializable]
    public class Country
    {
        public string numeric;
        public string alpha2;
        public string name;
        public string emoji;
        public string currency;
        public int latitude;
        public int longitude;
    }

    [Serializable]
    public class Bank
    {
        public string name;
        public string url;
        public string phone;
        public string city;
    }
}