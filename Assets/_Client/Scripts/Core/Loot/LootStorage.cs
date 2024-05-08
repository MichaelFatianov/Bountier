using System.Collections.Generic;
using Bountier.Core.Data;
using UnityEngine;

namespace Bountier.Core.Loot
{
    public class LootStorage
    {
        private Dictionary<string, LootContainer> _lootEntities = new();
        private LootDatabase _lootDatabase;

        public bool IsEnough(string id, int amount)
        {
            if (_lootEntities.TryGetValue(id, out var lootEntity)) return lootEntity.Amount >= amount;
            Debug.LogWarning("There is no loot with id \"" + id + "\" in the storage");
            return false;
        }

        public LootContainer GetLoot(string id)
        {
            return _lootEntities.GetValueOrDefault(id);
        }

        public void DebugLoot()
        {
            foreach (var lootEntity in _lootEntities)
            {
                Debug.Log(lootEntity.Value);
            }
        }

        public bool AddLootContainers(LootContainer[] lootContainers)
        {
            foreach (var lootContainer in lootContainers)
            {
                AddLoot(lootContainer.LootId, lootContainer.Amount);
            }

            return true;
        }

        public LootContainer? RetrieveLoot(string lootId, int amount)
        {
            DebugLoot();
            var result = RemoveLoot(lootId, amount);
            if (!result) return null;
            var lootContainer = new LootContainer(lootId, amount);
            return lootContainer;
        }

        public void AddLoot(string id, int amount)
        {
            if (_lootEntities.ContainsKey(id))
            {
                _lootEntities[id].AddLoot(amount);
            }
            else
            {
                var lootContainer = new LootContainer(id, amount);
                _lootEntities.Add(id, lootContainer);
            }
        }

        private bool RemoveLoot(string id, int amount)
        {
            if (!_lootEntities.ContainsKey(id)) return false;
            if (!IsEnough(id, amount)) return false;
            
            _lootEntities[id].RemoveLoot(amount);
            if (_lootEntities[id].Amount == 0)
            {
                _lootEntities.Remove(id);
            }

            return true;
        }
    }
} 