﻿using BalancedHealhtDiet.Data.Configuration;
using BalancedHealhtDiet.Data.Entitites;
using BancedHealthyDiet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private BalanceDietAppContext context;
        private IGenericRepository<Recipe> recipesRepository;
        private IGenericRepository<Ingredient> ingredientsRepository;
        private IGenericRepository<Nutrition> nutritionsRepository;
        private IGenericRepository<Product> productsRepository;
        private IGenericRepository<Category> categoryRepository;
        //IDbContext
        public UnitOfWork(BalanceDietAppContext context)
        {
            this.context = context;
        }
        public IGenericRepository<Recipe> Recipes
        {
            get
            {
                if (recipesRepository == null)
                    recipesRepository = new Repository<Recipe>(context);
                return recipesRepository;
            }
        }

        public IGenericRepository<Ingredient> Ingredients
        {
            get
            {
                if (ingredientsRepository == null)
                    ingredientsRepository = new Repository<Ingredient>(context);
                return ingredientsRepository;
            }
        }

        public IGenericRepository<Nutrition> Nutritions
        {
            get
            {
                if (nutritionsRepository == null)
                    nutritionsRepository = new Repository<Nutrition>(context);
                return nutritionsRepository;
            }
        }

        public IGenericRepository<Product> Products
        {
            get
            {
                if (productsRepository == null)
                    productsRepository = new Repository<Product>(context);
                return productsRepository;
            }
        }
        public IGenericRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new Repository<Category>(context);
                return categoryRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
