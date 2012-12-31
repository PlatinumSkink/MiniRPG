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

namespace Mini_RPG
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        enum GameState { Menu,Running,Pause,Editor}
        GameState gameState = GameState.Menu;

        UI ui = new UI(32);

        Game game;
        Editor editor;
        Menu menu;

        KeyboardManager km = new KeyboardManager();

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Position.Content = Content;
            this.Window.Title = "Mini RPG";
            Console.WriteLine(graphics.PreferredBackBufferWidth);
            Console.WriteLine(graphics.PreferredBackBufferHeight);
            Core.Library.ArrangeLibrary();
            Core.Content = Content;
            //graphics.PreferredBackBufferWidth = 1920;
            //graphics.PreferredBackBufferHeight = 980;
            graphics.PreferredBackBufferWidth = 1024;
            Core.WorldWidth = graphics.PreferredBackBufferWidth;
            graphics.PreferredBackBufferHeight = 600;
            Core.WorldWidth = graphics.PreferredBackBufferHeight;
            //graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //game = new Game(32, new Vector2(50, 50), graphics.GraphicsDevice.Viewport, ui);
            editor = new Editor(32, new Vector2(50, 50), graphics.GraphicsDevice.Viewport, ui);
            menu = new Menu();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            switch (gameState)
            {
                case GameState.Menu:
                    string next = menu.Update(gameTime);
                    if (next == "Game")
                    {
                        graphics.PreferredBackBufferWidth = 800;
                        graphics.PreferredBackBufferHeight = 480;
                        //graphics.IsFullScreen = true;
                        graphics.ApplyChanges();
                        Core.WorldWidth = graphics.PreferredBackBufferWidth;
                        Core.WorldHeight = graphics.PreferredBackBufferHeight;
                        gameState = GameState.Running;
                        game = new Game(32, new Vector2(50, 50), graphics.GraphicsDevice.Viewport, ui);
                        string[] levelNames = new string[3];
                        levelNames[0] = "NiklasWorld1";
                        levelNames[1] = "NiklasWorld2";
                        levelNames[2] = "NiklasWorld3";
                        game.SetLevelNames(levelNames);
                        //game.Load("NIKLASWORLD3");
                        //game.Load("COLLISIONTESTWORLD");
                        //game.Load("COLLISION");
                    }
                    else if (next == "Editor")
                    {
                        gameState = GameState.Editor;
                    }
                    else if (next == "Quit")
                    {
                        this.Exit();
                    }
                    break;
                case GameState.Running:
                    game.Update(gameTime);
                    break;
                case GameState.Pause:
                    game.PauseUpdate(gameTime);
                    break;
                case GameState.Editor:
                    editor.Update(gameTime);
                    break;
                default:
                    break;
            }

            if (km.CheckKeyState(Keys.Escape, false))
            {
                this.Exit();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            switch (gameState)
            {
                case GameState.Menu:
                    spriteBatch.Begin();
                    menu.Draw(spriteBatch);
                    break;
                case GameState.Running:
                    spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, game.camera.GetViewMatrix());
                    game.Draw(spriteBatch);
                    break;
                case GameState.Pause:
                    spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, game.camera.GetViewMatrix());
                    break;
                case GameState.Editor:
                    spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, editor.camera.GetViewMatrix());
                    editor.Draw(spriteBatch);
                    break;
                default:
                    break;
            }
            spriteBatch.End();
            spriteBatch.Begin();
            switch (gameState)
            {
                case GameState.Menu:
                    
                    break;
                case GameState.Running:
                    game.UIDraw(spriteBatch);
                    break;
                case GameState.Pause:
                    break;
                case GameState.Editor:
                    editor.UIDraw(spriteBatch);
                    break;
                default:
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
