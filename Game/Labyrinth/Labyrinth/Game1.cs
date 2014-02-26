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
using TextInput;

// control the character class within the game
using className = Labyrinth.ControlVariables.ClassName;

namespace Labyrinth
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game {

		#region Fields
		GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

		Texture2D testSprite;
		

		// game settings
		int dimensionWdith = 1000;
		int dimensionHeight = 600;
		int maxCharInput = 12;

        Character humanPlayer;
		Character monsterPlayer;

		className currentNameInput = className.HUMAN;		// debug 

		// game state
		enum GameState{ START, BATTLE, GAMEOVER };
		GameState state = GameState.START;


		// the green cursor
		Texture2D greenCursor;				// visual aid for the user to know where the typed letters will appear on the screen
		float greenCursorTimer = 0.0f;
		float greenCursorInterval = 30.0f;	// length of the time each image is displayed
		int greenCurrentFrame = 0;
		int greenCursorWidth = 10;
		int greenCursorHeight = 20;
		Rectangle greenCursorRect;


		// allow text input from kb
		TextStream textStreamer;

		#endregion


		public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

			// set the default dimension of the game
			graphics.PreferredBackBufferWidth = dimensionWdith;
			graphics.PreferredBackBufferHeight = dimensionHeight;
			graphics.ApplyChanges();
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
			IsMouseVisible = true;

			textStreamer = new TextStream();

			greenCursorRect = new Rectangle(greenCurrentFrame * greenCursorWidth, 0, greenCursorWidth, greenCursorHeight);

            // Initialize the character class
            humanPlayer = new Character();
			monsterPlayer = new Character();
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

			greenCursor = Content.Load<Texture2D>(@"Textures/greenCursor");
			testSprite = Content.Load<Texture2D>(@"Textures/testSprite_Author_Redshrike_OpenGameArt");

            // Load the player resources 
           // Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
           
            humanPlayer.Initialize( ref testSprite, new Vector2(82.0f, 64.0f), string.Empty, 100, 100, 5, 3, 3, 50.0, 1 , className.HUMAN );

			monsterPlayer.Initialize( ref testSprite, new Vector2(dimensionWdith - 82.0f, 64.0f), string.Empty, 100, 100, 5, 3, 3, 50.0f, 1, className.MONSTER );

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

			#region what state the game is currently in
			switch(state){
				case GameState.START:
					// player input the name of the human character first
					switch(currentNameInput){
						case className.HUMAN:


							// default name if player press enter without typing anything

							if( humanPlayer.Name.Length == maxCharInput || ( humanPlayer.Name[humanPlayer.Name.Length-1] == '\n' ) );
							break;

						case className.MONSTER:

							break;
					}
					break;

				case GameState.BATTLE:

					break;

				case GameState.GAMEOVER:

					break;
			}
			#endregion

			base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Start drawing
            spriteBatch.Begin();
				
				// I indent through OpenGL habit
				if(state == GameState.START){

				}
				else if(state == GameState.BATTLE){

				}
				else if(state == GameState.GAMEOVER){

				}				

            // Stop drawing
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
