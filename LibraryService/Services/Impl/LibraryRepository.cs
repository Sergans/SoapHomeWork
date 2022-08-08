﻿using LibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryService.Services.Impl
{
    public class LibraryRepository : ILibraryRepositoryService
    {
        private readonly ILibraryDatabaseContextService _dbContext;
        private LibraryDatabaseContext _databaseContext;

        public LibraryRepository(ILibraryDatabaseContextService dbContext, LibraryDatabaseContext databaseContext)
        {
            _dbContext = dbContext;
            _databaseContext = databaseContext;
        }
        public int? Add(Book item)
        {
           _databaseContext.WriteJson(item);
            return 0;
        }

        public int Delete(Book item)
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetAll()
        {
           return _dbContext.Books;
        }

        public IList<Book> GetByAuthor(string authorName)
        {
            return _dbContext.Books.Where(book =>
               book.Authors.Where(author =>
                   author.Name.ToLower().Contains(authorName.ToLower())).Count() > 0).ToList();
        }

        public IList<Book> GetByCategory(string category)
        {
            return _dbContext.Books.Where(book =>
               book.Category.ToLower().Contains(category.ToLower())).ToList();
        }

        public Book GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetByTitle(string title)
        {
            return _dbContext.Books.Where(book =>
                 book.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public int Update(Book item)
        {
            throw new NotImplementedException();
        }
    }
}