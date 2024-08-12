using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderExampleLogic
{
    public class EmployeeBuilder
    {
        private int _id;
        private string _employeeName;
        private readonly AddressBuilder _addressBuilder = AddressBuilder.Empty();


        public EmployeeBuilder()
        {
        }

       // public static EmployeeBuilder Empty() => new();

        public EmployeeBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public EmployeeBuilder WithEmployeeName(string employeeName)
        {
            _employeeName = employeeName;
            return this;
        }

        public EmployeeBuilder WithEmployeeAddress(Action<AddressBuilder> action)
        {
            action(_addressBuilder);
            return this;
        }

        public Employee Build()
        {
            return new Employee()
            {
                Id = _id,
                EmployeeName = _employeeName,
                EmployeeAddress = _addressBuilder.Build()
            };
        }
    }
}
