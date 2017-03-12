﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AccountingBook.Models;
using AccountingBook.Repository;
using AccountingBook.Repository.Interface;

namespace AccountingBook.Service
{
    public class AccountBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AccountBook> _repository;
        public AccountBookService(IUnitOfWork untOfWork)
        {
            this._unitOfWork = untOfWork;
            this._repository = new Repository<AccountBook>(untOfWork);
        }
        public IQueryable<AccountBook> LookupAll()
        {
            return this._repository.LookupAll();
        }

        public IQueryable<AccountBook> Query(Expression<Func<AccountBook, bool>> filter)
        {
            return this._repository.Query(filter);
        }

        public AccountBook GetSingle(Expression<Func<AccountBook, bool>> filter)
        {
            return this._repository.GetSingle(filter);
        }

        public void Create(AccountBook entity)
        {
            this._repository.Create(entity);
        }

        public void Remove(AccountBook entity)
        {
            this._repository.Remove(entity);
        }

        public void Commit()
        {
            this._unitOfWork.Save();
        }
    }
}