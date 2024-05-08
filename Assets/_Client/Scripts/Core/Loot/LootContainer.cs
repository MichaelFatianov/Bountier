namespace Bountier.Core.Loot
{
    public struct LootContainer
    {
        private string _lootId;
        private int _amount;
        
        public string LootId => _lootId;
        public int Amount => _amount;

        public LootContainer(string lootId, int amount = 0)
        {
            _lootId = lootId;
            _amount = amount;
        }

        public void AddLoot(int amount)
        {
            _amount += amount;
        }

        public bool RemoveLoot(int amount)
        {
            if (_amount < amount) return false;
            _amount -= amount;
            return true;
        }
    }
}