using System;
using Bountier.Core.Loot;
using UnityEngine;

namespace Bountier.Core.Lootbox
{
    [Serializable]
    public class LootboxData
    {
        [SerializeField] private string _id;
        [SerializeField] private LootTable[] _tables;

        public string Id => _id;

        public LootTable GetTable(int index) => _tables[index];
        public LootTable[] GetTables() => _tables;
    }
}
