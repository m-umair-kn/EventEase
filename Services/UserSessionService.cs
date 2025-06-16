using System;
using System.Threading.Tasks;

namespace EventEase.Services
{
    public class UserSessionService
    {
        // Simple mock implementation of user session tracking
        private bool _isLoggedIn = false;
        private string _username = string.Empty;
        private DateTime? _lastActivity = null;

        public event Action? OnChange;

        public bool IsLoggedIn => _isLoggedIn;
        public string Username => _username;
        public DateTime? LastActivity => _lastActivity;

        public Task LoginAsync(string username)
        {
            _isLoggedIn = true;
            _username = username;
            _lastActivity = DateTime.Now;
            NotifyStateChanged();
            return Task.CompletedTask;
        }

        public Task LogoutAsync()
        {
            _isLoggedIn = false;
            _username = string.Empty;
            _lastActivity = null;
            NotifyStateChanged();
            return Task.CompletedTask;
        }

        public Task UpdateLastActivityAsync()
        {
            if (_isLoggedIn)
            {
                _lastActivity = DateTime.Now;
                NotifyStateChanged();
            }
            return Task.CompletedTask;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
