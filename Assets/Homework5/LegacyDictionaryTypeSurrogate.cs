using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;


namespace Assets.Homework5
{
    class LegacyDictionaryTypeSurrogate : IDataContractSurrogate
    {
        #region Methods

        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        public Type GetDataContractType(Type type)
        {
            throw new NotImplementedException();
        }

        public object GetDeserializedObject(object obj, Type targetType)
        {
            throw new NotImplementedException();
        }

        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            throw new NotImplementedException();
        }

        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new NotImplementedException();
        }

        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
