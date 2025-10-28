using Microsoft.JSInterop;

namespace yyy.Services
{
    public class UserService
    {
        public User currentUser { get; set; } = new();
        public List<User> userList { get; set; } = new();

        public event Action OnChange;

        public async Task Logout(IJSRuntime jsRuntime)
        {
            // Очищаем localStorage
            await jsRuntime.InvokeVoidAsync("localStorage.removeItem", "userEmail");
            await jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");

            // Очищаем текущего пользователя
            currentUser = new User();

            // Оповещаем все компоненты об изменении
            NotifyStateChanged();
        }

        public void SetUser(User user)
        {
            currentUser = user;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
