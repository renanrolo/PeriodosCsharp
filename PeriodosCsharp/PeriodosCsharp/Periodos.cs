using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace PeriodosCsharp
{
    public static class Periodos
    {
        /// <summary>
        /// Retorna o ultimo dia do mes da data de referencia.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime UltimoDiaDoMes(this DateTime data)
        {
            DateTime dataUltimoDiaDoMes = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
            return dataUltimoDiaDoMes;
        }

        /// <summary>
        /// Retorna o ultimo dia do mes da data de referencia.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime? UltimoDiaDoMes(this DateTime? data)
        {
            if (!data.HasValue)
                return null;

            DateTime dataUltimoDiaDoMes = new DateTime(data.Value.Year, data.Value.Month, DateTime.DaysInMonth(data.Value.Year, data.Value.Month));
            
            return dataUltimoDiaDoMes;
        }

        /// <summary>
        /// Compara datas e retorna a maior. Permite datas nulas, mas retorna somente a maior data que tiver valor.
        /// </summary>
        /// <param name="datas">Datas para comparar</param>
        /// <returns>Retorna a maior data, ou numa lista de nulos retorna null</returns>
        public static DateTime? RetornaMaiorData(params DateTime?[] datas)
        {
            DateTime? retorno = null;

            foreach (var item in datas)
            {
                if (!retorno.HasValue)
                {
                    retorno = item;
                    continue;
                }

                if (item.HasValue && item.Value > retorno.Value)
                {
                    retorno = item;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara datas e retorna a maior.
        /// </summary>
        /// <param name="datas">Datas para comparar</param>
        /// <returns>Retorna a maior data</returns>
        public static DateTime RetornaMaiorData(params DateTime[] datas)
        {
            DateTime retorno = new DateTime();

            foreach (var item in datas)
            {
                if (item > retorno)
                {
                    retorno = item;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara datas e retorna a menor. Permite datas nulas, mas retorna somente a menor data que tiver valor.
        /// </summary>
        /// <param name="datas">Datas para comparar</param>
        /// <returns>Retorna a menor data, ou numa lista de nulos retorna null</returns>
        public static DateTime? RetornaMenorData(params DateTime?[] datas)
        {
            DateTime? retorno = null;

            foreach (var item in datas)
            {
                if (!retorno.HasValue)
                {
                    retorno = item;
                    continue;
                }

                if (item.HasValue && item.Value < retorno.Value)
                {
                    retorno = item;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara datas e retorna a menor.
        /// </summary>
        /// <param name="datas">Datas para comparar</param>
        /// <returns>Retorna a menor data.</returns>
        public static DateTime RetornaMenorData(params DateTime[] datas)
        {
            DateTime retorno = new DateTime(9999, 12, 31);

            foreach (var item in datas)
            {
                if (item < retorno)
                {
                    retorno = item;
                }
            }

            return retorno;
        }

        public static Boolean VerificaPeriodoUnico(List<KeyValuePair<DateTime, DateTime?>> lista)
        {
            DateTime? dataInicioNaoUsada;
            DateTime? dataFimNaoUsada;

            Boolean retorno = VerificaPeriodoUnico(lista, out dataInicioNaoUsada, out dataFimNaoUsada);

            return retorno;
        }

        public static Boolean VerificaPeriodoUnico(List<KeyValuePair<DateTime, DateTime?>> lista, out DateTime? menorDataPeriodo, out DateTime? maiorDataPeriodo)
        {
            try
            {
                menorDataPeriodo = null;
                maiorDataPeriodo = null;

                if (lista == null)
                    return true;

                if (lista.Where(x => x.Value.HasValue && x.Value.Value < x.Key).Any())
                    throw new Exception("VerificaPeriodoUnico - Foi encontrado um (ou mais) periodo(s) com data final menor que data inicial.");

                if (lista.Count() <= 1)
                {
                    if (lista.Any())
                    {
                        menorDataPeriodo = lista.Min(x => x.Key);
                        maiorDataPeriodo = lista.Max(x => x.Value);
                    }

                    return true;
                }

                DateTime menorData = lista.Min(x => x.Key);
                DateTime? maiorData = lista.Max(x => x.Value);

                var listaDeDataFimNula = lista.Where(x => !x.Value.HasValue).ToList();

                if (listaDeDataFimNula.Any())
                {
                    maiorData = listaDeDataFimNula.Min(x => x.Key);
                }

                while (menorData < maiorData)
                {
                    menorData = menorData.AddDays(1);

                    var periodoEncontrado = lista.Where(x => x.Key <= menorData && (!x.Value.HasValue || x.Value >= menorData)).ToList().FirstOrDefault();

                    if (periodoEncontrado.Equals(new KeyValuePair<DateTime, DateTime?>()))
                        return false;

                    if (periodoEncontrado.Value.HasValue)
                        menorData = periodoEncontrado.Value.Value;
                }

                menorDataPeriodo = lista.Min(x => x.Key);
                maiorDataPeriodo = maiorData;

                if (lista.Where(x => !x.Value.HasValue).Any())
                {
                    maiorDataPeriodo = null;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static Boolean VerificaPeriodoUnico<TProperty>(this IEnumerable<TProperty> lista, Expression<Func<TProperty, DateTime>> expressaoDtIni, Expression<Func<TProperty, DateTime?>> expressaoDtFim)
        {
            var nomePropriedadeDtIni = (expressaoDtIni.Body as MemberExpression).Member.Name.ToString();
            var nomePropriedadeDFimi = (expressaoDtFim.Body as MemberExpression).Member.Name.ToString();

            List<KeyValuePair<DateTime, DateTime?>> listaKey =
                lista
                .Select(x =>
                    new KeyValuePair<DateTime, DateTime?>(
                        (DateTime)x.GetType().GetProperty(nomePropriedadeDtIni).GetValue(x, null)
                        , (DateTime?)x.GetType().GetProperty(nomePropriedadeDFimi).GetValue(x, null)))
                .ToList();

            Boolean retorno = VerificaPeriodoUnico(listaKey);

            return retorno;
        }

        public static Boolean VerificaPeriodoUnico<TProperty>(this IEnumerable<TProperty> lista, Expression<Func<TProperty, DateTime>> expressaoDtIni, Expression<Func<TProperty, DateTime?>> expressaoDtFim, out DateTime? menorDtIni, out DateTime? maiorDtFim)
        {
            var nomePropriedadeDtIni = (expressaoDtIni.Body as MemberExpression).Member.Name.ToString();
            var nomePropriedadeDFimi = (expressaoDtFim.Body as MemberExpression).Member.Name.ToString();

            List<KeyValuePair<DateTime, DateTime?>> listaKey =
                lista
                .Select(x =>
                    new KeyValuePair<DateTime, DateTime?>(
                        (DateTime)x.GetType().GetProperty(nomePropriedadeDtIni).GetValue(x, null)
                        , (DateTime?)x.GetType().GetProperty(nomePropriedadeDFimi).GetValue(x, null)))
                .ToList();

            Boolean retorno = VerificaPeriodoUnico(listaKey, out menorDtIni, out maiorDtFim);

            return retorno;
        }

        public static Boolean VerificaPeriodosSemConflito(List<KeyValuePair<DateTime, DateTime?>> lista)
        {
            if (lista == null || lista.Count() <= 1)
            {
                return true;
            }

            foreach (var item in lista)
            {
                var listaSemOProprioElemento = lista.Where(x => x.Key != item.Key).ToList();

                if (item.Value.HasValue)
                {
                    if (listaSemOProprioElemento.Any(x => x.Value.HasValue && item.Key <= x.Value.Value && item.Value.Value >= x.Key))
                    {
                        return false;
                    }
                    if (listaSemOProprioElemento.Any(x => !x.Value.HasValue && item.Value.Value >= x.Key))
                    {
                        return false;
                    }
                }
                else
                {
                    if (listaSemOProprioElemento.Any(x => !x.Value.HasValue))
                    {
                        return false;
                    }
                    if (listaSemOProprioElemento.Any(x => x.Value.HasValue && item.Key <= x.Value.Value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static Boolean VerificaPeriodosSemConflito<TProperty>(this IEnumerable<TProperty> lista, Expression<Func<TProperty, DateTime>> expressaoDtIni, Expression<Func<TProperty, DateTime?>> expressaoDtFim)
        {
            var nomePropriedadeDtIni = RetornaNomePropriedade(expressaoDtIni);
            var nomePropriedadeDFimi = RetornaNomePropriedade(expressaoDtFim); ;

            List<KeyValuePair<DateTime, DateTime?>> listaKey =
                lista
                .Select(x =>
                    new KeyValuePair<DateTime, DateTime?>(
                        (DateTime)x.GetType().GetProperty(nomePropriedadeDtIni).GetValue(x, null)
                        , (DateTime?)x.GetType().GetProperty(nomePropriedadeDFimi).GetValue(x, null)))
                .ToList();

            Boolean retorno = VerificaPeriodosSemConflito(listaKey);

            return retorno;
        }

        private static string RetornaNomePropriedade(LambdaExpression memberSelector)
        {
            if ((memberSelector.Body as MemberExpression).Expression.NodeType == ExpressionType.MemberAccess)
            {
                return ((memberSelector.Body as MemberExpression).Expression as MemberExpression).Member.Name;
            }

            return (memberSelector.Body as MemberExpression).Member.Name;
        }

        /// <summary>
        /// Compara datas. 
        /// </summary>
        /// <param name="essaData"></param>
        /// <param name="outraData">Data a ser comparada.</param>
        public static Boolean MaiorQue(this DateTime essaData, DateTime outraData)
        {
            Boolean comparacao = false;

            if (DateTime.Compare(essaData, outraData) > 0)
            {
                comparacao = true;
            }

            return comparacao;
        }

        /// <summary>
        /// Compara datas. 
        /// </summary>
        /// <param name="essaData"></param>
        /// <param name="outraData">Data a ser comparada.</param>
        public static Boolean MaiorOuIgualQue(this DateTime essaData, DateTime outraData)
        {
            Boolean comparacao = false;

            if (DateTime.Compare(essaData, outraData) > -1)
            {
                comparacao = true;
            }

            return comparacao;
        }

        /// <summary>
        /// Compara datas. 
        /// </summary>
        /// <param name="essaData"></param>
        /// <param name="outraData">Data a ser comparada.</param>
        public static Boolean IgualQue(this DateTime essaData, DateTime outraData)
        {
            Boolean comparacao = false;

            if (DateTime.Compare(essaData, outraData) == 0)
            {
                comparacao = true;
            }

            return comparacao;
        }

        /// <summary>
        /// Compara datas. 
        /// </summary>
        /// <param name="essaData"></param>
        /// <param name="outraData">Data a ser comparada.</param>
        public static Boolean MenorQue(this DateTime essaData, DateTime outraData)
        {
            Boolean comparacao = false;

            if (DateTime.Compare(essaData, outraData) == -1)
            {
                comparacao = true;
            }

            return comparacao;
        }

        /// <summary>
        /// Compara datas. 
        /// </summary>
        /// <param name="essaData"></param>
        /// <param name="outraData">Data a ser comparada.</param>
        public static Boolean MenorOuIgualQue(this DateTime essaData, DateTime outraData)
        {
            Boolean comparacao = false;

            if (DateTime.Compare(essaData, outraData) <= 0)
            {
                comparacao = true;
            }

            return comparacao;
        }

    }
}
