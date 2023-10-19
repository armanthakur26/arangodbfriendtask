using Arangodbtest.model;
using static System.Reflection.Metadata.BlobBuilder;

namespace Arangodbtest.Repository.Irepository
{
    public interface IemployeeRepository
    {

        ICollection<Employee> GetEmployees();

        Employee getemploye(string _key);
        void addemployee(Employee employee);
        void updateemployee(Employee employee);
        void deleteemployee(string _key);
         
    }
}