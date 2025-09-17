using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PocketCore.Scenes
{
    /// <summary>
    /// The base class for all scenes in the game.
    /// </summary>
    public abstract class Base
    {
        public virtual void Create() { }
        public virtual void Start() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Stop() { }
        public virtual void Terminate() { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}