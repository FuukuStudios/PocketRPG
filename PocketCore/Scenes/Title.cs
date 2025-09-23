using System.Collections.Generic;
using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PocketCore.Graphics;
using PocketCore.Managers;
using static PocketCore.Pocket;

namespace PocketCore.Scenes;

public class Title : Base
{
    private Sprite _backSprite1;
    private Sprite _backSprite2;
    private Sprite _gameTitleSprite;
    private FontSystem _mainFont;

    private List<Sprite> _sprites;

    public override void Create()
    {
        base.Create();
        _sprites = [];

        CreateBackground();
        CreateForeground();

        _mainFont = FontManager.Load("mplus-1m-regular");  // TODO: actual font getting
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
        foreach (var sprite in _sprites) sprite.Draw(spriteBatch);
    }

    public void CreateBackground()
    {
        _backSprite1 = new Sprite(ImageManager.LoadTitle1(DataSystem.title1Name));
        _backSprite2 = new Sprite(ImageManager.LoadTitle2(DataSystem.title2Name));

        CenterSprite(_backSprite1);
        CenterSprite(_backSprite2);

        _sprites.Add(_backSprite1);
        _sprites.Add(_backSprite2);
    }

    public void CreateForeground()
    {
        _gameTitleSprite = new Sprite(new Bitmap(PocketGraphics.Width, PocketGraphics.Height));
        _sprites.Add(_gameTitleSprite);
    }

    public void DrawGameTitle()
    {
        if (!DataSystem.optDrawTitle) return;

        const int x = 20; // a margin
        var y = PocketGraphics.Height / 4; // positioned a fourth down from the top
        var maxWidth = PocketGraphics.Width - x * 2; // width with margin accounted
        var text = DataSystem.gameTitle;
        var bitmap = _gameTitleSprite.Bitmap;
        bitmap.FontFace = _mainFont;
        bitmap.OutlineColor = Color.Black;
        bitmap.OutlineWidth = 8;
        bitmap.FontSize = 72;
        bitmap.DrawText(text, x, y, maxWidth, 48, Bitmap.TextAlignment.Center);
    }

    public static void CenterSprite(Sprite sprite)
    {
        sprite.Position = new Vector2(PocketGraphics.Width / 2f, PocketGraphics.Height / 2f);
        sprite.Origin = new Vector2(sprite.Width / 2f, sprite.Height / 2f);
    }

    public override void Terminate()
    {
        base.Terminate();
        _gameTitleSprite?.Bitmap?.Dispose();
        // Background bitmaps are cached in ImageManager, so we don't dispose them here.
    }
}