using System;
using Bountier.Core.Lootbox;
using UnityEngine;

namespace Bountier.Core.Loot
{
    [Serializable]
    public class LootTable
    {
        [SerializeField] private LootboxToken[] _tokens;

        public LootboxToken[] Tokens => _tokens;
    }
}
