using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CNUsuario
    {
        //Devolver el metodo lista de la capa datos de la clase CDUsuario
        private CDUsuario objcdUsuario = new CDUsuario();

        public List<Usuario> Listar()
        {
            return objcdUsuario.Lista();
        }
    }
}
