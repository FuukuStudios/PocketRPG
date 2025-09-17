using Microsoft.Xna.Framework;
using PocketCore.Managers;

namespace PocketCore.Scenes
{
    public class Boot : Base
    {
        public override void Start()
        {
            base.Start();
            // In a real game, you would load database files here.
            // For now, we just go to the title screen.
            SceneManager.GoTo(new Title());
        }
    }
}