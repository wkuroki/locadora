namespace Locadora.Service.Services
{
    using FluentValidation;
    using Locadora.Entities;
    using Locadora.Infra.Data.Repository;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Classe base para services (Interno)
    /// </summary>
    /// <typeparam name="T">Tipo da Entity</typeparam>
    public class BaseService<T> where T : BaseEntity
    {
        /// <summary>
        /// Repositório
        /// </summary>
        private readonly BaseRepository<T> repository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repository">BaseRepository<T></param>
        public BaseService(BaseRepository<T> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Salvar objeto no repositório
        /// </summary>
        /// <param name="obj">Objeto do tipo T</param>
        /// <returns>Retorna o objeto do tipo T</returns>
        public virtual T Insert(T obj)
        {
            repository.Insert(obj);
            return obj;
        }

        /// <summary>
        /// Atualizar objeto no repositório
        /// </summary>
        /// <param name="obj">Objeto do tipo T</param>
        /// <returns>Retorna o objeto do tipo T</returns>
        public virtual T Update(T obj)
        {
            repository.Update(obj);
            return obj;
        }

        /// <summary>
        /// Salvar objeto no repositório
        /// </summary>
        /// <typeparam name="V">Validação</typeparam>
        /// <param name="obj">Objeto do tipo T</param>
        /// <returns>Retorna o objeto do tipo T</returns>
        public virtual T Insert<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        /// <summary>
        /// Atualizar objeto no repositório
        /// </summary>
        /// <typeparam name="V">Validação</typeparam>
        /// <param name="obj">Objeto do tipo T</param>
        /// <returns>Retorna o objeto do tipo T</returns>
        public virtual T Update<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        /// <summary>
        /// Excluir objeto no repositório
        /// </summary>
        /// <param name="id">Identificador do objeto</param>
        public virtual void Delete(long id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O id deve ser maior que Zero.");
            }

            repository.Delete(id);
        }

        /// <summary>
        /// Quantidade de objetos no repositório
        /// </summary>
        /// <returns>Quantidade de objetos no repositório </returns>
        public int RowsCount()
        {
            return repository.RowsCount();
        }

        /// <summary>
        /// Selecionar objeto no repositório
        /// </summary>
        /// <returns>Retorna uma lista de objetos do tipo T</returns>
        public IList<T> SelectAll()
        {
            return repository.SelectAll();
        }

        /// <summary>
        /// Selecionar objeto no repositório
        /// </summary>
        /// <param name="id">Identificador do objeto</param>
        /// <returns>Retorna o objeto do tipo T</returns>
        public virtual T SelectById(long id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O id deve ser maior que Zero.");
            }

            return repository.SelectById(id);
        }

        /// <summary>
        /// Validar objeto no repositório 
        /// </summary>
        /// <param name="obj">Objeto do tipo T</param>
        /// <param name="validator">Validação</param>
        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
            {
                throw new Exception("Registros não detectados!");
            }

            validator.ValidateAndThrow(obj);
        }
    }
}
