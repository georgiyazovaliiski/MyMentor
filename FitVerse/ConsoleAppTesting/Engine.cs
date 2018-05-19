using System;

namespace ConsoleAppTesting
{
    internal class Engine
    {
        private IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public void Run()
        {
            
        }
    }
}