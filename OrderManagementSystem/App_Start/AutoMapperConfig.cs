using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OrderManagementSystem.App_Start
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            List<Profile> profiles = assembly.GetTypes()
                .Where(t => typeof(Profile).IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<Profile>()
                .ToList();

            // Add any assemblies which the API is dependent upon.
            profiles.AddRange(ORMServices.AutoMapperResolver.GetProfiles());

            Mapper.Initialize(p => profiles.ForEach(p.AddProfile));
            Mapper.AssertConfigurationIsValid();
        }
    }
}