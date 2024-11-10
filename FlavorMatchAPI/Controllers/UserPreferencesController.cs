using FlavorMatch.Shared.Models;
using Microsoft.EntityFrameworkCore;

public interface IUserPreferencesRepo
{
	Task<List<UserPreferences>> GetUserPreferencesAsync(string userId);
	Task SaveUserPreferencesAsync(List<UserPreferences> preferences);
}

public class UserPreferencesRepo : IUserPreferencesRepo
{
	private readonly FlavorMatchAPIContext _context;

	public UserPreferencesRepo(FlavorMatchAPIContext context)
	{
		_context = context;
	}

	public async Task<List<UserPreferences>> GetUserPreferencesAsync(string userId)
	{
		return await _context.UserPreferences
		.Where(p => p.UserId == userId)
		.ToListAsync();
	}

	public async Task SaveUserPreferencesAsync(List<UserPreferences> preferences)
	{
		// Delete existing preferences
		var existingPreferences = _context.UserPreferences
			.Where(p => p.UserId == preferences.First().UserId);

		_context.UserPreferences.RemoveRange(existingPreferences);

		// Add new preferences
		_context.UserPreferences.AddRange(preferences);
		await _context.SaveChangesAsync();
	}
}
