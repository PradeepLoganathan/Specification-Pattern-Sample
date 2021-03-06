﻿using System;
using System.Linq.Expressions;
using BookStore.Domain.BooksAggregate;
using BookStore.Repository.Specifications;

namespace BookStore.Repository.Books.Specifications
{
    public class PriceSpecification : Specification<Book>
    {
        private readonly decimal _price;
        public PriceSpecification(int price)
        {
            this._price = price;
        }


        public override Expression<Func<Book, bool>> ToExpression()
        {
            return book => book.Price < _price;
        }
    }
}
