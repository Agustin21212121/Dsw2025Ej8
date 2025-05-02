using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Models
{
    public class CuentaCorriente : CuentaBancaria
    {
        public decimal _comision = 0.05m;
        public decimal _limiteDeDescubierto = 1000m;
        public CuentaCorriente(string numero, decimal saldo)
            : base(numero, saldo)
        {

        }
        public override void Depositar(decimal monto)
        {
            base.Depositar(monto);
            monto -= monto * _comision;
            _saldo += monto;  
        }

        public override void Retirar(decimal monto)
        {
            base.Retirar(monto);

            if (_saldo - monto >= -_limiteDeDescubierto)
            {
                _saldo -= monto;

                if (_saldo < 0)
                {
                    _estado = Estado.Suspendida;
                }
            }
            else
            {
                _estado = Estado.Suspendida;
                throw new SaldoInsuficiente("Saldo insuficiente. La cuenta fue suspendida.");
            }
        }
    }
}


