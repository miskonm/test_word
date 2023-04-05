using System;
using System.Collections.Generic;
using TW.Services.Ui.Views;

namespace TW.Services.Ui
{
    public class SimpleUiService : IUiService
    {
        private readonly ViewControllerFactory _factory;
        private readonly Dictionary<Type, ViewController> _controllersByType = new();

        public SimpleUiService(ViewControllerFactory factory)
        {
            _factory = factory;
        }
        
        public TController GetController<TController>() where TController : ViewController
        {
            var type = typeof(TController);
            if (!_controllersByType.ContainsKey(type))
            {
                _controllersByType.Add(type, _factory.Create<TController>()); 
            }

            return (TController)_controllersByType[type];
        }
    }
}