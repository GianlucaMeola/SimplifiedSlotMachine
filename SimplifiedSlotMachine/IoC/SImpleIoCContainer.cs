namespace SimplifiedSlotMachine.IoC
{
    public class SimpleIoCContainer
    {
        private readonly Dictionary<Type, Func<object>> _registrations = new Dictionary<Type, Func<object>>();

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface, new()
        {
            _registrations[typeof(TInterface)] = () => new TImplementation();
        }

        public TInterface Resolve<TInterface>()
        {
            if (!_registrations.TryGetValue(typeof(TInterface), out var factory))
                throw new InvalidOperationException($"No registration found for type {typeof(TInterface)}");

            return (TInterface)factory();
        }
    }
}
