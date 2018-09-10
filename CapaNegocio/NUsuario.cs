using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
   public class NUsuario
    {
        //Métodos para comunicarnos con la capa datos
        //Método Insertar que llama al método Insertar de la clase DCliente
        //de la CapaDatos
        public static string Insertar(string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento, string cuit,
            string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DUsuario Obj = new DUsuario();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Cuit = cuit;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DCliente
        //de la CapaDatos
        public static string Editar(int idusuario, string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento, string cuit,
            string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DUsuario Obj = new DUsuario();
            Obj.Idusuario = idusuario;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Cuit = cuit;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCliente
        //de la CapaDatos
        public static string Eliminar(int idusuario)
        {
            DUsuario Obj = new DUsuario();
            Obj.Idusuario = idusuario;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCliente
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DUsuario().Mostrar();
        }

        //Método BuscarApellidos que llama al método BuscarApellidos
        //de la clase DCLiente de la CapaDatos

        public static DataTable BuscarApellido(string textobuscar)
        {
            DUsuario Obj = new DUsuario();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellido(Obj);
        }

        //Método BuscarNOmbre que llama al método BuscarNombre
        //de la clase DCLiente de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DUsuario Obj = new DUsuario();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        //Método BuscarNum_Documento que llama al método BuscarNum_Documento
        //de la clase DCliente de la CapaDatos

        public static DataTable BuscarCuit(string textobuscar)
        {
            DUsuario Obj = new DUsuario();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCuit(Obj);
        }

        public static DataTable Login(string usuario, string password)
        {
            DUsuario Obj = new DUsuario();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }
    }
}

