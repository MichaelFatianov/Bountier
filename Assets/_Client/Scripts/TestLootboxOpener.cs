using Bountier.Core.Loot;
using Bountier.Core.Lootbox;
using UnityEngine;
using VContainer;

public class TestLootboxOpener : MonoBehaviour
{
     private LootboxOpener _opener;
     private LootStorage _storage;

    [Inject]
    private void Construct(LootboxOpener opener, LootStorage storage)
    {
        _opener = opener;
        _storage = storage;
    }

    [ContextMenu("OpenWoodenChest")]
    public void OpenWoodenChest()
    {
        var lootbox = _storage.RetrieveLoot("26", 1);
        if (lootbox == null) return;
        var loot = _opener.OpenLootbox(lootbox.Value.LootId, 1);  
        _storage.AddLootContainers(loot);
    }

    public void OpenWoodenChestX10()
    {
        var loot = _opener.OpenLootbox("WoodenChest", 10);
        _storage.AddLootContainers(loot);
    }

    [ContextMenu("Buy woodchest")]
    public void BuyWoodenChest()
    {
        var gold = _storage.RetrieveLoot("15", 100);
        if (gold != null)
        {
            _storage.AddLoot("26", 1);
        }
    }

    [ContextMenu("Start Items")]
    public void AddStartItems()
    {
        _storage.AddLoot("15", 100);
    }
}
