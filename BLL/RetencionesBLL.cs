using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RetencionesBLL
    {
        public static bool Guardar(Entidades.Retenciones retencion)
        {
            using (var conec = new DAL.Repository<Entidades.Retenciones>())
            {
                try
                {
                    return conec.Guardar(retencion);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return false;
        }

        public static bool Eliminar(Entidades.Retenciones retencion)
        {
            using (var conec = new DAL.Repository<Entidades.Retenciones>())
            {
                try
                {
                    return conec.Eliminar(retencion);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return false;
        }

        public static bool Modificar(Entidades.Retenciones retencion)
        {
            using (var conec = new DAL.Repository<Entidades.Retenciones>())
            {
                try
                {
                    return conec.Modificar(retencion);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return false;
        }

        public static Entidades.Retenciones Buscar(Expression<Func<Entidades.Retenciones, bool>> criterio)
        {
            using (var conec = new DAL.Repository<Entidades.Retenciones>())
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

        public static List<Entidades.Retenciones> GetList(Expression<Func<Entidades.Retenciones, bool>> criterio)
        {
            using (var conec = new DAL.Repository<Entidades.Retenciones>())
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

        public static List<Entidades.Retenciones> GetListAll()
        {
            using (var conec = new DAL.Repository<Entidades.Retenciones>())
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
