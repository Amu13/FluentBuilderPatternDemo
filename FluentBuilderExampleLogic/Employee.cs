namespace FluentBuilderExampleLogic
{
    public class Employee
    {
        public int Id { get; init; } // An init enforces immutability, so that once the object is initialized, it can't be changed.

        public string EmployeeName { get; init; }

        public Address EmployeeAddress { get; init; }
    }
}
