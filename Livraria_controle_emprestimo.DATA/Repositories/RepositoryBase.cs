using Livraria_controle_emprestimo.DATA.Interfaces;
using Livraria_controle_emprestimo.DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria_controle_emprestimo.DATA.Repositories
{
    public class RepositoryBase<T> : IRepositoryModel<T>, IDisposable where T : class
    {
        protected EmprestimoContext _Context;
        public bool _SaveChanges = true;

        public RepositoryBase(bool saveChanges = true)
        {
            _SaveChanges = saveChanges;
            _Context = new EmprestimoContext();
        }
        public T Alterar(T objeto)
        {
            _Context.Entry(objeto).State = EntityState.Modified;
            if (_SaveChanges)
            {
                _Context.SaveChanges();
            }
            return objeto;
        }

        public void Dispose()
        {
            _Context.Dispose();
        }

        public void Excluir(T objeto)
        {
            _Context.Set<T>().Remove(objeto);
            if(_SaveChanges)
            {
                _Context.SaveChanges();
            }
        }

        public void Excluir(params object[] variavel)
        {
            var obj = SelecionarPK(variavel);
            Excluir(obj);
        }

        public T Incluir(T objeto)
        {
            _Context.Set<T>().Add(objeto);
            if (_SaveChanges)
            {
                _Context.SaveChanges();
            }
            return objeto;
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }

        public T SelecionarPK(params object[] variavel)
        {
            return _Context.Set<T>().Find(variavel);
        }

        public List<T> SelecionarTodos()
        {
            return _Context.Set<T>().ToList();
        }
    }
}
