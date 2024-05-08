using System;
using System.Collections.Generic;
using _Client_.Scripts.GoogleSheetExtension.Objects;
using Bountier.Core.Data;
using Bountier.Core.Loot;
using Bountier.Core.Loot.Enum;
using UnityEditor;
using UnityEngine;

namespace _Client_.Scripts.Utils.Extensions.GoogleSheetExtension.Objects
{
    public class DatabaseLoader : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private string _path;
        [SerializeField] private GoogleSheetsSettings _settings;
        
        
        [ContextMenu("LoadData")]
        private async void LoadData()
        {
            var data = GoogleSheetLoader.GetSheetData<SheetFeed>(_settings.Url, "Entities!A1:Z", _settings.Api);
            
            await data;
            Debug.Log($"{data.Result.values}");
                
            UpdateData(data.Result.values);
        }

        private void UpdateData(string[][] data)
        {
            UpdateLoot(data);
            UpdateLootboxes(data);
        }

        private void UpdateLoot(string[][] data)
        {
            var lootData = new List<LootData>();
            
            for (var i = 1; i < data.Length; i++)
            {
                if(!string.IsNullOrEmpty(data[i][1]))
                {
                     Debug.Log($"Id: {data[i][0]}, Name:{data[i][1]}, maxStack: {data[i][2]}, category: {Enum.Parse<LootCategory>(data[i][3])}");
                    var newData = new LootData(
                        data[i][0],
                        data[i][1],
                        int.Parse(data[i][2]),
                        Enum.Parse<LootCategory>(data[i][3])
                        );
                    lootData.Add(newData);
                }
            }

            var asset = new LootDatabase(lootData.ToArray());
            AssetDatabase.CreateAsset(asset, $"{_path}Database_Loot.asset");
            AssetDatabase.SaveAssets();
        }
        
        private void UpdateLootboxes(string[][] data)
        {
            
        }
        
#endif
    }
}
