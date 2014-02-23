// a central deposit for variables that will be used across different class

using System;
using System.Collections.Generic;


namespace Labyrinth{
	static class ControlVariables{

		// Class of the character; Human, Monster or Mecha.
		public static enum ClassName{ HUMAN, MONSTER, MECHA, NULL };
	}
}
