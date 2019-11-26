using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Dropdown;

namespace CreditCardApplication
{
    public class CreditCardFilterUI : MonoBehaviour
    {
        private Dropdown dropDown;

        [SerializeField]
        private Field fieldToFiltering;

       string lastOption;

        private void Awake()
        {
            dropDown = GetComponent<Dropdown>();
            dropDown.ClearOptions();
            lastOption = "";
        }
        private void OnEnable()
        {
            UpdateFilter();
        }
        private void OnDisable()
        {
            //save the last selected option
            lastOption= dropDown.options[dropDown.value].text;
            dropDown.ClearOptions();
        }

        private void UpdateFilter()
        {
            //filter contains only values who really exist in list
           
            if (CreditCardList.instance.CreditCards == null) return;

            List<string> options = new List<string>();
           
            foreach (var item in CreditCardList.instance.CreditCards)
            {
                switch (fieldToFiltering)
                {
                    case Field.BankName:
                        options.Add((item.GetBankName()));
                        break;
                    case Field.Validity:
                        options.Add((item.GetValidity().ToString()));
                        break;
                    case Field.Brand:
                        options.Add((item.GetBrand()));
                        break;
                    default:
                        break;
                }
            }
            //remove duplicate
            options = options.Distinct().ToList();
            //remove empty
            options = options.Where(item => !System.String.IsNullOrEmpty(item)).ToList();
            //add empty value (its mean no filter)
            options.Add("");
            
            
            //if lastoption not exist in new filter list - add lastoption to the filter list
            if(!options.Contains(lastOption))
            {
                options.Add(lastOption);
            }
           
            dropDown.AddOptions(options);
            //select lastoption
            dropDown.value = options.IndexOf(lastOption);
        }
        //field to filtering
        enum Field
        {
            BankName,
            Validity,
            Brand
        };

    }
}
