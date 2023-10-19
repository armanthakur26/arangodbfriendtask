using ArangoDB.Client;
using Arangodbtest.model;
using Arangodbtest.Repository.Irepository;
using Microsoft.VisualBasic;

namespace Arangodbtest.Repository
{
    public class EmployeeRepository : IemployeeRepository
    {
        private readonly IArangoDatabase _arangodatabase;
        private readonly string _collectionName;
        public EmployeeRepository(IArangoDatabase arangoDatabase)
        {
            _arangodatabase = arangoDatabase;
            _collectionName = "Employee";               //collection name jo database mai hai
        }

        public void addemployee(Employee employee)
        {
            var collection = _arangodatabase.Collection(_collectionName);
            collection.Insert(employee);    
        }

        public void deleteemployee(string _key)
        {
            var collection = _arangodatabase.Collection(_collectionName);
            var emp = collection.Document<Employee>(_key);
            collection.Remove(emp);
        }

        public Employee getemploye(string _key)
        {
            var collection = _arangodatabase.Collection(_collectionName);
            var employee = collection.All<Employee>().ToList();
            var emp=employee.FirstOrDefault(e=>e._key==_key);
            return (emp);
        }

        public ICollection<Employee> GetEmployees()
        {
            var collection = _arangodatabase.Collection(_collectionName);
            var employee = collection.All<Employee>().ToList();
            return employee;
        }

        public void updateemployee(Employee employee)
        {
            var collection = _arangodatabase.Collection(_collectionName);
            var emp = collection.Document<Employee>(employee._key);
            if(employee != null) 
            {
                emp.name = employee.name;
            }
            collection.Update(emp);
        }
    }
}
