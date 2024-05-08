using System.Collections.Generic;
using Bountier.Core.Data;
using Bountier.Core.Loot;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Bountier.Core.Lootbox
{
    public class LootboxOpener
    {
        private LootboxDatabase _lootboxDatabase;
        private LootDatabase _lootDatabase;

        [Inject]
        public LootboxOpener(LootboxDatabase lootboxDatabase, LootDatabase lootDatabase)
        {
            _lootboxDatabase = lootboxDatabase;
            _lootDatabase = lootDatabase;
        }

        public LootContainer[] OpenLootbox(string lootboxId, int amount)
        {
            //Debug.Log("Lootbox amount to open " + amount);
            var lootbox = _lootboxDatabase.GetLootboxData(lootboxId);

            var loot = new List<LootContainer>();

            for (var i = 0; i < amount; i++)
            {
                var tables = lootbox.GetTables();
                //Debug.Log("Tables to roll " + tables.Length);

                foreach (var table in tables)
                {
                    var totalWeight = 0f;

                    foreach (var token in table.Tokens)
                    {
                        totalWeight += token.Weight;
                    }

                    var randomWeight = Random.Range(0f, totalWeight);
                    //Debug.Log("Random weight: " + randomWeight);

                    foreach (var token in table.Tokens)
                    {

                        randomWeight -= token.Weight;
                        if (randomWeight <= 0)
                        {
                            //Debug.Log("Add item: " + token.Loot.Name);
                            var tokenAmount = token.GetAmount();
                            var container = new LootContainer(token.LootId, tokenAmount);
                            loot.Add(container);
                            break;
                        }
                    }
                }
            }
            
            foreach (var item in loot)
            {
                Debug.Log(item.LootId);
            }

            return loot.ToArray();
        }
    }
}
