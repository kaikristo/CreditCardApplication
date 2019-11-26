using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CreditCardApplication
{
    public class ButtonApplyFilter : MonoBehaviour
    {
        [SerializeField]
        private Dropdown bankFilterValue, brandFilterValue, validityFilterValue;
        private Button applyButton;
        private void Start()
        {
            applyButton = GetComponent<Button>();
            applyButton.onClick.AddListener(() => { SetFilters(); });
        }

        private void SetFilters()
        {
            string bank = System.String.IsNullOrEmpty(bankFilterValue.captionText.text) ? "" : bankFilterValue.captionText.text;
            
            string brand = System.String.IsNullOrEmpty(brandFilterValue.captionText.text) ? "" : brandFilterValue.captionText.text;
            
            string validStr = System.String.IsNullOrEmpty(validityFilterValue.captionText.text) ? "" : validityFilterValue.captionText.text;
            bool validFilter = validStr == "" ? false : true;
            bool valid = validStr == "True" ? true : false;

            CreditCardListDisplayer.instance.Filter.SetFilter(brand,bank, validFilter,valid);
            CreditCardListDisplayer.instance.DisplayList();
            

        }
    }
}
