using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bountier.Core.Lootbox
{
    [Serializable]
    public class LootboxToken
    {
        [SerializeField] private string _lootId;

        [SerializeField] private int _minAmount;
        [SerializeField] private int _maxAmount;
        
        [SerializeField] private int _weight;

        public string LootId => _lootId;
        public int Weight => _weight;

        public int MinAmount => _minAmount;

        public int MaxAmount => _maxAmount;

        public LootboxToken(string lootId, int weight, int minAmount, int maxAmount)
        {
            _lootId = lootId;
            _weight = weight;
            _minAmount = minAmount;
            _maxAmount = maxAmount;
        }

        public int GetAmount()
        {
            if (_maxAmount == -1)
            {
                return _minAmount;
            }

            var randomValue = Random.Range(_minAmount, _maxAmount + 1);
            return randomValue;
        }
    }
}

