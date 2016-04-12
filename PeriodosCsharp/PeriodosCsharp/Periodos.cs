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


                if (lista.Where(x=>x.Value.HasValue && x.Value.Value < x.Key).Any())
                    throw new Exception("Foi encontrado um (ou mais) periodo(s) com data final menor que data inicial.");


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

        public static Boolean VerificaPeriodoUnico<TProperty>(this List<TProperty> lista, Expression<Func<TProperty, DateTime>> expressaoDtIni, Expression<Func<TProperty, DateTime?>> expressaoDtFim)
        {
            List<KeyValuePair<DateTime, DateTime?>> listaKey = new List<KeyValuePair<DateTime, DateTime?>>();

            var nomePropriedadeDtIni = (expressaoDtIni.Body as MemberExpression).Member.Name.ToString();
            var nomePropriedadeDFimi = (expressaoDtFim.Body as MemberExpression).Member.Name.ToString();

            foreach (var item in lista)
            {
                object dtIniObject = item.GetType().GetProperty(nomePropriedadeDtIni).GetValue(item, null);
                object dtFimObject = item.GetType().GetProperty(nomePropriedadeDFimi).GetValue(item, null);

                DateTime dtInicioAux = (DateTime)dtIniObject;
                DateTime? dtFimAux = dtFimObject as DateTime?;

                var novoPeriodo = new KeyValuePair<DateTime, DateTime?>(dtInicioAux, dtFimAux);

                listaKey.Add(novoPeriodo);
            }

            Boolean retorno = VerificaPeriodoUnico(listaKey);

            return retorno; 
        }

        public static Boolean VerificaSozinho<TProperty>(this List<TProperty> lista)
        {
            return true;
        }
    }
}
