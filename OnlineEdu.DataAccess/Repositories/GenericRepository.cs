using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Repositories
{
    //constructor yapısını yeni versiyonu classın yanına () açarak içine yazma
    public class GenericRepository<T>(OnlineEduContext _context) : IRepository<T> where T : class 
    {
        //Table özelliği, belirtilen veritabanı modeline karşılık gelen tabloyu temsil eder ve bu tablo üzerinde CRUD (Create, Read, Update, Delete) işlemleri gerçekleştirilmesini sağlar. Bu şekilde, veritabanı işlemleri için genel bir erişim noktası sağlanmış olur.
        public DbSet<T> Table {  get => _context.Set<T>(); }
        public int Count()
        {
            return Table.Count();
        }

        public void Create(T entity)
        {
           Table.Add(entity);
            _context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            var entity = Table.Find(id);
            Table.Remove(entity);
            _context.SaveChanges();
        }

        public int FilteredCount(Expression<Func<T, bool>> predicate)
        {
           return Table.Where(predicate).Count(); 
        }

        public T GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public List<T> GetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public List<T> GetList()
        {
            return Table.ToList();
        }

        public void Update(T entity)
        {
           Table.Update(entity);
            _context.SaveChanges();
        }
    

    }
}
