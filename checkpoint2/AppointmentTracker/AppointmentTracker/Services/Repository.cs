using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppointmentTracker.Data;
using AppointmentTracker.Models;

namespace AppointmentTracker.Services
{
    public class Repository : IRepository
    {
        private readonly SpaAppContext _spaAppContext;
        private readonly IReadOnlySpaAppContext _readOnlySpaAppContext;

        public Repository(SpaAppContext SpaAppContext, IReadOnlySpaAppContext readOnlySpaAppContext)
        {
            _spaAppContext = SpaAppContext;
            _readOnlySpaAppContext = readOnlySpaAppContext;
        }

        public IQueryable<AppointmentModel> Appointments => _readOnlySpaAppContext.Appointments;

        public IQueryable<CustomerModel> Customers => _readOnlySpaAppContext.Customers;

        public IQueryable<ServiceProviderModel> Providers => _readOnlySpaAppContext.Providers;

        public void Add(ToDo toDo)
        {
            _toDoContext.ToDos.Add(toDo);
            _toDoContext.SaveChanges();
        }

        public void Update(int id, ToDo toDo)
        {
            toDo.Id = id;
            _toDoContext.ToDos.Update(toDo);
            _toDoContext.SaveChanges();
        }

        public void DeleteToDo(int id)
        {
            var toBeDeleted = _toDoContext.ToDos.Find(SelectToDoById(id));
            _toDoContext.ToDos.Remove(toBeDeleted);
            _toDoContext.SaveChanges();
        }

        public ToDo GetToDo(int id)
        {
            return _readOnlyToDoContext.ToDos
                .Include(x => x.Status)
                .Include(x => x.Tag)
                .First(SelectToDoById(id));
        }

        public void Add(Status status)
        {
            _toDoContext.Statuses.Add(status);
            _toDoContext.SaveChanges();
        }

        public void Update(int id, Status status)
        {
            status.Id = id;
            _toDoContext.Statuses.Update(status);
            _toDoContext.SaveChanges();
        }

        public void DeleteStatus(int id)
        {
            var toBeDeleted = _toDoContext.Statuses.First(SelectStatusesById(id));
            _toDoContext.Statuses.Remove(toBeDeleted);
            _toDoContext.SaveChanges();
        }

        public Status GetStatus(int id)
        {
            return _readOnlyToDoContext.Statuses.First(SelectStatusesById(id));
        }

        #region Selector Functions
        private static Func<ToDo, bool> SelectToDoById(int id)
        {
            return toDo => toDo.Id == id;
        }

        private static Func<Status, bool> SelectStatusesById(int id)
        {
            return status => status.Id == id;
        }

        public void Dispose()
        {
            _toDoContext?.Dispose();
            (_readOnlyToDoContext as IDisposable)?.Dispose();
        }
        #endregion



    }
}
