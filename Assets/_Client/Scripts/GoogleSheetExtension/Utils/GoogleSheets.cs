using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace _Client_.Scripts.Utils.Extensions
{
    public static class GoogleSheetLoader
    {
        public static async Task<T> GetSheetData<T>(string sheetURL, string sheetNumName, string apiKey) where T : class
        {
            var url =
                $"https://sheets.googleapis.com/v4/spreadsheets/{sheetURL}/values/{sheetNumName}?alt=json&key={apiKey}";
            return await GetSheetData<T>(url);
        }

        private static async Task<T> GetSheetData<T>(string url) where T : class
        {
            var webRequest =
                UnityWebRequest.Get(url);
            await webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.ConnectionError &&
                webRequest.result != UnityWebRequest.Result.ProtocolError)
                return JsonConvert.DeserializeObject<T>(webRequest.downloadHandler.text);

            Debug.Log($"Error: {webRequest.error}");
            return null;

        }
    }
}
