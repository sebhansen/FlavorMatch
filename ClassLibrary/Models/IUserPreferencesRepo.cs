namespace FlavorMatch.Shared.Models
{ 
	public interface IUserPreferencesRepo
	{
		Task<List<UserPreferences>> GetUserPreferencesAsync(string userId);
		Task SaveUserPreferencesAsync(List<UserPreferences> preferences);
	}
}