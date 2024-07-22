using FlavorMatch.Shared.Models;
using Microsoft.EntityFrameworkCore;

public class UserPreferencesRepository : IUserPreferencesRepo
{
	private readonly FlavorMatchAPIContext _context;

	public UserPreferencesRepository(FlavorMatchAPIContext context)
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
		var existingPreferences = _context.UserPreferences
			.Where(p => p.UserId == preferences.First().UserId);

		_context.UserPreferences.RemoveRange(existingPreferences);
		_context.UserPreferences.AddRange(preferences);
		await _context.SaveChangesAsync();
	}
}
