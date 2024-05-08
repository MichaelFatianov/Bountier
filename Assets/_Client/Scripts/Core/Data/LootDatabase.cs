using System.Collections.Generic;
using Bountier.Core.Loot;
using UnityEngine;
using VContainer.Unity;

namespace Bountier.Core.Data
{
    [CreateAssetMenu(menuName = "Database/Loot", fileName = "Database_Loot")]
    public class LootDatabase : Database, IInitializable
    {
        [SerializeField] private LootData[] _lootEntities;
        private Dictionary<string, LootData> _mappedLootEntities;

        public LootDatabase(LootData[] lootEntities)
        {
            _lootEntities = lootEntities;
            Initialize();
        }
        
        public void Initialize()
        {
            _mappedLootEntities = new Dictionary<string, LootData>();
            
            foreach (var lootEntity in _lootEntities)
            {
                _mappedLootEntities.Add(lootEntity.Name, lootEntity);
            }
        }
    }
}