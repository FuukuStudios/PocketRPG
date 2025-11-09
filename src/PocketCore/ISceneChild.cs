using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PocketCore;

public interface ISceneChild
{
	void Update();
	void Draw(SpriteBatch spriteBatch);
}