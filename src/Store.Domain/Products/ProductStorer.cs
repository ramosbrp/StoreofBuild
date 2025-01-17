﻿using Store.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Products
{
    public class ProductStorer
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        //Construtor
        public  ProductStorer(IRepository<Product> productRepository, IRepository<Category> categoryRepository )
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        //Lógica de persistência
        public void Store(ProductDto dto) 
        {
            var category = _categoryRepository.GetById(dto.Category);

            DomainException.When(category == null, "Category invalid");

            var product = _productRepository.GetById(dto.Id);
            if (product == null)
            {
                product = new Product(dto.Name, category, dto.Price, dto.StockQuantity);
                _productRepository.Save(product);
            }
            else
            {
                product.Update(dto.Name, category, dto.Price, dto.StockQuantity);
            }
        }
    }
}
