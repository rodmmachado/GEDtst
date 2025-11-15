using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using BPDWeb.Kernel.Dominio;

namespace BPDWeb.Kernel.DB.Atributo
{
    public class ValidarAtributo
    {
        public ValidarAtributo()
        {

        }

        public string ValidarInclusao(PropertyInfo objeto, bool obrigatorio, string erro, DominioDAO dao, bool validarObrigatorieade, bool valorBase)
        {
            switch (objeto.PropertyType.ToString())
            {
                case "System.Int32":
                    {
                        int inteiro = Convert.ToInt32(objeto.GetValue(dao, null));
                        if ((inteiro <= 0) && (obrigatorio) && (validarObrigatorieade) && (!valorBase))
                        {
                            throw new Exception("O campo ( " + erro + " ) é obrigatório");
                        }

                        if ((inteiro <= 0) && (!valorBase))
                        {
                            return "";
                        }
                        return inteiro.ToString();

                    }

                case "System.String":
                    {
                        string texto = Convert.ToString(objeto.GetValue(dao, null));
                        texto = texto.Replace("'", "''");
                        if ((texto.Length <= 0) && (obrigatorio) && (validarObrigatorieade))
                        {
                            throw new Exception("O campo ( " + erro + " ) é obrigatório");
                        }

                        if (texto.Length <= 0)
                        {
                            return "";
                        }
                        return "'" + texto + "'";

                    }
                case "System.DateTime":
                    {
                        DateTime data = Convert.ToDateTime(objeto.GetValue(dao, null));
                        if (((data == DateTime.MaxValue) || (data == DateTime.MinValue)) && (obrigatorio) && (validarObrigatorieade))
                        {
                            throw new Exception("O campo ( " + erro + " ) é obrigatório");
                        }

                        if ((data == DateTime.MaxValue) || (data == DateTime.MinValue))
                        {
                            return "null";
                        }
                        return "'" + data.ToString("yyyy-MM-dd HH:mm:ss") + "'";

                    }
                case "System.TimeSpan":
                    {
                        TimeSpan @timeSpan = TimeSpan.Parse(objeto.GetValue(dao, null).ToString());

                        if ((@timeSpan <= new TimeSpan()) && (obrigatorio) && (validarObrigatorieade))
                        {
                            throw new Exception("O campo ( " + erro + " ) é obrigatório");
                        }

                        if (@timeSpan <= new TimeSpan())
                        {
                            return "";
                        }
                        return "'" + @timeSpan.ToString() + "'";

                    }
                case "System.Decimal":
                    {
                        decimal @decimal = Convert.ToDecimal(objeto.GetValue(dao, null));
                        if ((@decimal <= 0) && (obrigatorio) && (validarObrigatorieade) && (!valorBase))
                        {
                            throw new Exception("O campo ( " + erro + " ) é obrigatório");
                        }

                        if ((@decimal <= 0) && (!valorBase))
                        {
                            return "";
                        }
                        return @decimal.ToString().Replace(",", ".");

                    }


                case "System.Int64":
                    {
                        long inteiro = Convert.ToInt64(objeto.GetValue(dao, null));
                        if ((inteiro <= 0) && (obrigatorio) && (validarObrigatorieade) && (!valorBase))
                        {
                            throw new Exception("O campo ( " + erro + " ) é obrigatório");
                        }
                        if ((inteiro <= 0) && (!valorBase))
                        {
                            return "";
                        }
                        return inteiro.ToString();

                    }
                case "System.Boolean":
                    {
                        bool inteiro = Convert.ToBoolean(objeto.GetValue(dao, null));
                        return inteiro.ToString();

                    }
            }
            return "";
        }
    }
}
