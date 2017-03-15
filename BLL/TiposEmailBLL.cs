using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TiposEmailBLL
    {
        public static bool Guardar(Entidades.TiposEmails tipo)
        {
            using (var conec = new Repository<TiposEmails>())
            {
                try
                {
                    return conec.Guardar(tipo);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return false;
        }

        public static bool Eliminar(TiposEmails tipo)
        {
            using (var conec = new DAL.Repository<TiposEmails>())
            {
                try
                {
                    return conec.Eliminar(tipo);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return false;
        }

        public static bool Modificar(TiposEmails tipo)
        {
            using (var conec = new DAL.Repository<TiposEmails>())
            {
                try
                {
                    return conec.Modificar(tipo);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return false;
        }

        public static TiposEmails Buscar(Expression<Func<TiposEmails, bool>> criterio)
        {
            using (var conec = new DAL.Repository<TiposEmails>())
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

        public static List<TiposEmails> GetList(Expression<Func<TiposEmails, bool>> criterio)
        {
            using (var conec = new DAL.Repository<TiposEmails>())
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

        public static List<TiposEmails> GetListAll()
        {
            var tipo = new TiposEmails();

            using (var conec = new DAL.Repository<TiposEmails>())
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
