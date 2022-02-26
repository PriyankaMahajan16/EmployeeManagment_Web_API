using EmployeeManagement.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IMongoCollection<Employee> _employees;

        public EmployeeServices(IEmployeeDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _employees = database.GetCollection<Employee>(settings.EmployeeCollectionName);
        }

        public Employee Create(Employee employee)
        {
            _employees.InsertOne(employee);
            return employee;
        }

        public List<Employee> Get()
        {
            return _employees.Find(Employee => true).ToList();
        }

        public Employee Get(string id)
        {
            return _employees.Find(Employee => Employee.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _employees.DeleteOne(Employee => Employee.Id == id);
        }

        public void Update(string id, Employee student)
        {
            _employees.ReplaceOne(student => student.Id == id, student);
        }
    }
}
