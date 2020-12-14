using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ORMServices
{
    public class AutoMapperResolver
    {
        public static IEnumerable<Profile> GetProfiles()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            IEnumerable<Profile> profiles = assembly.GetTypes()
                .Where(t => typeof(Profile).IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<Profile>();

            return profiles;
        }
    }
}