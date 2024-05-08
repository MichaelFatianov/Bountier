using UnityEngine;

namespace _Client_.Scripts.Utils.Extensions.GoogleSheetExtension.Objects
{
    [CreateAssetMenu(menuName = "Settings/Google Sheet Settings", fileName = "GoogleSheet_Settings")]
    public class GoogleSheetsSettings:ScriptableObject
    {
        [SerializeField] private string _url;
        [SerializeField] private string _api;

        public string Url => _url;
        public string Api => _api;
    }
}