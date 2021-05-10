using System;
using System.Globalization;
using System.Reflection;

namespace Bannerlord.Python.Utils
{
    internal sealed class WrappedConstructorInfo : ConstructorInfo
    {
        private readonly object[] _args;
        private readonly ConstructorInfo _constructorInfoImplementation;

        public WrappedConstructorInfo(ConstructorInfo actualConstructorInfo, object[] args)
        {
            _constructorInfoImplementation = actualConstructorInfo;
            _args = args;
        }

        public override object[] GetCustomAttributes(bool inherit) =>
            _constructorInfoImplementation.GetCustomAttributes(inherit);

        public override bool IsDefined(Type attributeType, bool inherit) =>
            _constructorInfoImplementation.IsDefined(attributeType, inherit);

        public override ParameterInfo[] GetParameters() => _constructorInfoImplementation.GetParameters();

        public override MethodImplAttributes GetMethodImplementationFlags() =>
            _constructorInfoImplementation.GetMethodImplementationFlags();

        public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters,
            CultureInfo culture) =>
            _constructorInfoImplementation.Invoke(obj, invokeAttr, binder, parameters, culture);

        public override string Name => _constructorInfoImplementation.Name;
        public override Type? DeclaringType => _constructorInfoImplementation.DeclaringType;
        public override Type? ReflectedType => _constructorInfoImplementation.ReflectedType;
        public override RuntimeMethodHandle MethodHandle => _constructorInfoImplementation.MethodHandle;
        public override MethodAttributes Attributes => _constructorInfoImplementation.Attributes;

        public override object[] GetCustomAttributes(Type attributeType, bool inherit) =>
            _constructorInfoImplementation.GetCustomAttributes(attributeType, inherit);

        public override object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters,
            CultureInfo culture) =>
            _constructorInfoImplementation.Invoke(invokeAttr, binder, _args, culture);
    }
}