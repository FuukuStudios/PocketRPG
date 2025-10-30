using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PocketCore;

public static class Graphics
{
	private static bool _isLoading; // TODO: a temp var until implemented
	
	public static void StartLoading()
	{
		// TODO: implement
		_isLoading = true;
	}

	public static bool EndLoading()
	{
		// TODO: implement
		var r = _isLoading;
		_isLoading = false;
		return r;
	}
}