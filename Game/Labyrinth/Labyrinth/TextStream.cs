using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TextInput{
	class TextStream{

		#region Fields
		Keys[] oldKeys = new Keys[0];

		// switch to see if the shift key has been pressed
		bool isShiftKeyDown;
		bool capLock = false;
		#endregion


		#region Methods
		public void ReadKBInput(ref string userString){

			KeyboardState kb = Keyboard.GetState();

			Keys[] pressedKeys = kb.GetPressedKeys();

			// is the shift key pressed down
			if( kb.IsKeyUp(Keys.LeftShift) && kb.IsKeyUp(Keys.RightShift) )
				isShiftKeyDown = false;
			else
				isShiftKeyDown = true;

			// walk through each key that is presently pressed
			for( int i = 0; i < pressedKeys.Length; ++i ){

				// flag to indicated whether or not we have a key match
				bool matchFound = false;

				// walk through each key that was previously pressed
				for( int j = 0; j < oldKeys.Length; ++j ){
					if( pressedKeys[i] == oldKeys[j] ){
						matchFound = true;
						break;
					}
				}//end nested for

				if(!matchFound){
					switch(pressedKeys[i]){

						#region Digits
						case Keys.D0:
							if(isShiftKeyDown){
								userString = userString + ")";
							}
							else{
								userString = userString + "0";
							}
							break;

						case Keys.D1:
							if(isShiftKeyDown){
								userString = userString + "!";
							}
							else{
								userString = userString + "1";
							}
							break;
	
						case Keys.D2:
							if(isShiftKeyDown){
								userString = userString + "@";
							}
							else{
								userString = userString + "2";
							}
							break;

						case Keys.D3:
							if(isShiftKeyDown){
								userString = userString + "#";
							}
							else{
								userString = userString + "3";
							}
							break;
	
						case Keys.D4:
							if(isShiftKeyDown){
								userString = userString + "$";
							}
							else{
								userString = userString + "4";
							}
							break;

						case Keys.D5:
							if(isShiftKeyDown){
								userString = userString + "%";
							}
							else{
								userString = userString + "5";
							}
							break;
	
						case Keys.D6:
							if(isShiftKeyDown){
								userString = userString + "^";
							}
							else{
								userString = userString + "6";
							}
							break;

						case Keys.D7:
							if(isShiftKeyDown){
								userString = userString + "&";
							}
							else{
								userString = userString + "7";
							}
							break;
	
						case Keys.D8:
							if(isShiftKeyDown){
								userString = userString + "*";
							}
							else{
								userString = userString + "8";
							}
							break;

						case Keys.D9:
							if(isShiftKeyDown){
								userString = userString + "(";
							}
							else{
								userString = userString + "9";
							}
							break;
						#endregion
							
						#region Alphabet
						case Keys.A:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "A";
							}
							else{
								userString = userString + "a";
							}
							break;

						case Keys.B:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "B";
							}
							else{
								userString = userString + "b";
							}
							break;

						case Keys.C:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "C";
							}
							else{
								userString = userString + "c";
							}
							break;

						case Keys.D:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "D";
							}
							else{
								userString = userString + "d";
							}
							break;

						case Keys.E:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "E";
							}
							else{
								userString = userString + "e";
							}
							break;

						case Keys.F:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "F";
							}
							else{
								userString = userString + "f";
							}
							break;

						case Keys.G:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "G";
							}
							else{
								userString = userString + "g";
							}
							break;

						case Keys.H:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "H";
							}
							else{
								userString = userString + "h";
							}
							break;

						case Keys.I:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "I";
							}
							else{
								userString = userString + "i";
							}
							break;

						case Keys.J:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "J";
							}
							else{
								userString = userString + "j";
							}
							break;

						case Keys.K:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "K";
							}
							else{
								userString = userString + "k";
							}
							break;

						case Keys.L:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "L";
							}
							else{
								userString = userString + "l";
							}
							break;

						case Keys.M:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "M";
							}
							else{
								userString = userString + "m";
							}
							break;

						case Keys.N:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "N";
							}
							else{
								userString = userString + "n";
							}
							break;

						case Keys.O:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "O";
							}
							else{
								userString = userString + "o";
							}
							break;

						case Keys.P:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "P";
							}
							else{
								userString = userString + "p";
							}
							break;

						case Keys.Q:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "Q";
							}
							else{
								userString = userString + "q";
							}
							break;

						case Keys.R:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "R";
							}
							else{
								userString = userString + "r";
							}
							break;

						case Keys.S:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "S";
							}
							else{
								userString = userString + "s";
							}
							break;

						case Keys.T:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "T";
							}
							else{
								userString = userString + "t";
							}
							break;

						case Keys.U:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "U";
							}
							else{
								userString = userString + "u";
							}
							break;

						case Keys.V:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "V";
							}
							else{
								userString = userString + "v";
							}
							break;

						case Keys.W:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "W";
							}
							else{
								userString = userString + "w";
							}
							break;

						case Keys.X:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "X";
							}
							else{
								userString = userString + "x";
							}
							break;

						case Keys.Y:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "Y";
							}
							else{
								userString = userString + "y";
							}
							break;

						case Keys.Z:
							// caps lock will toggle isShiftKeyDown
							if(capLock)
								isShiftKeyDown = !isShiftKeyDown;

							if(isShiftKeyDown){
								userString = userString + "Z";
							}
							else{
								userString = userString + "z";
							}
							break;
						#endregion

						#region Punctuation marks
						case Keys.OemTilde:
							if(isShiftKeyDown){
								userString = userString + "`";
							}
							else{
								userString = userString + "~";
							}
							break;

						case Keys.OemMinus:
							if(isShiftKeyDown){
								userString = userString + "_";
							}
							else{
								userString = userString + "-";
							}
							break;

						case Keys.OemPlus:
							if(isShiftKeyDown){
								userString = userString + "+";
							}
							else{
								userString = userString + "=";
							}
							break;

						case Keys.OemOpenBrackets:
							if(isShiftKeyDown){
								userString = userString + "{";
							}
							else{
								userString = userString + "[";
							}
							break;

						case Keys.OemCloseBrackets:
							if(isShiftKeyDown){
								userString = userString + "}";
							}
							else{
								userString = userString + "]";
							}
							break;

						case Keys.OemPipe:
							if(isShiftKeyDown){
								userString = userString + "|";
							}
							else{
								userString = userString + "\\";
							}
							break;

						case Keys.OemSemicolon:
							if(isShiftKeyDown){
								userString = userString + ":";
							}
							else{
								userString = userString + ";";
							}
							break;

						case Keys.OemQuotes:
							if(isShiftKeyDown){
								userString = userString + "\"";
							}
							else{
								userString = userString + "'";
							}
							break;

						case Keys.OemComma:
							if(isShiftKeyDown){
								userString = userString + "<";
							}
							else{
								userString = userString + ",";
							}
							break;

						case Keys.OemPeriod:
							if(isShiftKeyDown){
								userString = userString + ">";
							}
							else{
								userString = userString + ".";
							}
							break;

						case Keys.OemQuestion:
							if(isShiftKeyDown){
								userString = userString + "?";
							}
							else{
								userString = userString + "/";
							}
							break;
						#endregion

						#region NumPad
						case Keys.NumPad0:
							userString = userString + "0";
							break;

						case Keys.NumPad1:
							userString = userString + "1";
							break;

						case Keys.NumPad2:
							userString = userString + "2";
							break;

						case Keys.NumPad3:
							userString = userString + "3";
							break;

						case Keys.NumPad4:
							userString = userString + "4";
							break;

						case Keys.NumPad5:
							userString = userString + "5";
							break;

						case Keys.NumPad6:
							userString = userString + "6";
							break;

						case Keys.NumPad7:
							userString = userString + "7";
							break;

						case Keys.NumPad8:
							userString = userString + "8";
							break;

						case Keys.NumPad9:
							userString = userString + "9";
							break;

						case Keys.Multiply:
							userString = userString + "*";
							break;

						case Keys.Add:
							userString = userString + "+";
							break;

						case Keys.Subtract:
							userString = userString + "-";
							break;

						case Keys.Decimal:
							userString = userString + ".";
							break;

						case Keys.Divide:
							userString = userString + "/";
							break;
						#endregion

						#region Format and Editing
						case Keys.CapsLock:
							capLock = !capLock;
							break;

						case Keys.Back:
							if( userString.Length > 0 )
								userString = userString.Remove(userString.Length - 1);
							break;

						case Keys.Space:
							if( userString.Length > 0 )		// prevent user from entering spaces at the beginning of the string
								userString = userString + " ";
							break;

						case Keys.Enter:
							userString = userString + System.Environment.NewLine;
							break;
						#endregion
					}//end switch	
				}
			}// end for

			// remember the currently pressed key for next time
			oldKeys = pressedKeys;
		}//end ReadInput
		#endregion


	}//end class TextStream
}
