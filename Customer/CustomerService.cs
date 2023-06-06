
namespace Customer
{
    public class CustomerService
    {
        public bool ValidateCUIT(long cuit)
        {
            if (cuit.ToString().Length != 11) throw new ArgumentException(nameof(cuit));
            int verificador;
            int resultado = 0;
            long codes = 5432765432;

            verificador = int.Parse(cuit.ToString().Substring(cuit.ToString().Length - 1));
            int x = 0;
            while (x < 10)
            {
                int digitoValidador = int.Parse(codes.ToString().Substring((x), 1));
                int digito = int.Parse(cuit.ToString().Substring((x), 1));
                int digitoValidacion = digitoValidador * digito;
                resultado += digitoValidacion;
                x++;
            }
            resultado = resultado % 11;
            return 11- resultado == verificador;
        }
    }
}
