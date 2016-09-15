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

            var teste = Periodos.VerificaPeriodosSemConflito(lista);

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

            var teste = Periodos.VerificaPeriodosSemConflito(lista);

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

            var teste = Periodos.VerificaPeriodosSemConflito(lista);

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

            var teste = Periodos.VerificaPeriodosSemConflito(lista);

            Assert.IsTrue(teste);
        }
    }
}
