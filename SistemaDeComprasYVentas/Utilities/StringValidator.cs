using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Utilities
{
	public class StringValidator
	{
		private const int maxUsuarioSize = 50;
		private const int maxContrasenaSize = 20;
		private const int minUsuarioSize = 3;
		private const int minContrasenaSize = 8;
		private const int minNombreSize = 3;
		private const int minApellidoSize = 5;
		private const int minCorreoSize = 10;
		private const int minCalleSize = 3;
		private const int telefonoSize = 10;

		private bool IsStringValidSize( string input, int minSize, int maxSize )
		{
			return ( input.Length >= minSize && input.Length <= maxSize );
		}

		private bool HasSpaces( string input )
		{
			bool hasSpaces = false;
			foreach( char letter in input ) 
			{
				if( letter == ' ' )
				{
					hasSpaces = true;
				}
			}
			return hasSpaces;
		}

		private bool HasNumbers( string input )
		{
			bool hasNumbers = false;
			foreach( char letter in input )
			{
				if( letter >= 48 && letter <= 57 )
				{
					hasNumbers = true;
				}
			}
			return hasNumbers;
		}

		private bool HasSingleAtCharacter( string input )
		{
			int counter = 0;
			foreach( char letter in input )
			{
				if( letter == '@' )
				{
					counter += 1;
				}
			}
			return counter == 1;
		}

		private bool HasInvalidCharacter( string input )
		{
			bool hasInvalidCharacter = false;
			foreach( char letter in input )
			{
				if( letter == ';' || letter == '|' || letter == '=' ||
					letter == 39 )
				{
					hasInvalidCharacter = true;
				}
			}
			return hasInvalidCharacter;
		}

		private bool HasOnlyNumbers( string input )
		{
			bool hasOnlyNumbers = true;
			foreach( char letter in input )
			{
				if( letter < 48 || letter > 57 )
				{
					hasOnlyNumbers = false;
				}
			}
			return hasOnlyNumbers;
		}
	}
}
