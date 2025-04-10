﻿using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(int? id);

        //Task<ProductDTO> GetProductCategory(int? id);
        Task Add(ProductDTO producDto);
        Task Update(ProductDTO producDto);
        Task Remove(int? id);
    }
}
