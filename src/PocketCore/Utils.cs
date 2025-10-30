namespace PocketCore;

public static class Utils
{
	private static readonly HashSet<string> Options = new (StringComparer.OrdinalIgnoreCase);

	public static void Initialize(string[] args)
	{
		Options.Clear();
		if (args.Length == 0) return;

		foreach (var arg in args)
		{
			Options.Add(arg.Trim());
		}
	}
	
	public static bool IsOptionValid(string name)
	{
		return Options.Contains(name);
	}
}