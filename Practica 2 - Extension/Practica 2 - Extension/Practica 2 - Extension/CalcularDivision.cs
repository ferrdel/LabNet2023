using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2___Extension
{
    public class CalcularDivision
    {
        public int Division(int nro)
        {
            try
            {
                return 999999/nro;
            }
            catch(DivideByZeroException ex)
            {
                throw ex;
            }
            finally
            {
                Console.WriteLine("\n--Operacion Finalizada --  \n");
            }
        }

        public int DivisionDosNros(int nro1, int nro2)
        {
            try
            {
                return nro1 / nro2;
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Console.WriteLine("\n--Operacion Finalizada -- \n");
            }
        }

    }
}
