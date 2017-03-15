using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmpleadosEmailBLL
    {
        public static bool Guardar(Entidades.EmpleadosEmails email)
        {
            using (var conec = new DAL.Repository<Entidades.EmpleadosEmails>())
            {
                try
                {
                    return conec.Guardar(email);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return false;
        }

        public static bool Eliminar(Entidades.EmpleadosEmails email)
        {
            using (var conec = new DAL.Repository<Entidades.EmpleadosEmails>())
            {
                try
                {
                    return conec.Eliminar(email);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return false;
        }

        public static bool Modificar(Entidades.EmpleadosEmails email)
        {
            using (var conec = new DAL.Repository<Entidades.EmpleadosEmails>())
            {
                try
                {
                    return conec.Modificar(email);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return false;
        }

        public static Entidades.EmpleadosEmails Buscar(Expression<Func<Entidades.EmpleadosEmails, bool>> criterio)
        {
            using (var conec = new DAL.Repository<Entidades.EmpleadosEmails>())
            {
                try
                {
                    return conec.Buscar(criterio);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<Entidades.EmpleadosEmails> GetList(Expression<Func<Entidades.EmpleadosEmails, bool>> criterio)
        {
            using (var conec = new DAL.Repository<Entidades.EmpleadosEmails>())
            {
                try
                {
                    return conec.GetList(criterio);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<Entidades.EmpleadosEmails> GetListAll()
        {
            using (var conec = new DAL.Repository<Entidades.EmpleadosEmails>())
            {
                try
                {
                    return conec.GetListAll();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
