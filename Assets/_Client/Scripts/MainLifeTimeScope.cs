using Bountier.Core;
using Bountier.Core.Loot;
using Bountier.Core.Lootbox;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MainLifeTimeScope : LifetimeScope
{
    [SerializeField] private Database[] _databases;
    
    protected override void Configure(IContainerBuilder builder)
    {
        RegisterDatabases(builder);
        builder.Register<LootboxOpener>(Lifetime.Singleton);
        builder.Register<LootStorage>(Lifetime.Singleton);
        builder.RegisterEntryPoint<TestLootboxOpener>(Lifetime.Scoped);
    }


    private void RegisterDatabases(IContainerBuilder builder)
    {
        foreach (var database in _databases)
        {
            var type = database.GetType();
            builder.RegisterInstance(database).As(type, typeof(IInitializable));
        }
    }
}
