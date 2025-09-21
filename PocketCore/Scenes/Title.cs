using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PocketCore.Graphics;
using PocketCore.Managers;
using System.Collections.Generic;
using PocketCore.Objects;

namespace PocketCore.Scenes
{
    public class Title : Base
    {
        private Sprite _backSprite1;
        private Sprite _backSprite2;
        private Sprite _gameTitleSprite;
        private SpriteFont _mainFont;

        private List<Sprite> _sprites;

        public override void Create()
        {
            base.Create();
            _sprites = new List<Sprite>();

            CreateBackground();
            CreateForeground();
            
            // In a real project, fonts would be managed by a FontManager
            _mainFont = ImageManager.Load<SpriteFont>("fonts/mplus-1m-regular");
        }

        public override void Start()
        {
            base.Start();
            // In a real project, music would be played here.
            DrawGameTitle(); // Now we draw the title text after the scene has started and assets are loaded.
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }
        }

        public void CreateBackground()
        {
            _backSprite1 = new Sprite
            {
                Bitmap = ImageManager.LoadTitle1(DataManager.System.Title1Name)
            };
            _backSprite2 = new Sprite
            {
                Bitmap = ImageManager.LoadTitle2(DataManager.System.Title2Name)
            };
            
            CenterSprite(_backSprite1);
            CenterSprite(_backSprite2);
            
            _sprites.Add(_backSprite1);
            _sprites.Add(_backSprite2);
        }

        public void CreateForeground()
        {
            _gameTitleSprite = new Sprite
            {
                Bitmap = new Bitmap(PocketGraphics.Width, PocketGraphics.Height)
            };
            _sprites.Add(_gameTitleSprite);
        }

        public void DrawGameTitle()
        {
            if (!DataManager.System.OptDrawTitle) return;
            
            const int x = 20;
            var y = PocketGraphics.Height / 4;
            var maxWidth = PocketGraphics.Width - x * 2;
            var text = DataManager.System.GameTitle;
            var bitmap = _gameTitleSprite.Bitmap;
            bitmap.FontFace = FontManager.Load("mplus-1m-regular"); // TODO: actual font getting
            bitmap.OutlineColor = Color.Black;
            bitmap.OutlineWidth = 8;
            bitmap.FontSize = 72;
            bitmap.DrawText(text, x, y, maxWidth, 48, Bitmap.TextAlignment.Center);
        }
        
        public void CenterSprite(Sprite sprite)
        {
            if (sprite.Bitmap == null) return;
            sprite.X = PocketGraphics.Width / 2f;
            sprite.Y = PocketGraphics.Height / 2f;
            sprite.Origin = new Vector2(sprite.Width / 2f, sprite.Height / 2f);
        }
        
        public override void Terminate()
        {
            base.Terminate();
            _gameTitleSprite?.Bitmap?.Dispose();
            // Background bitmaps are cached in ImageManager, so we don't dispose them here.
        }
    }
}

