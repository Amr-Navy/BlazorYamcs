using System;


namespace Yamcs.Client.Services
{
    public class InstantState
    {

        public string Instance { get; private set; }
        public string Processor { get; private set; }

        public event Action OnChange;

        public void SetInstance(string instance)
        {
            Instance = instance;
            Console.WriteLine(Instance);
            NotifyStateChanged();
        }
        public void Setprocessor(string processor)
        {
            Processor = processor;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

