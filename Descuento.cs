using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] montosCompras = {
            {50, 10, 20, 0, 0},
            {800, 900, 1100, 1200, 1300},
            {1200, 1300, 1400, 1500, 1600},
            {90, 180, 200, 250, 300},
            {70, 150, 300, 700, 800},
            {150, 200, 300, 400, 500}
        };

        CalcularTotalesYDescuentos(montosCompras);
    }

    static void CalcularTotalesYDescuentos(int[,] montosCompras)
    {
        for (int cliente = 0; cliente < montosCompras.GetLength(0); cliente++)
        {
            int totalCompra = 0;

            for (int compra = 0; compra < montosCompras.GetLength(1); compra++)
            {
                totalCompra += montosCompras[cliente, compra];
            }

            double descuento = 0;
            string tipoDescuento = "No puede aplicar un descuento";
            if (totalCompra >= 100 && totalCompra <= 1000)
            {
                descuento = totalCompra * 0.1;
                tipoDescuento = "Descuento del 10%";
            }
            else if (totalCompra > 1000)
            {
                descuento = totalCompra * 0.2;
                tipoDescuento = "Descuento del 20%";
            }

            double totalConDescuento = totalCompra - descuento;

            Console.WriteLine($"Cliente {cliente + 1}:");
            Console.WriteLine($"Total de compras: {totalCompra:C}");
            Console.WriteLine($"Descuento aplicado: {tipoDescuento}");
            Console.WriteLine($"Total con descuento: {totalConDescuento:C}");
            Console.WriteLine();
        }
        Console.ReadKey();
    }
}
