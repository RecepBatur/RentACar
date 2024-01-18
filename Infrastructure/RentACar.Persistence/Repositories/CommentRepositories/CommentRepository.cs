﻿using RentACar.Application.Features.RepositoryPattern;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly RentACarContext _context;

        public CommentRepository(RentACarContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public void Remove(Comment entity)
        {
            var value = _context.Comments.Find(entity.CommentId);
            _context.Remove(value);
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
