using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeradorCPF
{
    internal class Class1
    {
        public int[] GeradorCPF()
        {
            Random random = new Random();
            int[] cpf = new int[9];
            for (int i = 0; i < 9; i++)
            {
                cpf[i] = random.Next(0, 10);
            }
            return cpf;
        }

        public int d1(int[] cpf)
        {
            int soma = 0;
            int aux = 10;

            // Gerando Dígito 1
            for (int i = 0; i < 9; i++)
            {
                soma += cpf[i] * aux;
                aux--;
            }

            int d1 = soma % 11;
            if (d1 < 2)
            {
                d1 = 0;
            }
            else
            {
                d1 = 11 - d1;
            }

            return d1;
        }

        public int d2(int[] cpf, int d1)
        {
            int soma = 0;
            int aux = 11;

            // Gerando Dígito 2
            for (int i = 0; i < 9; i++)
            {
                soma += cpf[i] * aux;
                aux--;
            }
            soma += d1 * 2; // Aqui o peso para D1 é 2

            int d2 = soma % 11;
            if (d2 < 2)
            {
                d2 = 0;
            }
            else
            {
                d2 = 11 - d2;
            }

            return d2;
        }

        public string GerarCpfCompleto()
        {
            int[] cpfBase = GeradorCPF();
            int D1 = d1(cpfBase);
            int D2 = d2(cpfBase, D1);

            string cpfCompleto = string.Join("", cpfBase) + $"{D1}{D2}";

            string cpfFormatado = string.Format("{0:000\\.000\\.000\\-00}", Convert.ToInt64(cpfCompleto));

            return cpfFormatado;
        }
    }
}