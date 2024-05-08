using System.Collections.Generic;
using Bountier.Core.Lootbox;
using UnityEngine;
using VContainer.Unity;

namespace Bountier.Core.Data
{
    [CreateAssetMenu(menuName = "Database/Lootbox", fileName = "Database_Lootbox")]
    public class LootboxDatabase : Database, IInitializable
    {
        [SerializeField] private LootboxData[] _lootboxesData;

        private Dictionary<string, LootboxData> _mappedLootboxesData = new();

        public void Initialize()
        {
            foreach (var data in _lootboxesData)
            {
                _mappedLootboxesData.Add(data.Id, data);
            }
        }
        
        public LootboxData GetLootboxData(string id)
        {
            return _mappedLootboxesData[id];
        }

        
    }
}
