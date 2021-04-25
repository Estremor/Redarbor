using AutoMapper;
using BL.Dto;
using Model.Entity;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class EmployeeService : IEmployeeService
    {
        #region Fileds
        private readonly IEmployeeRepository _employeeRepo;
        private IMapper _mapper;
        #endregion

        #region C'tor
        public EmployeeService(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public EmployeeDto GetEmployeeById(int id)
        {
            if (id <= 0)
                throw new Exception($"El valor enviado para el {nameof(id)} no es valido {id}");

            var result = _employeeRepo.Get(id);
            return _mapper.Map<EmployeeDto>(result);
        }
        public void UpdateEmployee(int id, EmployeeDto employee)
        {
            if (id <= 0)
                throw new Exception($"El valor enviado para el {nameof(id)} no es valido {id}");
            if (!_employeeRepo.ExistById(id))
                throw new Exception($"El {nameof(Employee)} con {nameof(id)} =>  {id} no existe");
            #region Validations
            //if (employee.CompanyId < 1)
            //    throw new Exception($"El valor enviado para el {nameof(employee.CompanyId)} no es valido {employee.CompanyId}");
            //if (string.IsNullOrWhiteSpace(employee.Name))
            //    throw new Exception($"El valor enviado para el {nameof(employee.Name)} no es valido {employee.Name}");
            //if (string.IsNullOrWhiteSpace(employee.Password))
            //    throw new Exception($"El valor enviado para el {nameof(employee.Password)} no es valido {employee.Password}");
            //if (employee.PortalId < 1)
            //    throw new Exception($"El valor enviado para el {nameof(employee.PortalId)} no es valido {employee.PortalId}");
            //if (employee.RoleId < 1)
            //    throw new Exception($"El valor enviado para el {nameof(employee.RoleId)} no es valido {employee.RoleId}");

            //if (string.IsNullOrWhiteSpace(employee.Username))
            //    throw new Exception($"El valor enviado para el {nameof(employee.Username)} no es valido {employee.Username}");

            #endregion
            var employeeEntity = _mapper.Map<Employee>(employee);
            employeeEntity.Id = id;
            _employeeRepo.Update(employeeEntity);
        }
        public EmployeeDto CreateEmployee(EmployeeDto employee)
        {
            #region Validations
            if (_employeeRepo.ExistByUsername(employee.Username))
                throw new Exception($"El {nameof(Employee)} con {nameof(employee.Name)} =>  {employee.Name} ya existe");
            #endregion

            var entity = _mapper.Map<Employee>(employee);
            entity = _employeeRepo.Insert(entity);
            return _mapper.Map<EmployeeDto>(entity);
        }
        public IEnumerable<EmployeeDto> ListEmployees()
        {
            var result = _employeeRepo.List();
            return _mapper.Map<IEnumerable<EmployeeDto>>(result);
        }
        public void DeleteEmployee(int id)
        {
            if (id <= 0)
                throw new Exception($"El valor enviado para el {nameof(id)} no es valido {id}");
            if (!_employeeRepo.ExistById(id))
                throw new Exception($"El {nameof(Employee)} con {nameof(id)} =>  {id} no existe");
            _employeeRepo.Delete(id);
        }
        #endregion
    }
}
