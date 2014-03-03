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

		SpriteFont timesNewRoman;
		Texture2D testSprite;
		

		// game settings
		int dimensionWdith = 1000;
		int dimensionHeight = 600;
		int maxCharInput = 12;

        Character humanPlayer;
		Character monsterPlayer;

		className currentNameInput = className.HUMAN;		// debug - use in the Update() , game state = GameState.START, to input character names.

		// game state
		enum GameState{ START, BATTLE, GAMEOVER };
		GameState state = GameState.START;

		// the green cursor
		Texture2D greenCursorTexture;						// visual aid for the user to know where the typed letters will appear on the screen
		float greenCursorTimer = 0.0f;
		float greenCursorInterval = 30.0f;					// length of the time each image is displayed
		int greenCursorCurFrame = 0;
		int greenCursorWidth = 10;
		int greenCursorHeight = 20;
		const int greenCursorTotalFrame = 6;
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

			greenCursorRect = new Rectangle(greenCursorCurFrame * greenCursorWidth, 0, greenCursorWidth, greenCursorHeight);

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

			timesNewRoman = Content.Load<SpriteFont>(@"Fonts/timesNewRoman");

			greenCursorTexture = Content.Load<Texture2D>(@"Textures/greenCursor");
			testSprite = Content.Load<Texture2D>(@"Textures/testSprite_Author_Redshrike_OpenGameArt");

            // Load the player resources 
           // Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
           
            humanPlayer.Initialize( ref testSprite, new Vector2(82.0f, 64.0f), string.Empty, 100, 100, 5, 3, 3, 50.0, 1 , className.HUMAN );

			monsterPlayer.Initialize( ref testSprite, new Vector2(dimensionWdith - 82.0f - 42.0f, 64.0f), string.Empty, 100, 100, 5, 3, 3, 50.0f, 1, className.MONSTER ); // 42 is the width of one frame of the character text within the sprite sheet

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
					string tempString;

					#region player enter the name of the human character first then the monster character
					switch(currentNameInput){
						case className.HUMAN:
							tempString = humanPlayer.Name;
							textStreamer.ReadKBInput(ref tempString);

							// always check if string is null or empty before doing string comparision  
							if( !string.IsNullOrEmpty(tempString) ){

								// default name if player press enter without typing anything
								if( tempString.IndexOf(System.Environment.NewLine) == 0 ){
									tempString = "Human Being";
									currentNameInput = className.MONSTER;								// set the process to name the next character
								}

								// user had enter the maximum allowable number of char or user press enter to signal that he/she is finish
								else if( (tempString.Length >= maxCharInput) || ( tempString[tempString.Length-1] == '\n' ) ){
									if( tempString.Length > maxCharInput ){    // truncate to satisfied the max allowable length of char rule
										tempString.Remove(maxCharInput - 1);
									}

									humanPlayer.Name = tempString;
									currentNameInput = className.MONSTER;								// set the process to name the next character
								}
							}// end if null/empty string 

							// user hasn't or is still typing in the char name
							humanPlayer.Name = tempString;
							break;

						case className.MONSTER:
							tempString = monsterPlayer.Name;
							textStreamer.ReadKBInput(ref tempString);


							// always check if string is null or empty before doing string comparision  
							if( !string.IsNullOrEmpty(tempString) ){

								// default name if player press enter without typing anything
								if(tempString.IndexOf(System.Environment.NewLine) == 0 ){
									tempString = "Monster";
									state = GameState.BATTLE;											// name input done start the battle
								}

								// user had enter the maximum allowable number of char or user press enter to signal that he/she is finish
								else if( (tempString.Length >= maxCharInput) || ( tempString[tempString.Length-1] == '\n' ) ){
									if( tempString.Length > maxCharInput ){    // truncate to satisfied the max allowable length of char rule
										tempString.Remove(maxCharInput - 1);
									}

									monsterPlayer.Name = tempString;
									state = GameState.BATTLE;											// name input done start the battle
								}
							}// end null/empty string 

							// else user is still typing the char name
							monsterPlayer.Name = tempString;
							break;
					}
					#endregion
					
					// user is entering the name for the character(s) so keep animating the green cursor
					greenCursorTimer += (float)gameTime.ElapsedGameTime.Milliseconds;
					if( greenCursorTimer >= greenCursorInterval ){
						greenCursorTimer = 0.0f;
						if( (++greenCursorCurFrame) >= (greenCursorTotalFrame - 1) ){
							greenCursorCurFrame = 0;
						}

						greenCursorRect.X = greenCursorCurFrame * greenCursorWidth;
					}
					
					break;	// case GameState.START:

				case GameState.BATTLE:

					// character action
					humanPlayer.Update(ref gameTime);
					monsterPlayer.Update(ref gameTime);

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
				
				// I indent because of OpenGL habit
				// will make this better once we have more detail of how the game should start. this is for show.
				if(state == GameState.START){
					Vector2 nameMeasurement;
					if(currentNameInput == className.HUMAN){

						nameMeasurement = timesNewRoman.MeasureString(humanPlayer.Name);

						spriteBatch.DrawString(timesNewRoman, "Enter your character name (MAX Letters: 12):\n", new Vector2(80, 50), Color.Black);
						spriteBatch.DrawString(timesNewRoman, humanPlayer.Name, new Vector2(80, 100), Color.Black);
						spriteBatch.Draw(	greenCursorTexture, 
											new Rectangle(80 + (int)nameMeasurement.X, 105, greenCursorWidth, greenCursorHeight),
											greenCursorRect,
											Color.White
										);
					}
					else if(currentNameInput == className.MONSTER){
						nameMeasurement = timesNewRoman.MeasureString(monsterPlayer.Name);

						spriteBatch.DrawString(timesNewRoman, "Enter monster name (MAX Letters: 12):\n", new Vector2(80, 50), Color.Black);
						spriteBatch.DrawString(timesNewRoman, monsterPlayer.Name, new Vector2(80, 100), Color.Black);
						spriteBatch.Draw(	greenCursorTexture, 
											new Rectangle(80 + (int)nameMeasurement.X, 105, greenCursorWidth, greenCursorHeight),
											greenCursorRect,
											Color.White
										);
					}
				}

				else if(state == GameState.BATTLE){
					humanPlayer.Draw(ref spriteBatch);
					// 62.0f is the height of the character texture from the sprite sheet
					Vector2 nameMeasurement = timesNewRoman.MeasureString(humanPlayer.Name);
					spriteBatch.DrawString(timesNewRoman, humanPlayer.Name, new Vector2( humanPlayer.Position.X - nameMeasurement.X / 4.0f , humanPlayer.Position.Y + 62.0f + 10.0f), Color.Black); 

					nameMeasurement = timesNewRoman.MeasureString(monsterPlayer.Name);
					monsterPlayer.Draw(ref spriteBatch);
					spriteBatch.DrawString(timesNewRoman, monsterPlayer.Name, new Vector2( monsterPlayer.Position.X - nameMeasurement.X / 4.0f , monsterPlayer.Position.Y + 62.0f + 10.0f), Color.Black);
				}

				else if(state == GameState.GAMEOVER){

				}				

            // Stop drawing
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
