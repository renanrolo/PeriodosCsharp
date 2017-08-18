using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeriodosCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes
{
    [TestClass]
    public class TestPeriodosSemConflito
    {
        [TestMethod]
        public void Testar_VerificaPeriodosSemConflito_com_datas_iniciais_iguais_incorreto()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), null);
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 07, 15));

            lista.Add(periodoUm);
            lista.Add(periodoDois);

            var teste = PeriodosUtil.VerificaPeriodosSemConflito(lista);

            Assert.IsFalse(teste);
        }

        [TestMethod]
        public void Testar_VerificaPeriodosSemConflito_com_datas_iguais_incorreto()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 08, 15));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 08, 15));

            lista.Add(periodoUm);
            lista.Add(periodoDois);

            var teste = PeriodosUtil.VerificaPeriodosSemConflito(lista);

            Assert.IsFalse(teste);
        }

        [TestMethod]
        public void Testar_VerificaPeriodosSemConflito_com_data_inicial_igual_data_final()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 07, 01));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 07, 01), new DateTime(2016, 07, 01));

            lista.Add(periodoUm);
            lista.Add(periodoDois);

            var teste = PeriodosUtil.VerificaPeriodosSemConflito(lista);

            Assert.IsFalse(teste);
        }

        [TestMethod]
        public void Testar_VerificaPeriodosSemConflito_correto()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 07, 01));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 08, 01), new DateTime(2016, 08, 01));

            lista.Add(periodoUm);
            lista.Add(periodoDois);

            var teste = PeriodosUtil.VerificaPeriodosSemConflito(lista);

            Assert.IsTrue(teste);
        }

        #region Com lambda
        [TestMethod]
        public void Teste_VerificaPeriodoUnico_com_um_so_periodo()
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

            var periodoUm = new ClasseAuxiliar() { DataInicio = new DateTime(2016, 01, 06), DataFim = new DateTime(2016, 01, 20) };
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
            var periodoTres = new ClasseAuxiliar() { DataInicio = new DateTime(2016, 04, 01), DataFim = new DateTime(2016, 04, 20) };

            lista.Add(periodoUm);
            lista.Add(periodoDois);
            lista.Add(periodoTres);

            Boolean retorno = lista.VerificaPeriodoUnico(dtIni => dtIni.DataInicio, dtFim => dtFim.DataFim);

            Assert.AreEqual(false, retorno);
        }
        #endregion
    }
}
