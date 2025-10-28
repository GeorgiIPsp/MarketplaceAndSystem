using yyy.Models;

namespace AutomathetionService.Services
{
    // Services/AuthService.cs
    public class AuthService
    {
        public List<Seller> Sellers { get; set; } = new();
        public List<Employee> Employees { get; set; } = new();
        public List<Administrator> Administrators { get; set; } = new();

        public CurrentUser CurrentUser { get; set; } = new();

        public AuthService()
        {
            // Добавляем тестовых пользователей
            InitializeTestData();
        }

        private void InitializeTestData()
        {
            // Администраторы
            Administrators.Add(new Administrator
            {
                Id = 1,
                Email = "a@r.com",
                Password = "a123",
                Name = "Владимир Админов"
            });

            // Сотрудники
            Employees.Add(new Employee
            {
                Id = 1,
                Email = "e@r.com",
                Password = "e123",
                Name = "Иван Сотрудников",
                Role = "Сборщик"
            });
            Employees.Add(new Employee
            {
                Id = 1,
                Email = "e@ra.com",
                Password = "e1234",
                Name = "Георгий",
                Role = "Сборщик"
                
            });
            Sellers.Add(new Seller
            {
                Id = 1,
                Email = "georg@gmail.com",
                Password = "12345",
                Name = "Георгий",
            });
            // Продавцы (добавляются при регистрации)
        }

        public async Task<AuthResult> Login(string email, string password)
        {
            // Ищем во всех таблицах
            var admin = Administrators.FirstOrDefault(a => a.Email == email && a.Password == password);
            if (admin != null)
            {
                CurrentUser = new CurrentUser
                {
                    Id = admin.Id,
                    Email = admin.Email,
                    Name = admin.Name,
                    Role = "administrator",
                    IsAuthenticated = true
                };
                return new AuthResult { Success = true, Role = "administrator" };
            }

            var employee = Employees.FirstOrDefault(e => e.Email == email && e.Password == password);
            if (employee != null)
            {
                CurrentUser = new CurrentUser
                {
                    Id = employee.Id,
                    Email = employee.Email,
                    Name = employee.Name,
                    Role = "employee",
                    IsAuthenticated = true
                };
                return new AuthResult { Success = true, Role = "employee" };
            }

            var seller = Sellers.FirstOrDefault(s => s.Email == email && s.Password == password);
            if (seller != null)
            {
                CurrentUser = new CurrentUser
                {
                    Id = seller.Id,
                    Email = seller.Email,
                    Name = seller.Name,
                    Role = "seller",
                    IsAuthenticated = true
                };
                return new AuthResult { Success = true, Role = "seller" };
            }

            return new AuthResult { Success = false, ErrorMessage = "Неверный email или пароль" };
        }

        public async Task<AuthResult> Register(string email, string password, string name = "")
        {
            // Проверяем, нет ли пользователя с таким email во всех таблицах
            if (Sellers.Any(s => s.Email == email) ||
                Employees.Any(e => e.Email == email) ||
                Administrators.Any(a => a.Email == email))
            {
                return new AuthResult { Success = false, ErrorMessage = "Пользователь с таким email уже существует" };
            }

            // При регистрации создаем только продавца
            var newSeller = new Seller
            {
                Id = Sellers.Count + 1,
                Email = email,
                Password = password,
                Name = string.IsNullOrEmpty(name) ? email.Split('@')[0] : name,
                CreatedAt = DateTime.Now
            };

            Sellers.Add(newSeller);

            CurrentUser = new CurrentUser
            {
                Id = newSeller.Id,
                Email = newSeller.Email,
                Name = newSeller.Name,
                Role = "seller",
                IsAuthenticated = true
            };

            return new AuthResult { Success = true, Role = "seller" };
        }

        public void Logout()
        {
            CurrentUser = new CurrentUser();
        }
    }


    public class CurrentUser
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; }
    }

    public class AuthResult
    {
        public bool Success { get; set; }
        public string Role { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
