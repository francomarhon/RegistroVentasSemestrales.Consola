using System.Security.Cryptography;

namespace RegistroVentasSemestrales.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalArsSemestre = 0;
            int contadorVentasSemestre = 0;

            for (int mes = 1; mes <= 6; mes++)
            {
                int contadorVenta=0;
                double totalArs=0;

                Console.WriteLine($"Es {nombreMes(mes)} - dia {mes}");


                do
                {
                    Console.WriteLine("Venta realizada: ");
                    Console.Write("Cual fue el monto en ARS?");
                    double monto = Convert.ToDouble(Console.ReadLine());

                    if (monto >= 5000 && monto <= 15000)
                    {
                        contadorVenta++;
                        totalArs += monto;

                        Console.WriteLine($"Venta N° {contadorVenta} del mes");
                        Console.WriteLine($"Se registro una venta por ${monto} ARS");
                        Console.WriteLine($"Esto equivale a:");
                        Console.WriteLine($"{convertirUSD(monto)} USD");
                        Console.WriteLine($"{convertirEUR(monto)} EUR");
                        Console.WriteLine($"{convertirCNY(monto)} CNY");
                        Console.WriteLine($"La venta se clasifico como {ClasificarVenta(monto)}");

                    }
                    else
                    {
                        Console.WriteLine("El monto debe estar entre 5000 y 15000 ARS");
                    }

                    Console.Write("Desea realizar otra venta? (s/n): ");

                } while (Console.ReadLine()!.ToLower() == "s") ;

                Console.WriteLine("Resumen del mes");
                Console.WriteLine($"Durante el mes de {nombreMes(mes)} se registraron {contadorVenta} ventas");
                Console.WriteLine($"El total de ventas en ARS fue de: ${totalArs}");
                Console.WriteLine($"El total de ventas en USD fue de: ${convertirUSD(totalArs)}");
                Console.WriteLine($"El total de ventas en EUR fue de: ${convertirEUR(totalArs)}");
                double promedioMes = totalArs / contadorVenta;
                Console.WriteLine($"El promedio de ventas del mes fue ${promedioMes}");


                totalArsSemestre += totalArs;
                contadorVentasSemestre += contadorVenta;

            }

            Console.WriteLine("Resumen del semestre");
            Console.WriteLine($"Durante el semestre se registraron {contadorVentasSemestre} ventas");
            Console.WriteLine($"El total de ventas en ARS fue de: ${totalArsSemestre}");
            Console.WriteLine($"El total de ventas en USD fue de: ${convertirUSD(totalArsSemestre)}");
            Console.WriteLine($"El total de ventas en EUR fue de: ${convertirEUR(totalArsSemestre)}");
            double promedioSemestre = totalArsSemestre / contadorVentasSemestre;
            Console.WriteLine($"El promedio de ventas del semestre fue ${promedioSemestre}");

        }

        private static object ClasificarVenta(double monto)
        {
            if (monto <= 20000)
            {
                return "baja";
            }
            else if (monto > 20000 && monto <= 70000)
            {
                return "media";
            }
            else
            {
                return "alta";
            }
        }

        private static object convertirCNY(double monto)
        {
            return monto / 191.22;
        }

        private static object convertirEUR(double monto)
        {
            return monto / 1598.20;
        }

        private static object convertirUSD(double monto)
        {
            return monto / 1364.00;
        }

        private static object nombreMes(int mes)
        {
            switch (mes)
            {
                case 1: return "Enero";
                case 2: return "Febrero";
                case 3: return "Marzo";
                case 4: return "Abril";
                case 5: return "Mayo";
                case 6: return "Junio";
                default: return "Mes no valido";
            }

        }
    }
}
