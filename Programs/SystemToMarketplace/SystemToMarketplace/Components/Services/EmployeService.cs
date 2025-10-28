namespace AutomathetionService.Services
{
    public class EmployeService
    {
        private List<Employee> _employees = new List<Employee>();
        public event Action OnEmployeesChanged;
        public EmployeService()
        {
            InitializeTestData();
        }

        private void InitializeTestData()
        {
            _employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Иван Петров", Email = "ivan@reign.ru", Role = "picker", Password = "123456" },
                new Employee { Id = 2, Name = "Мария Сидорова", Email = "maria@reign.ru", Role = "sorter", Password = "123456" },
                new Employee { Id = 3, Name = "Алексей Козлов", Email = "alex@reign.ru", Role = "returner", Password = "123456" },
                new Employee { Id = 4, Name = "Елена Новикова", Email = "elena@reign.ru", Role = "picker", Password = "123456" },
                new Employee { Id = 5, Name = "Дмитрий Волков", Email = "dmitry@reign.ru", Role = "sorter", Password = "123456" }
            };
        }
        private void NotifyEmployeesChanged()
        {
            OnEmployeesChanged?.Invoke();
        }
        // Получить всех сотрудников
        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }


        public Employee GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }


        public Employee GetEmployeeByEmail(string email)
        {
            return _employees.FirstOrDefault(e => e.Email == email);
        }


        public void AddEmployee(Employee employee)
        {
            var newId = _employees.Count > 0 ? _employees.Max(e => e.Id) + 1 : 1;
            employee.Id = newId;
            _employees.Add(employee);
            NotifyEmployeesChanged(); 
        }


        public bool UpdateEmployee(Employee employee)
        {
            var existingEmployee = GetEmployeeById(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                existingEmployee.Role = employee.Role;
                if (!string.IsNullOrEmpty(employee.Password))
                {
                    existingEmployee.Password = employee.Password;
                }
                NotifyEmployeesChanged(); 
                return true;
            }
            return false;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
                NotifyEmployeesChanged(); 
                return true;
            }
            return false;
        }


        public bool EmployeeExists(string email)
        {
            return _employees.Any(e => e.Email == email);
        }

        public List<Employee> GetEmployeesByRole(string role)
        {
            return _employees.Where(e => e.Role == role).ToList();
        }

        public int GetEmployeesCount()
        {
            return _employees.Count;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}