using SistemaDeComprasYVentas.Models;
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

		public bool IsLoginRequestDataValid( LoginRequestData loginInfo )
		{
			return IsUsernameValid( loginInfo.username ) && IsPasswordValid( loginInfo.password );
		}

		public bool IsUsernameValid( string username )
		{
			return ( IsStringValidSize( username, minUsuarioSize, maxUsuarioSize ) && !HaveSpaces( username ) && 
					 !HasInvalidCharacter( username ) );
		}

		public bool IsPasswordValid( string password )
		{
			return ( IsStringValidSize( password, minContrasenaSize, maxContrasenaSize ) && !HaveSpaces( password ) &&
					 !HasInvalidCharacter( password ) );
		}

		private bool IsStringValidSize( string input, int minSize, int maxSize )
		{
			return ( input.Length >= minSize && input.Length <= maxSize );
		}

		private bool HaveSpaces( string input )
		{
			bool haveSpaces = false;
			foreach( char letter in input ) 
			{
				if( letter == ' ' )
				{
					haveSpaces = true;
				}
			}
			return haveSpaces;
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
				if( letter == ';' || letter == '|' || letter == '=' || letter == '.' ||
					letter == 39 || letter == '(' || letter == ')' )
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
