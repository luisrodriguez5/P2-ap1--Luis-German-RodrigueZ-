using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmpleadosRetencioneBLL
    {
        public static bool Guardar(EmpleadoRetenciones relacion)
        {
            using (var conec = new DAL.Repository<EmpleadoRetenciones>())
            {
                try
                {
                    return conec.Guardar(relacion);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return false;
        }

        public static bool Guardar(List<Entidades.EmpleadoRetenciones> lista)
        {
            try
            {
                foreach (var relacion in lista)
                {
                    Guardar(relacion);
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }

            return false;
        }
    }
}
