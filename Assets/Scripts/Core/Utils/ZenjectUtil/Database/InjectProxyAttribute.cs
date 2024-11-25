using System;
using Zenject;

namespace Core.Utils.ZenjectUtil.Database
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property)]
    public class InjectProxyAttribute : InjectAttributeBase
    {
        public const string PROXY_ID = "Proxy";

        public InjectProxyAttribute() => Id = PROXY_ID;
    }
}