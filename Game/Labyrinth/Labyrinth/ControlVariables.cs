// a central deposit for variables that will be used across different class

using System;
using System.Collections.Generic;


namespace Labyrinth{
	static class ControlVariables{

		// Class of the character; Human, Monster or Mecha.
		public enum ClassName{ HUMAN, MONSTER, MECHA, NULL };

		public enum AnimationSequence{ STAND, WALK, RUN, SPIN, DEAD, NULL };

		public static Random rand = new Random();  //Random number generator
	}
}
