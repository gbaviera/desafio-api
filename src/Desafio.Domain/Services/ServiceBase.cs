﻿using Desafio.Domain.Base;
using Desafio.Domain.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace Desafio.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : EntityBase
    {
        private readonly IRepositoryBase<T> _baseRepository;
        private readonly IValidator<T> _validator;

        public ServiceBase(IRepositoryBase<T> baseRepository, IValidator<T> validator)
        {
            _baseRepository = baseRepository;
            _validator = validator;
        }

        public virtual Task<ExecutionResult<T>> Create<TValidator>(T obj)
        {
            var validationResult = Validate(obj, _validator);

            if (!validationResult.IsValid)
                return default;

            _baseRepository.Create(obj);

            var result = new ExecutionResult<T> { Data = obj, ValidationResult = validationResult };

            return Task.FromResult(result);
        }

        public virtual Task Delete(T entity)
        {
            return _baseRepository.Delete(entity);
        }

        public virtual async Task<T> GetById(Guid id) => await _baseRepository.GetById(id);

        public virtual async Task<ExecutionResult<T>> Update<TValidator>(T obj)
        {
            var result = Validate(obj, _validator);

            if (!result.IsValid)
                return default;

            return await Task.FromResult(new ExecutionResult<T> { Data = obj, ValidationResult = result });
        }

        public virtual ValidationResult Validate(T obj, IValidator<T> validator)
        {
            if (obj == null)
                throw new NullReferenceException("Object is Null " + typeof(T));

            return validator.Validate(obj);
        }

    }
}
