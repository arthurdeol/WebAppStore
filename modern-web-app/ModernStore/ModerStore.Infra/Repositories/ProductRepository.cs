﻿using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModerStore.Infra.Contexts;
using System;
using System.Linq;

namespace ModerStore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ModernStoreDataContext _context;
        public ProductRepository(ModernStoreDataContext context)
        {
            _context = context;
        }
        public Product Get(Guid id)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}
