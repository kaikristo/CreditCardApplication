using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CreditCardApplication
{
    public class ButtonAddListener : MonoBehaviour
    {
        private Button button;
        public Text input;
        void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => { StartCoroutine(WaitAndUpdate()); });
        }
        IEnumerator WaitAndUpdate()
        {
            //disable button until the result
            button.interactable = false;
            if (input.text.Length == 0)
            {
                button.interactable = true;
                yield break;
            }
            
            ApiRequester.instance.Request(input.text);
            
            float timer = 0;
            //max time to request
            float timeOut = 4f;
            
            bool failed = false;

            while (ApiRequester.instance.RequestResult == null)
            {
                if (ApiRequester.instance.Error)
                    break;
                if (timer > timeOut)
                {           
                    failed = true;
                    break;
                }
                timer += Time.deltaTime;
                yield return null;
            }

            button.interactable = true;
            if (failed)
            {
                Debug.Log("Request timeout");
                yield break;
            }
            else
            if(ApiRequester.instance.Error)
            {
                Debug.LogError("Request:Error");
            }
            else
            {
                CreditCardList.instance.CreditCards.Add(ApiRequester.instance.RequestResult);
                ApiRequester.instance.ClearRequest();
                CreditCardListDisplayer.instance.DisplayList();
            }
        }
    }
}