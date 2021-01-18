namespace Contacts.Domain.Helper
{
    /// <summary>
    /// Class responsible to help the validations.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// CPFs the validatior.
        /// </summary>
        /// <param name="cpf">The CPF.</param>
        /// <returns>Return if is valid.</returns>
        public static bool CpfValidatior(string cpf)
        {
            if (cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" || cpf == "55555555555"
                || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888" || cpf == "99999999999")
            {
                return false;
            }

            int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string existCpf;
            string digit;
            int plus;
            int rest;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            existCpf = cpf.Substring(0, 9);
            plus = 0;

            for (int i = 0; i < 9; i++)
                plus += int.Parse(existCpf[i].ToString()) * mult1[i];
            rest = plus % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            existCpf = existCpf + digit;
            plus = 0;
            for (int i = 0; i < 10; i++)
                plus += int.Parse(existCpf[i].ToString()) * mult2[i];
            rest = plus % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            return cpf.EndsWith(digit);
        }

        /// <summary>
        /// CNPJs the validator.
        /// </summary>
        /// <param name="cnpj">The CNPJ.</param>
        /// <returns>Return if cnpj is valid.</returns>
        public static bool CnpjValidator(string cnpj)
        {
            int[] muti1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multi2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int plus;
            int rest;
            string digit;
            string existCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            existCnpj = cnpj.Substring(0, 12);
            plus = 0;
            for (int i = 0; i < 12; i++)
                plus += int.Parse(existCnpj[i].ToString()) * muti1[i];
            rest = (plus % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            existCnpj = existCnpj + digit;
            plus = 0;
            for (int i = 0; i < 13; i++)
                plus += int.Parse(existCnpj[i].ToString()) * multi2[i];
            rest = (plus % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            return cnpj.EndsWith(digit);
        }
    }
}
