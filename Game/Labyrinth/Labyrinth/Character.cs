using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Labyrinth
{
    class Character {
		#region Fields
		//string Name;				//Name of the Character.
        string className;			//Class of the character; Human, Monster or Mecha.

        int health;					//Current health of the character.
        int maxhealth;				//Maximum health of the character.
        int att;					//How much attack it deals.
        int def;					//How much attack it takes.
        int speed;					//Speed between subsequent attacks, also modifier to movement speed.
        double acc;					//hit rate modifier

        int exp;					//Current experience; required for level up.
        int level;					//Current level; determines the stats of the character; determines the amount of exp succesful 
									//attacks gets; determines required exp for next level.

        //public Texture2D characterTexture;	// Animation representing the character.
        public Vector2 Position;				// the position of the character.
        public bool Active;						// State of the player.

        static Random rand = new Random();  //Random number generator
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

		public string Name{ get; set; }								// Name of the Character.
		public Texture2D CharacterTexture{ get; private set; }		// Animation representing the character. 
		#endregion

		public void Initialize(Texture2D texture, Vector2 position, string name, int health, int maxhealth, int att, int def,
                                int speed, double acc, int level = 1, string className = "")
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
            this.className = className;


        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CharacterTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
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
            healthBoost = 10 + rand.Next(4) + this.maxhealth / 4;
        }
        else
        {
            // Just increase health by a small amount
            healthBoost = this.maxhealth / 4;
        }
        // If the character is a human, then favour attack and
        // speed boosts over defense, but increase defense
        // 50% of the time too
        if(this.className == "Human")
        {
            attBoost = 1;
            speedBoost = 1;
            if(rand.Next(2) == 0) defBoost = 1;
        }
        // Monster gets same as for human but favour attack and speed
        // instead. 
        else if(this.className == "Monster")
        {
            attBoost = 1;
            defBoost = 1;
            if(rand.Next(2) == 0) speedBoost = 1;
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
  }

}
