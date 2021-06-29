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
		private const int maxNombreSize = 30;
		private const int maxApellidoSize = 50;
		private const int maxCorreoSize = 50;
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

		public bool IsUsuarioDataValid( Usuario usuario, string confirmarContrasena )
		{
			return ( AreNamesValid( usuario.nombres ) && AreLastNamesValid( usuario.apellidos ) && IsEmailValid( usuario.correo_electronico ) &&
				     IsTelephoneValid( usuario.telefono ) && IsUsernameValid( usuario.nombre_usuario ) && IsPasswordValid( usuario.contrasena ) &&
					 DoPasswordsMatch( usuario.contrasena, confirmarContrasena ) );
		}

		public bool AreNamesValid( string names )
		{
			return ( IsStringValidSize( names, minNombreSize, maxNombreSize ) && !HasNumbers( names ) &&
					 !HasInvalidCharacter( names ) );
		}

		public bool AreLastNamesValid( string lastNames )
		{
			return ( IsStringValidSize( lastNames, minApellidoSize, maxApellidoSize ) && !HasNumbers( lastNames ) &&
					 !HasInvalidCharacter( lastNames ) );
		}

		public bool IsEmailValid( string email )
		{
			return ( IsStringValidSize( email, minCorreoSize, maxCorreoSize ) && !HasInvalidCharacter( email ) &&
					 HasSingleAtCharacter( email ) );
		}

		public bool IsTelephoneValid( string telephone )
		{
			return ( telephone.Length == telefonoSize ) && !HasInvalidCharacter( telephone ) && HasOnlyNumbers( telephone );
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

		public bool DoPasswordsMatch( string password, string confirmPassword )
		{
			return password.Equals( confirmPassword );
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
