﻿using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using SieveUnitTests.Entities;

namespace SieveUnitTests.Services
{
	public class ApplicationSieveProcessor : SieveProcessor
    {
        public ApplicationSieveProcessor(
            IOptions<SieveOptions> options,
            ISieveCustomSortMethods customSortMethods,
            ISieveCustomFilterMethods customFilterMethods)
            : base(options, customSortMethods, customFilterMethods)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<Post>(p => p.ThisHasNoAttributeButIsAccessible)
                .CanSort()
                .CanFilter()
                .HasName("shortname");

            mapper.Property<Post>(p => p.OnlySortableViaFluentApi)
                .CanSort();

            return mapper;
        }
    }
}
