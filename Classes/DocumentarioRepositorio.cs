using System;
using System.Collections.Generic;
using DIO.Documentario.Interfaces;

namespace DIO.Documentario
{
	public class DocumentarioRepositorio : IRepositorio<Documentario>
	{
        private List<Documentario> listaDocumentario = new List<Documentario>();
		public void Atualiza(int id, Documentario objeto)
		{
			listaDocumentario[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaDocumentario[id].Excluir();
		}

		public void Insere(Documentario objeto)
		{
			listaDocumentario.Add(objeto);
		}

		public List<Documentario> Lista()
		{
			return listaDocumentario;
		}

		public int ProximoId()
		{
			return listaDocumentario.Count;
		}

		public Documentario RetornaPorId(int id)
		{
			return listaDocumentario[id];
		}
	}
}
