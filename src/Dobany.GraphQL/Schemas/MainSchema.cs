﻿using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using Dobany.Queries.Container;
using System;

namespace Dobany.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}