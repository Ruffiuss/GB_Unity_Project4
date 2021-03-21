using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Reflection;
using System.CodeDom;
using System;


namespace Assets.Homework5
{
    public class LegacyDictionaryTypeSurrogate : IDataContractSurrogate
    {
        #region Methods

        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            Console.WriteLine("GetCustomDataToExport(Member)");
            FieldInfo fieldInfo = (FieldInfo)memberInfo;
            if (fieldInfo.IsPublic) return "public";
            else return "private";
        }

        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        public Type GetDataContractType(Type type)
        {
            throw new NotImplementedException();
        }

        public Type GetDataContractType<T1, T2>(Type type)
        {
            Console.WriteLine("GetDataContractType");
            if (typeof(Dictionary<T1, T2>).IsAssignableFrom(type))
            {
                return typeof(DictionarySurrogated<T1, T2>);
            }
            return type;
        }

        public object GetDeserializedObject(object obj, Type targetType)
        {
            throw new NotImplementedException();
        }

        public object GetDeserializedObject<T1, T2>(object obj, Type targetType)
        {
            Console.WriteLine("GetDeserializedObject");
            if (obj is DictionarySurrogated<T1, T2>)
            {
                Dictionary<T1, T2> dict = new Dictionary<T1, T2>();
                var dictProxy = new DictionaryProxy<T1, T2>(dict);
                                
                dictProxy.Dictionary.Add(((DictionarySurrogated<T1, T2>)obj).Key.KeySerializable, ((DictionarySurrogated<T1, T2>)obj).Key.ValuesSerializable);
                
                return dict;
            }
            return obj;
        }

        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            throw new NotImplementedException();
        }

        public object GetObjectToSerialize<T1, T2>(object obj, Type targetType)
        {
            Console.WriteLine("GetObjectToSerialize");
            if (obj is Dictionary<T1, T2>)
            {
                var dictProxy = new DictionaryProxy<T1, T2>((Dictionary<T1,T2>)obj);
                DictionarySurrogated<T1,T2> dictionarySurrogated = new DictionarySurrogated<T1, T2>();

                dictionarySurrogated.Key = new TKeySerializable<T1, T2>();

                foreach (var key in ((Dictionary<T1, T2>)obj).Keys)
                {
                    dictionarySurrogated.Key = new TKeySerializable<T1, T2>(key, ((Dictionary<T1, T2>)obj)[key]);
                }

                return dictionarySurrogated;
            }
            return obj;
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
