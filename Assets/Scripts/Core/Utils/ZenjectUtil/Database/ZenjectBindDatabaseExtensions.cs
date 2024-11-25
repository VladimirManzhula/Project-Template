using Zenject;

namespace Core.Utils.ZenjectUtil.Database
{
    public static class ZenjectBindDatabaseExtensions
    {
        public static ConcreteIdArgConditionCopyNonLazyBinder BindDatabase<T>(
            this DiContainer container,
            T instance
        )
        {
            container.Inject(instance);
            if (instance is IInitializable initializable)
            {
                container.BindInitializableExecutionOrder(instance.GetType(), -10000);
                container.Bind<IInitializable>().FromInstance(initializable).AsCached();
            }

            return container.Bind<T>().FromSubstitute(instance);
        }
        
        public static void BindDatabaseWithDao<TDao, TBase>(
            this DiContainer container,
            TDao instance
        )
        {
            container.Bind<TDao>().FromSubstitute(instance).WhenInjectedInto<TBase>();
            container.BindInterfacesTo<TBase>().AsSingle();
        }
    }
}