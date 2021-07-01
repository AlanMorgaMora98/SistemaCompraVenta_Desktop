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
		private const int maxEvaluacionSize = 200;
		private const int minUsuarioSize = 3;
		private const int minContrasenaSize = 8;
		private const int minNombreSize = 3;
		private const int minApellidoSize = 5;
		private const int minCorreoSize = 10;
		private const int minCalleSize = 3;
		private const int minEvaluacionSize = 20;
		private const int telefonoSize = 10;
		private const int codigoPostalSize = 5;
		private const int maxEstadoSize = 20;
		private const int minEstadoSize = 6;
		private const int maxMunicipioSize = 30;
		private const int minMunicipioSize = 6;
		private const int maxColoniaSize = 30;
		private const int minColoniaSize = 3;
		private const int maxDireccionSize = 25;
		private const int minDireccionSize = 5;
		private const int maxNumeroInternoSize = 5;
		private const int minNumeroInternoSize = 1;
		private const int maxNumeroExternoSize = 3;
		private const int minNumeroExternoSize = 1;
		private const int maxDescripcionSize = 200;
		private const int minDescripcionSize = 15;
		private const int maxNombreHabienteSize = 80;
		private const int minNombreHabienteSize = 10;
		private const int NumeroTarjetaSize = 16;
		private const int maxNombrePublicacionSize = 50;
		private const int minNombrePublicacionSize = 3;
		private const int maxDescripcionPublicacionSize = 200;
		private const int minDescripcionPublicacionSize = 10;
		private const int maxCantidadPublicacionSize = 10000;
		private const int minCantidadPublicacionSize = 1;


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

		public bool IsEvaluacionValid( string evaluacion )
		{
			return ( IsStringValidSize( evaluacion, minEvaluacionSize, maxEvaluacionSize ) && !HasInvalidCharacter( evaluacion ) &&
					 !HasNumbers( evaluacion ) );
		}

		private bool IsStringValidSize( string input, int minSize, int maxSize )
		{
			return ( input.Length >= minSize && input.Length <= maxSize );
		}

		private bool IsIntValidSize(int input, int minSize, int maxSize)
		{
			return (input >= minSize && input <= maxSize);
		}

		public bool IsCodigoPostalValid(string codigoPostal)
		{
			return (codigoPostal.Length == codigoPostalSize) && !HasInvalidCharacter(codigoPostal) && HasOnlyNumbers(codigoPostal);
		}

		public bool IsEstadoValid(string estado)
		{
			return (IsStringValidSize(estado, minEstadoSize, maxEstadoSize) && !HasNumbers(estado) &&
					 !HasInvalidCharacter(estado) && !HasSingleAtCharacter(estado));
		}

		public bool IsMunicipioValid(string municipio)
		{
			return (IsStringValidSize(municipio, minMunicipioSize, maxMunicipioSize) && !HasNumbers(municipio) &&
					 !HasInvalidCharacter(municipio) && !HasSingleAtCharacter(municipio));
		}

		public bool IsColoniaValid(string colonia)
		{
			return (IsStringValidSize(colonia, minColoniaSize, maxColoniaSize) && !HasSingleAtCharacter(colonia) &&
					 !HasInvalidCharacter(colonia) && !HasOnlyNumbers(colonia));
		}

		public bool IsDireccionValid(string direccion)
		{
			return (IsStringValidSize(direccion, minDireccionSize, maxDireccionSize) && !HasSingleAtCharacter(direccion) &&
					 !HasInvalidCharacter(direccion) && !HasOnlyNumbers(direccion));
		}

		public bool IsNumeroInternoValid(int interno)
		{
			return (IsIntValidSize(interno, minNumeroInternoSize, maxNumeroInternoSize));
		}

		public bool IsNumeroExternoValid(int externo)
		{
			return (IsIntValidSize(externo, minNumeroExternoSize, maxNumeroExternoSize));
		}

		public bool IsDescripcionValid(string descripcion)
		{
			return (IsStringValidSize(descripcion, minDescripcionSize, maxDescripcionSize) && !HasSingleAtCharacter(descripcion) &&
					 !HasInvalidCharacter(descripcion) && !HasOnlyNumbers(descripcion));
		}

		public bool IsNombreHabienteValid(string nombre)
		{
			return (IsStringValidSize(nombre, minNombreHabienteSize, maxNombreHabienteSize) && !HasNumbers(nombre) &&
					 !HasInvalidCharacter(nombre) && !HasSingleAtCharacter(nombre));
		}
		
		public bool IsNumeroTarjetaValid(string tarjeta)
		{
			return (IsStringValidSize(tarjeta, NumeroTarjetaSize, NumeroTarjetaSize) && HasOnlyNumbers(tarjeta));
		}
		
		public bool IsNombrePublicacionValid(string nombre)
		{
			return (IsStringValidSize(nombre, minNombrePublicacionSize, maxNombrePublicacionSize) && !HasInvalidCharacter(nombre) && 
					 !HasSingleAtCharacter(nombre));
		}

		public bool IsDescripcionPublicacionValid(string descripcion)
		{
			return (IsStringValidSize(descripcion, minDescripcionPublicacionSize, maxDescripcionPublicacionSize) && !HasInvalidCharacter(descripcion) &&
					 !HasSingleAtCharacter(descripcion) && !HasOnlyNumbers(descripcion));
		}

		public bool IsCantidadPublicacionValid(int cantidad)
		{
			return (IsIntValidSize(cantidad, minCantidadPublicacionSize, maxCantidadPublicacionSize));
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
				if( letter == ';' || letter == '|' || letter == '=' ||
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
