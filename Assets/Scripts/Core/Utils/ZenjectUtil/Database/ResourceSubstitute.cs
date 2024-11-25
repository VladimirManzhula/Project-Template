using System;
using System.Collections.Generic;
using Zenject;

namespace Core.Utils.ZenjectUtil.Database
{
    public static class ResourceSubstitute
	{
		private static readonly Dictionary<Type, object> SubstituteData = new();

		public static ConcreteIdArgConditionCopyNonLazyBinder FromSubstitute<TContract>(
			this ConcreteIdBinderGeneric<TContract> binderGeneric,
			TContract instance
		)
		{
			if (instance == null)
				throw new Exception($"[{nameof(ResourceSubstitute)}] {typeof(TContract)} is null during binding");

			if (!GetSubstituteData(out TContract substitute))
				return binderGeneric.FromInstance(instance).AsSingle();

			return binderGeneric.FromMethodUntyped(context =>
			{
				context.Container.Bind<TContract>().WithId(InjectProxyAttribute.PROXY_ID).FromInstance(instance)
					.AsCached().WhenInjectedInto(substitute.GetType());
				context.Container.Inject(substitute);
				return substitute;
			}).AsSingle();
		}
		
		private static bool GetSubstituteData<TContract>(out TContract substitute)
		{
			substitute = default;
			if (!SubstituteData.TryGetValue(typeof(TContract), out var instance))
				return false;

			substitute = (TContract)instance;
			return true;
		}
	}
}