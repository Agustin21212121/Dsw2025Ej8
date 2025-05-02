using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Models
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public decimal _tasaDeInteres = 0.03m;
        public CajaDeAhorro(string numero, decimal saldo)
            : base(numero, saldo)
        {
        }

        public override void Depositar(decimal monto)
        {
            base.Depositar(monto);
            _saldo += monto;

        }


        public override void Retirar(decimal monto)
        {
            base.Retirar(monto);

            if (_saldo >= monto)
            {
                _saldo -= monto;
            }
            else
            {
                _estado = Estado.Suspendida;
                throw new SaldoInsuficiente("Saldo insuficiente. La cuenta fue suspendida.");
            }
        }

        public virtual void AplicarInteres()
        {

            _saldo += _saldo * _tasaDeInteres;

        }
    }
}
