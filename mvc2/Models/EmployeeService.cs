namespace mvc2.Models
{
    public class EmployeeService
    {
        private static List<Employee> employees=new List<Employee>
        {
            new Employee{Id=1,Name="John Doe",Email="luong@gmail.com" },
            new Employee{Id=2,Name="Jane Smith",Email="aaa@gmail.com" },
            new Employee{Id=3,Name="Bob Johnson",Email="bbbb@gmail.com" }
        };
        public List<Employee> GetAllEmployees()
        {
            return employees;
        }
        public Employee? GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }
        public void addEmployee(Employee item)
        {
            
                employees.Add(item);
        }
        public void removeEmployee(int id)
        {
            var item=GetEmployeeById(id);
            if(item!=null)
            {
                employees.Remove(item);
            }
        }
        public void updateEmployee(Employee e)
        {
            var item = GetEmployeeById(e.Id);
            if (item != null)
            {
                item.Name= e.Name;
                item.Email= e.Email;
            }
        }
    }
}
