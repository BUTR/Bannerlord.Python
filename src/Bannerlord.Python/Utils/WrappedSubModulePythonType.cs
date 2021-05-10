using HarmonyLib.BUTR.Extensions;

using System;
using System.Globalization;
using System.Reflection;

namespace Bannerlord.Python.Utils
{
    internal class WrappedSubModulePythonType : Type
    {
        private readonly Type _typeImplementation = typeof(SubModulePython);

        private readonly string _moduleFolder;
        private readonly string _scriptName;
        private readonly string _subModuleClassType;

        public WrappedSubModulePythonType(string moduleFolder, string scriptName, string subModuleClassType)
        {
            _moduleFolder = moduleFolder;
            _scriptName = scriptName;
            _subModuleClassType = subModuleClassType;
        }

        private ConstructorInfo? GetWrappedConstructor()
        {
            var constructorInfo = AccessTools2.Constructor(typeof(SubModulePython), new[] {typeof(string), typeof(string), typeof(string)});
            if (constructorInfo is null) return null;
            return new WrappedConstructorInfo(constructorInfo, new object[] {_moduleFolder, _scriptName, _subModuleClassType});
        }

        public override object[] GetCustomAttributes(bool inherit) => _typeImplementation.GetCustomAttributes(inherit);
        public override bool IsDefined(Type attributeType, bool inherit) => _typeImplementation.IsDefined(attributeType, inherit);
        public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr) => _typeImplementation.GetConstructors(bindingAttr);
        public override Type GetInterface(string name, bool ignoreCase) => _typeImplementation.GetInterface(name, ignoreCase);
        public override Type[] GetInterfaces() => _typeImplementation.GetInterfaces();
        public override EventInfo? GetEvent(string name, BindingFlags bindingAttr) => _typeImplementation.GetEvent(name, bindingAttr);
        public override EventInfo[] GetEvents(BindingFlags bindingAttr) => _typeImplementation.GetEvents(bindingAttr);
        public override Type[] GetNestedTypes(BindingFlags bindingAttr) => _typeImplementation.GetNestedTypes(bindingAttr);
        public override Type GetNestedType(string name, BindingFlags bindingAttr) => _typeImplementation.GetNestedType(name, bindingAttr);
        public override Type? GetElementType() => _typeImplementation.GetElementType();
        protected override bool HasElementTypeImpl() => _typeImplementation.HasElementType;
        protected override PropertyInfo? GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
            => _typeImplementation.GetProperty(name, bindingAttr, binder, returnType, types, modifiers);
        public override PropertyInfo[] GetProperties(BindingFlags bindingAttr) => _typeImplementation.GetProperties(bindingAttr);
        protected override MethodInfo? GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
            => _typeImplementation.GetMethod(name, bindingAttr, binder, callConvention, types, modifiers);
        public override MethodInfo[] GetMethods(BindingFlags bindingAttr) => _typeImplementation.GetMethods(bindingAttr);
        public override FieldInfo? GetField(string name, BindingFlags bindingAttr) => _typeImplementation.GetField(name, bindingAttr);
        public override FieldInfo[] GetFields(BindingFlags bindingAttr) => _typeImplementation.GetFields(bindingAttr);
        public override MemberInfo[] GetMembers(BindingFlags bindingAttr) => _typeImplementation.GetMembers(bindingAttr);
        protected override TypeAttributes GetAttributeFlagsImpl() => _typeImplementation.Attributes;
        protected override bool IsArrayImpl() => _typeImplementation.IsArray;
        protected override bool IsByRefImpl() => _typeImplementation.IsByRef;
        protected override bool IsPointerImpl() => _typeImplementation.IsPointer;
        protected override bool IsPrimitiveImpl() => _typeImplementation.IsPrimitive;
        protected override bool IsCOMObjectImpl() => _typeImplementation.IsCOMObject;
        public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
            => _typeImplementation.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);

        public override Type UnderlyingSystemType => _typeImplementation.UnderlyingSystemType;
        protected override ConstructorInfo? GetConstructorImpl(BindingFlags bindingAttr, Binder? binder, CallingConventions callConvention, Type[] types, ParameterModifier[]? modifiers)
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance;
            if (bindingAttr == flags && binder == null && types.Length == 0 && modifiers == null)
                return GetWrappedConstructor();
            return _typeImplementation.GetConstructor(bindingAttr, binder, callConvention, types, modifiers);
        }

        public override string Name => _typeImplementation.Name;
        public override Guid GUID => _typeImplementation.GUID;
        public override Module Module => _typeImplementation.Module;
        public override Assembly Assembly => _typeImplementation.Assembly;
        public override string? FullName => _typeImplementation.FullName;
        public override string? Namespace => _typeImplementation.Namespace;
        public override string? AssemblyQualifiedName => _typeImplementation.AssemblyQualifiedName;
        public override Type? BaseType => _typeImplementation.BaseType;
        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
            => _typeImplementation.GetCustomAttributes(attributeType, inherit);
    }
}