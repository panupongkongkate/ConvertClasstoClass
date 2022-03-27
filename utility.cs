﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.datamodal;

namespace ConsoleApp1
{
    public static class utility
    {
        public static T Cast<T>(this Object myobj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);

                propertyInfo.SetValue(x, value, null);
            }
            return (T)x;
        }
        public static T ConvertClass<T>(object DataModels)
        {
            if (DataModels != null)
            {
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(DataModels));
            }
            else
            {
                return default;
            }
        }
        public static T ConvertglobalClass<T>(this object DataModels)
        {
            if (DataModels != null)
            {
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(DataModels));
            }
            else
            {
                return default;
            }
        }
    }
}
