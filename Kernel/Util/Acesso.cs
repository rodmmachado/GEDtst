using BPDWeb.Kernel.Criptografia;

namespace BPDWeb.Kernel.Seguranca
{
	/// <summary>
	/// Classe Acesso
	/// </summary>
	public class Acesso
	{
		#region Construtores

		/// <summary>
		/// Construtor de Acesso sem parâmetros
		/// </summary>
		public Acesso()
		{
			
		}
		
		#endregion
		
		#region Atributos
		
		private string _pagina;
		/// <summary>
		/// Página
		/// </summary>
		public string Pagina
		{
			get
			{
				return _pagina;
			}
			set
			{
				_pagina = value;
			}
		}

		#endregion

		#region Metodos


		/// <summary>
		/// Método para criptografar parametros passados como argumento
		/// </summary>
		/// <param name="parametros">parametros passado como argumento </param>
		/// <returns>Parâmetro Criptografado</returns>
		public string CriptografarParametros(string parametros)
		{
			SecureQueryString crip = new SecureQueryString();
			string []listaParametros = parametros.Split('&');
			string []subParametos;
			foreach(string item in listaParametros)
			{
				subParametos = item.Split('=');
				crip[subParametos[0]] = subParametos[1];
			}
			return crip.EncryptedString;
		}

		/// <summary>
		/// Método para recuperar um valor de um parametro
		/// </summary>
		/// <param name="parametros">Lista de parametros</param>
		/// <param name="valor">recupera o valor de um parametro escolhido</param>
		/// <returns>Parametro descriptografado</returns>
		public string DesCriptografarParametros(string parametros, string valor)
		{
			SecureQueryString crip = new SecureQueryString(parametros);
			return crip[valor];
		}
		
		#endregion 

		
	}
}
