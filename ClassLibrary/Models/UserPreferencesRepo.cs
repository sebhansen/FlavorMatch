namespace FlavorMatch.Shared.Models
{
	public class UserPreferencesRepo
	{
		private readonly IUserPreferencesRepo _repository;

		public UserPreferencesRepo(IUserPreferencesRepo repository)
		{
			_repository = repository;
		}

		public Task<List<UserPreferences>> GetUserPreferencesAsync(string userId)
		{
			return _repository.GetUserPreferencesAsync(userId);
		}

		public Task SaveUserPreferencesAsync(List<UserPreferences> preferences)
		{
			return _repository.SaveUserPreferencesAsync(preferences);
		}
	}
}
