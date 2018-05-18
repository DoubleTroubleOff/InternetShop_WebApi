﻿using Domain.Context;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Entities;
using UoWandRepositories.Interfaces;
using UoWandRepositories.Repositories;

namespace UoWandRepositories.UnitOfWork
{
    public class ShopUnitOfWork : IShopUnitOfWork //UnitOfWork for predmet area
    {
        private DbContext _dbContext;

        private ICategoryRepository categoryRepository;
        private IItemCharacteristicRepository itemCharacteristicRepository;
        private IItemRepository itemRepository;
        private IOrderRepository orderRepository;

        public ShopUnitOfWork(string connectionString,
            ICategoryRepository categoryRepository,
            IItemCharacteristicRepository itemCharacteristicRepository,
            IItemRepository itemRepository,
            IOrderRepository orderRepository)
        {
            _dbContext = new EFshopContext(connectionString);
            this.categoryRepository = categoryRepository;
            this.itemCharacteristicRepository = itemCharacteristicRepository;
            this.itemRepository = itemRepository;
            this.orderRepository = orderRepository;
        }

        public ICategoryRepository Categories
        {
            get
            {
                return categoryRepository;
            }
        }

        public IItemCharacteristicRepository ItemCharacteristics
        {
            get
            {
                return itemCharacteristicRepository;
            }
        }

        public IItemRepository Items
        {
            get
            {
                return itemRepository;
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                return orderRepository;
            }
        }
        /*
public IShopGenericRepository<Category> Categories
{
    get
    {
        if (categoryRepository == null)
            categoryRepository = new CategoryRepository(_dbContext);
        return categoryRepository;
    }
}

public IShopGenericRepository<ItemCharacteristic> ItemCharacteristics
{
    get
    {
        if (itemCharacteristicRepository == null)
            itemCharacteristicRepository = new ItemCharacteristicRepository(_dbContext);
        return itemCharacteristicRepository;
    }
}

public IShopGenericRepository<Item> Items
{
    get
    {
        if (itemRepository == null)
            itemRepository = new ItemRepository(_dbContext);
        return itemRepository;
    }
}

public IShopGenericRepository<Order> Orders
{
    get
    {
        if (orderRepository == null)
            orderRepository = new OrderRepository(_dbContext);
        return orderRepository;
    }
}*/

        public int Save()// Save changes
        {
            return _dbContext.SaveChanges();
        }

        // Disposes the current object
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        // Disposes all external resources.
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                {
                    if (_dbContext != null)
                    {
                        _dbContext.Dispose();
                    }
                }
            this.disposed = true;
        }
    }
}
