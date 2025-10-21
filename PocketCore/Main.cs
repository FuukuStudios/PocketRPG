using System;
using PocketCore.Managers;

namespace PocketCore;

/// <summary>
///     A static class for general utility methods.
/// </summary>
public static class Utils
{
	public const string APP_NAME = "PocketRPG";
	public const string APP_VERSION = "0.2.4-alpha";
	public const string MONOGAME_VERSION = "3.8.4";

	private static readonly Random Random = new();

	/// <summary>
	///     Generates a random integer from 0 to max-1.
	/// </summary>
	public static int RandomInt(int max)
	{
		if (max <= 0) return 0;
		return Random.Next(max);
	}
}

// TODO: ---
// - make title screen accurate
// - implement game data xml shit