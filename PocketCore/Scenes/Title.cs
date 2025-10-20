using System.Collections.Generic;
using System.Diagnostics;
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

    public override void Create()
    {
        base.Create();
        CreateBackground();
        CreateForeground();
		// TODO: create window layer
		// TODO: create window layer
        _mainFont = FontManager.Load("mplus-1m-regular");  // TODO: actual font getting
    }

    public override void Start()
    {
        base.Start();
        // TODO: SceneManager: clear stack
        AdjustBackground();
    }

    public override void Update(GameTime gameTime)
    {
	    // TODO: isBusy check
        base.Update(gameTime);
    }

    public void CreateBackground()
    {
	    Debug.WriteLine($"Creating background for Title Scene.\n - BG: {DataSystem.title1Name}\n - Frame: {DataSystem.title2Name}");
        _backSprite1 = new Sprite(ImageManager.LoadTitle1(DataSystem.title1Name));
        _backSprite2 = new Sprite(ImageManager.LoadTitle2(DataSystem.title2Name));

        Children.Add(_backSprite1);
        Children.Add(_backSprite2);
    }

    public void CreateForeground()
    {
        _gameTitleSprite = new Sprite(new Bitmap(PocketGraphics.Width, PocketGraphics.Height));
        Children.Add(_gameTitleSprite);
        if (DataSystem.optDrawTitle) DrawGameTitle();
    }

    public void DrawGameTitle()
    {
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

    public void AdjustBackground()
    {
	    ScaleSprite(_backSprite1);
	    ScaleSprite(_backSprite2);
	    CenterSprite(_backSprite1);
	    CenterSprite(_backSprite2);
    }

    public override void Terminate()
    {
        base.Terminate();
        _gameTitleSprite?.Bitmap?.Dispose();
        // Background bitmaps are cached in ImageManager, so we don't dispose them here.
    }
}