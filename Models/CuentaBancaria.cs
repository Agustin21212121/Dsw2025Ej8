using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Models;

public class CuentaBancaria
{
    protected TipoCuenta _tipo { get; }
    public string _numero { get; }
    public decimal _saldo { get; set; }
    protected Estado _estado { get; set; }
    protected string[] _titulares { get; }

    public CuentaBancaria(string numero, decimal saldo)
    {
        _numero = numero;
        _saldo = saldo;
        _estado = Estado.Activa;

    }

    public virtual void Depositar(decimal monto)
    {
        if (_estado != Estado.Activa)
        {
            throw new CuentaNoActiva("No se puede operar con la cuenta {_estado})");
        }

        if (monto <= 0)
        {
            throw new MontoNoValido("El monto ingresado no es válido para la operación solicitada");
        }
    }

    public virtual void Retirar(decimal monto)
    {
        if (_estado != Estado.Activa)
        {
            throw new CuentaNoActiva("No se puede operar con la cuenta {_estado})");
        }
        if (monto <= 0)
        {
            throw new MontoNoValido("El monto ingresado no es válido para la operación solicitada");
        }
    }

}






