﻿using System;
namespace Desafio.Domain.Services.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task Create(T entity);
        Task Delete(T id);
        Task<T> GetById(Guid id);
    }
}

