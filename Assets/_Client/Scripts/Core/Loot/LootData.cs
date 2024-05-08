using System;
using Bountier.Core.Loot.Enum;
using UnityEngine;

namespace Bountier.Core.Loot
{
    [Serializable]
    public struct LootData
    {
        [SerializeField] private string _name;
        [SerializeField] private string _id;
        [SerializeField] private int _maxStack;
        [SerializeField] private LootCategory _category;

        public string Name => _name;
        public int MaxStack => _maxStack;

        public LootData(string id, string name, int maxStack, LootCategory category)
        {
            _id = id;
            _name = name;
            _maxStack = maxStack;
            _category = category;
        }
    }
}

