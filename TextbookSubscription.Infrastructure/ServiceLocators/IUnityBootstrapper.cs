﻿namespace TextbookSubscription.Infrastructure.ServiceLocators
{
    using Microsoft.Practices.Unity;

    /// <summary>
    /// Unity容器初始化器
    /// </summary>
    public interface IUnityBootstrapper
    {
        /// <summary>
        /// 类型注册
        /// </summary>
        /// <param name="container">Unity容器</param>
        void RegisterTypes(IUnityContainer container);
    }
}
