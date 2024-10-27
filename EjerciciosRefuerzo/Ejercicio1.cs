using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosRefuerzo
{
    internal class Ejercicio1
    {
        public static void ejercicio1()
        {
            Cuenta cuenta1 = new Cuenta("Paula Atencia");
            cuenta1.Ingresar(500);
            Console.WriteLine(cuenta1.ToString()); 

            cuenta1.Retirar(100);
            Console.WriteLine(cuenta1.ToString()); 

            cuenta1.Retirar(50);
            Console.WriteLine(cuenta1.ToString());
        }
    }
    public class Cuenta
    {
        private string titular;
        private double cantidad;

        public Cuenta(string titular)
        {
            this.titular = titular;
            this.cantidad = 0;
        }


        public Cuenta(string titular, double cantidad)
        {
            this.titular = titular;
            this.cantidad = cantidad;
        }


        public string Titular
        {
            get { return titular; }
            set { titular = value; }
        }

        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public override string ToString()
        {
            return $"Titular: {titular}, Cantidad: {cantidad}";
        }

        public void Ingresar(double cantidad)
        {
            if (cantidad > 0)
            {
                this.cantidad += cantidad;
            }
        }

        public void Retirar(double cantidad)
        {
            if (this.cantidad - cantidad < 0)

            {
                this.cantidad = 0;
            }

            else
            {
                this.cantidad -= cantidad;
            }
        }
    }

 
}


