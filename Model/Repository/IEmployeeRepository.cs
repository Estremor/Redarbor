using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        bool ExistById(int id);
        bool ExistByUsername(string userName);
    }
}
