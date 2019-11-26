using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace CreditCardApplication
{
    public class ApiRequester : MonoBehaviour
    {
        const string URL = "https://lookup.binlist.net";

        public static ApiRequester instance;

        //need to know when request will be filled
        private CreditCard requestResult = null;
        private bool error = false;

        public CreditCard RequestResult { get => requestResult; }
        public bool Error { get => error; }

        private void Awake()
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




        /// <summary>
        /// Get Request
        /// </summary>
        /// <param name="bin">card number</param>
        public void Request(string bin)
        {   
            error = false;
            string request = URL;
            StartCoroutine(GetCardRequest(request, bin));
        }

        public void ClearRequest()
        {
            requestResult = null;
        }

        IEnumerator GetCardRequest(string uri, string bin)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri + "/" + bin))
            {

                yield return webRequest.SendWebRequest();

                if (webRequest.isNetworkError)
                {
                    Debug.Log(": Error: " + webRequest.error);
                    error = true;
                }
                else
                {
                    string response = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
                    //to many request
                    if(webRequest.responseCode==429)
                    {
                        error = true;
                        yield break;
                    }
                    if (response.Length != 0)
                    {
                        CreditCardInfo data = JsonUtility.FromJson<CreditCardInfo>(response);
                        CreditCard creditCard = new CreditCard();
                        creditCard.SetCardInformation(bin, data);
                        requestResult = creditCard;
                    }
                    else
                    {
                        error = true;
                        Debug.Log("Wrong card number");
                    }
                }

            }
        }







    }
}