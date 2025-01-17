﻿using Store.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Products
{
    class CategoryStorer
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryStorer(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Sotore(CategoryDto dto)
        {
            var category = _categoryRepository.GetById(dto.Id);

            if(category == null)
            {
                category = new Category(dto.Name);
                _categoryRepository.Save(category);
            }
            else
            {
                category.Update(dto.Name);
            }
        }
    }
}
