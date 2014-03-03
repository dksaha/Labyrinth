#define DEBUG			// use to test the class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using className = Labyrinth.ControlVariables.ClassName;
using animated = Labyrinth.ControlVariables.AnimationSequence;


namespace Labyrinth
{
    class Character {
		#region Fields
		
        int health;					//Current health of the character.
        int maxhealth;				//Maximum health of the character.
        int att;					//How much attack it deals.
        int def;					//How much attack it takes.
        int speed;					//Speed between subsequent attacks, also modifier to movement speed.
        double acc;					//hit rate modifier

        int exp;					//Current experience; required for level up.
        int level;					//Current level; determines the stats of the character; determines the amount of exp succesful 
									//attacks gets; determines required exp for next level.

		// time for animation
		float timer = 0.0f;
		float timeInterval = 250.0f;	// length of time each image is display XNA default fps is 60fps or about 16.66667ms per frame
		int currentFrame = 0;
		int characterTextWidth = 42;	// in the test sprite sheet each image is within a 42x62 square, change this variable when a new sprite is used
		int characterTextHeight = 62;
		int maxNumberOfFrame = 4;		// the test sprite contains 4 frames
		Rectangle characterRect;

		#endregion


		#region Properties
		// Get the width of the player ship
		// Texture2D provided a way to access properties withtin the texture
		//public int Width
		//{
		//	get { return CharacterTexture.Width; }
		//}

        // Get the height of the player ship
		// Texture2D provided a way to access properties withtin the texture
		//public int Height
		//{
		//	get { return CharacterTexture.Height; }
		//}

		public className Class{ get; private set; }					// The player class
		public string Name{ get; set; }								// Name of the Character.
		public Texture2D CharacterTexture{ get; private set; }		// Animation representing the character. 
		public Vector2 Position{ get; set; }						// the position of the character.
		public bool Active{ get; set; }								// State of the player.

		public animated Action{ get; set; }							// affects the animated action of the sprite, specified which animation sequence to draw or render to screen.
		#endregion



		#region Constructor
		public Character(){
			// for the character animation
			characterRect = new Rectangle(currentFrame * characterTextWidth, 0, characterTextWidth, characterTextHeight);

#if(DEBUG)
			Action = animated.SPIN;
#else
			Action = animated.NULL;
#endif

			exp = 0;
		}
		#endregion



		#region Methods
		public void Initialize(ref Texture2D texture, Vector2 position, string name, int health, int maxhealth, int att, int def,
                                int speed, double acc, int level = 1, className playerClass = ControlVariables.ClassName.NULL)
        {
            CharacterTexture = texture;

            Position = position;

            Active = true;

            this.Name = name;
            this.health = health;
            this.maxhealth = maxhealth;
            this.att = att;
            this.def = def;
            this.speed = speed;
            this.acc = acc;
            this.level = level;
            this.Class = playerClass;

			if( Class == className.MONSTER )			// in the test sprite sheet, the monster y coordinate starts at 62
				characterRect.Y = 62;
        }

		int expToLevel(int level)
         {
			// Exp to level x = 128*x^2
			return 128 * level * level;
         }
    
        
		bool levelUp()                                    // Level the creature to the next level if it has enough experience to do so, returning true if it could level up and false otherwise.
		{
			// We want the experience to the next level,
			// not the current level
			if(this.exp >= expToLevel(this.level+1))
			{
				// Advance to the next level
				++level;
 
				// Variables to keep track of stat changes. Neater than
				// having a bunch of stat increases all over the place,
				// and removes the issue of the next level's stats
				// affecting themselves (increasing endurance then
				// increasing health based on the boosted instead of
				// the original value, for example
				int healthBoost = 0;
				int attBoost = 0;
				int defBoost = 0;
				int speedBoost = 0;
 
				// Give a large boost to health every fifth level
				if(level % 5 == 0)
				{
					// Randomly increase health, but always give a
					// chunk proportional to the creature's endurance
					healthBoost = 10 + ControlVariables.rand.Next(4) + this.maxhealth / 4;
				}
				else
				{
					// Just increase health by a small amount
					healthBoost = this.maxhealth / 4;
				}
				// If the character is a human, then favour attack and
				// speed boosts over defense, but increase defense
				// 50% of the time too
				if(Class == className.HUMAN)
				{
					attBoost = 1;
					speedBoost = 1;
					if(ControlVariables.rand.Next(2) == 0) defBoost = 1;
				}
				// Monster gets same as for human but favour attack and speed
				// instead. 
				else if(Class == className.MONSTER)
				{
					attBoost = 1;
					defBoost = 1;
					if(ControlVariables.rand.Next(2) == 0) speedBoost = 1;
				}
 
				// Adjust all of the variables accordingly
				this.maxhealth += healthBoost;
				this.att += attBoost;
				this.def += defBoost;
				this.speed += speedBoost;
 
				return true;
			}

			return false;
		}
		#endregion


		#region Character Action
		void SpinningCW(){

		}

		#endregion



		public void Update(ref GameTime gameTimer) {

			#region Spining animation
			if( Action == animated.SPIN ){
				timer += (float)gameTimer.ElapsedGameTime.Milliseconds;
				if( timer >= timeInterval ){
					timer = 0.0f;
					if( (++currentFrame) >= maxNumberOfFrame )
						currentFrame = 0;
				}

				characterRect.X = currentFrame * characterTextWidth;
			}
			#endregion


		}

        public void Draw(ref SpriteBatch spriteBatch){

			// draw is based on the current test sprite sheet, the top half is the human sprite , the bottom half is the monster
			// each character has only one class type
			#region Human animation
			if( Class == className.HUMAN ){
				if( Action == animated.SPIN ){
					spriteBatch.Draw( CharacterTexture, 
									  new Rectangle( (int)(Position.X + 0.5f), (int)(Position.Y + 0.5f), characterTextWidth, characterTextHeight ), // adding .05 to the position insured accracy when the number get's truncated.
									  characterRect,
									  Color.White);
				}
				else if( Action == animated.NULL ){
					spriteBatch.Draw( CharacterTexture, 
									  new Rectangle( (int)(Position.X + 0.5f), (int)(Position.Y + 0.5f), characterTextWidth, characterTextHeight ), 
									  new Rectangle( 0, 0, 42, 62),
									  Color.White);
				}
			}
			#endregion

			#region Monster animation
			else if( Class == className.MONSTER ){
				if( Action == animated.SPIN ){
					spriteBatch.Draw( CharacterTexture, 
									  new Rectangle( (int)(Position.X + 0.5f), (int)(Position.Y + 0.5f), characterTextWidth, characterTextHeight ), // adding .05 to the position insured accracy when the number get's truncated.
									  characterRect,
									  Color.White);
				}
				else if( Action == animated.NULL ){
					spriteBatch.Draw( CharacterTexture, 
									  new Rectangle( (int)(Position.X + 0.5f), (int)(Position.Y + 0.5f), characterTextWidth, characterTextHeight ), 
									  new Rectangle( 0, 62, 42, 62),
									  Color.White);
				}
			}
			#endregion

			//spriteBatch.Draw(CharacterTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

       
        
  }
}
