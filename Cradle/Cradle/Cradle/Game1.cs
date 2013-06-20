using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Cradle
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D planetTexture;
        Texture2D menuTexture;

        Color aColor;

        bool displayMenu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //screen resolution
            int viewportWidth = 1920;
            int viewportHeight = 1080;

            //set up the viewport to match screen resolution and set to full screen
            graphics.PreferredBackBufferWidth = viewportWidth;
            graphics.PreferredBackBufferHeight = viewportHeight;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            this.IsMouseVisible = true;

            aColor = Color.CornflowerBlue;

            displayMenu = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            planetTexture = Content.Load<Texture2D>("Planet");
            menuTexture = Content.Load<Texture2D>("MenuPH500x500");
            
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) == true)
            {
                this.Exit();
            }
            MouseState mouseState;
            mouseState = Mouse.GetState();
            //check if planet has been clicked.
            
            Rectangle mouseClickArea = new Rectangle(mouseState.X, mouseState.Y, 5, 5);

            Rectangle rec = new Rectangle(400+15, 300+15, planetTexture.Width - 25, planetTexture.Height - 25);

            if (mouseClickArea.Intersects(rec)&& mouseState.LeftButton == ButtonState.Pressed)
            {
                displayMenu = true;
            }
            else
            {
                aColor = Color.CornflowerBlue;
            }

            if (displayMenu)
            {
                Rectangle mouseClickMenuArea = new Rectangle(mouseState.X, mouseState.Y, 5, 5);
                Rectangle cancelRec = new Rectangle(745,705,140,55);
                if (mouseClickMenuArea.Intersects(cancelRec) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    displayMenu = false;
                }
                else
                {
                    aColor = Color.CornflowerBlue;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(aColor);
            
            spriteBatch.Begin();
            spriteBatch.Draw(planetTexture, new Vector2(400,300), Color.White);

            if (displayMenu)
            {
                spriteBatch.Draw(menuTexture, new Vector2(GraphicsDevice.Viewport.Width / 2 - menuTexture.Width / 2, GraphicsDevice.Viewport.Height / 2 - menuTexture.Height / 2), Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
