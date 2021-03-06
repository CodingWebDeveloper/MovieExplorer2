﻿using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using MovieExplorer.Web.ViewModels.Countries;
using MovieExplorer.Web.ViewModels.Directors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data.Tests.Common
{
    public static class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(CountryViewModel).GetTypeInfo().Assembly,
                typeof(Country).GetTypeInfo().Assembly);

            AutoMapperConfig.RegisterMappings(
               typeof(DirectorViewModel).GetTypeInfo().Assembly,
               typeof(Director).GetTypeInfo().Assembly);
        }


    }
}
