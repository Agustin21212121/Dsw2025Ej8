using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Exceptions;
using Dsw2025Ej8.Models;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cuentas = new List<CuentaBancaria>
        {
            new CajaDeAhorro("1", 1000m) { _tasaDeInteres = 0.04m },
            new CajaDeAhorro("2", 500m) { _tasaDeInteres = 0.03m },
            new CuentaCorriente("3", 300m) { _limiteDeDescubierto = 1500m },
            new CuentaCorriente("4", 700m) { _limiteDeDescubierto = 2000m }
        };

            foreach (var cuenta in cuentas)
            {
                try
                {
                    cuenta.Depositar(0);
                    cuenta.Retirar(-50);

                    if (cuenta is CajaDeAhorro caja)
                    {
                        caja.AplicarInteres();
                    }

                    if (cuenta is CuentaCorriente corriente)
                    {
                        corriente.Depositar(500);
                        corriente.Retirar(2000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }

            Console.WriteLine("\n--- Resumen final de cuentas ---");
            foreach (var cuenta in cuentas)
            {
                var resumen = new
                {
                    Numero = cuenta._numero,
                    Tipo = cuenta.GetType().Name,
                    Saldo = cuenta._saldo
                };

                Console.WriteLine($"Cuenta: {resumen.Numero}, Tipo: {resumen.Tipo}, Saldo: {resumen.Saldo:C}");
            }
        }
    }
}

