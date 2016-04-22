using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeriodosCsharp;
using System.Collections.Generic;

namespace Testes
{
    [TestClass]
    public class TestSuitComLambda
    {
        [TestMethod]
        public void Teste_simples()
        {
            List<ClasseAuxiliar> lista = new List<ClasseAuxiliar>();

            lista.Add(new ClasseAuxiliar() { DataInicio = new DateTime(2016, 01, 06) });

            Boolean retorno = lista.VerificaPeriodoUnico(x => x.DataInicio, y => y.DataFim);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void Teste_Criando_uma_lista_com_varios_periodos()
        {
            List<ClasseAuxiliar> lista = new List<ClasseAuxiliar>();

            var periodoUm = new ClasseAuxiliar() { DataInicio = new DateTime(2016, 01, 06), DataFim =  new DateTime(2016, 01, 20) };
            var periodoDois = new ClasseAuxiliar() { DataInicio = new DateTime(2016, 01, 16), DataFim = new DateTime(2016, 02, 01) };
            var periodoTres = new ClasseAuxiliar() { DataInicio = new DateTime(2016, 02, 01), DataFim = null };

            lista.Add(periodoUm);
            lista.Add(periodoDois);
            lista.Add(periodoTres);

            Boolean retorno = lista.VerificaPeriodoUnico(dtIni => dtIni.DataInicio, dtFim => dtFim.DataFim);

            Assert.AreEqual(true, retorno);
        }


        [TestMethod]
        public void Teste_Criando_uma_lista_com_varios_periodos_sem_criar_um_periodo_unico()
        {
            List<ClasseAuxiliar> lista = new List<ClasseAuxiliar>();

            var periodoUm = new ClasseAuxiliar() { DataInicio = new DateTime(2016, 01, 01), DataFim = new DateTime(2016, 01, 20) };
            var periodoDois = new ClasseAuxiliar() { DataInicio = new DateTime(2016, 02, 01), DataFim = new DateTime(2016, 02, 20) };
            var periodoTres = new ClasseAuxiliar() { DataInicio = new DateTime(2016, 04, 01), DataFim = new DateTime(2016, 04, 20)  };

            lista.Add(periodoUm);
            lista.Add(periodoDois);
            lista.Add(periodoTres);

            Boolean retorno = lista.VerificaPeriodoUnico(dtIni => dtIni.DataInicio, dtFim => dtFim.DataFim);

            Assert.AreEqual(false, retorno);
        }

    }
}
