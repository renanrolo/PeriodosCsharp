using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PeriodosCsharp;

namespace Testes
{
    [TestClass]
    public class TestSuit
    {

        [TestMethod]
        public void Testar_Criar_lista_null()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            lista = null;

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_lista_vazia()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_um_periodo()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 30));

            lista.Add(periodoUm);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_lista_com_dois_periodos_corretos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 30));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 15), new DateTime(2016, 07, 15));

            lista.Add(periodoUm);
            lista.Add(periodoDois);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_dois_periodos_invalidos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 30));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 07, 10), new DateTime(2016, 07, 30));

            lista.Add(periodoUm);
            lista.Add(periodoDois);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(false, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_tres_periodos_corretos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 30));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 07, 01), new DateTime(2016, 07, 30));
            KeyValuePair<DateTime, DateTime?> periodoTres = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 05, 01), new DateTime(2016, 08, 30));

            lista.Add(periodoUm);
            lista.Add(periodoDois);
            lista.Add(periodoTres);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_tres_periodos_incorretos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 30));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 05, 01), new DateTime(2016, 07, 15));
            KeyValuePair<DateTime, DateTime?> periodoTres = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 08, 01), new DateTime(2016, 08, 30));

            lista.Add(periodoUm);
            lista.Add(periodoDois);
            lista.Add(periodoTres);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(false, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_dois_periodos_iguais_corretos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 30));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 30));

            lista.Add(periodoUm);
            lista.Add(periodoDois);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_dois_periodos_com_datas_inicio_e_fim_no_mesmo_dia_corretos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 30));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 30), new DateTime(2016, 07, 15));

            lista.Add(periodoUm);
            lista.Add(periodoDois);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_dois_periodos_com_data_fim_um_dia_depois_da_data_inicio_corretos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 30));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 07, 01), new DateTime(2016, 07, 15));

            lista.Add(periodoUm);
            lista.Add(periodoDois);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_tres_periodos_com_datas_inicio_e_fim_no_mesmo_dia_corretos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 30));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 30), new DateTime(2016, 07, 15));
            KeyValuePair<DateTime, DateTime?> periodoTres = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 07, 15), new DateTime(2016, 08, 30));

            lista.Add(periodoUm);
            lista.Add(periodoDois);
            lista.Add(periodoTres);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_um_periodos_com_data_fim_nula_correto()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), null);

            lista.Add(periodoUm);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_dois_periodos_com_data_fim_nula_corretos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), null);
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 07, 01), null);

            lista.Add(periodoUm);
            lista.Add(periodoDois);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_dois_periodos_com_data_fim_nula_e_outro_com_data_fim_definida_correto()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 07, 01));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 07, 01), null);

            lista.Add(periodoUm);
            lista.Add(periodoDois);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        public void Testar_Periodos_com_dois_periodos_com_data_fim_nula_e_outro_com_data_fim_definida_incorretos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 15));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 07, 01), null);

            lista.Add(periodoUm);
            lista.Add(periodoDois);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(false, teste);
        }

        [TestMethod]
        public void Testar_varios_periodos_incorretos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 15));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 15), new DateTime(2016, 06, 20));

            KeyValuePair<DateTime, DateTime?> periodoTres = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 07, 01), new DateTime(2016, 07, 15));
            KeyValuePair<DateTime, DateTime?> periodoQuatro = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 07, 10), new DateTime(2016, 07, 30));

            KeyValuePair<DateTime, DateTime?> periodoCinco = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 08, 01), new DateTime(2016, 08, 15));
            KeyValuePair<DateTime, DateTime?> periodoSeis = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 08, 10), new DateTime(2016, 08, 30));

            lista.Add(periodoUm);
            lista.Add(periodoDois);
            lista.Add(periodoTres);
            lista.Add(periodoQuatro);
            lista.Add(periodoCinco);
            lista.Add(periodoSeis);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(false, teste);
        }

        [TestMethod]
        public void Testar_varios_periodos_corretos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 15));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 15), new DateTime(2016, 06, 20));

            KeyValuePair<DateTime, DateTime?> periodoTres = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 20), new DateTime(2016, 07, 15));
            KeyValuePair<DateTime, DateTime?> periodoQuatro = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 07, 10), new DateTime(2016, 07, 30));

            lista.Add(periodoUm);
            lista.Add(periodoDois);
            lista.Add(periodoTres);
            lista.Add(periodoQuatro);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        public void Testar_varios_periodos_com_um_deles_englobando_todos_os_outros_corretos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 15));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 15), new DateTime(2016, 06, 20));

            KeyValuePair<DateTime, DateTime?> periodoTres = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 07, 20), new DateTime(2016, 07, 30));
            KeyValuePair<DateTime, DateTime?> periodoQuatro = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 05, 10), new DateTime(2016, 08, 30));

            lista.Add(periodoUm);
            lista.Add(periodoDois);
            lista.Add(periodoTres);
            lista.Add(periodoQuatro);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Testar_varios_periodos_com_um_deles_com_data_fim_menor_que_data_inicio_errado()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 15));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 15), new DateTime(2016, 07, 20));

            KeyValuePair<DateTime, DateTime?> periodoTres = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 07, 20), new DateTime(2016, 07, 30));
            KeyValuePair<DateTime, DateTime?> periodoQuatro = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 10), new DateTime(2016, 06, 9));

            lista.Add(periodoUm);
            lista.Add(periodoDois);
            lista.Add(periodoTres);
            lista.Add(periodoQuatro);

            var teste = Periodos.VerificaPeriodoUnico(lista);
        }

        [TestMethod]
        public void Testar_varios_periodos_com_datas_fim_e_data_inicio_no_mesmo_dia_e_periodos_no_dia_seguinte_corretos()
        {
            List<KeyValuePair<DateTime, DateTime?>> lista = new List<KeyValuePair<DateTime, DateTime?>>();

            KeyValuePair<DateTime, DateTime?> periodoUm = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 01), new DateTime(2016, 06, 01));
            KeyValuePair<DateTime, DateTime?> periodoDois = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 02), new DateTime(2016, 06, 02));
            KeyValuePair<DateTime, DateTime?> periodoTres = new KeyValuePair<DateTime, DateTime?>(new DateTime(2016, 06, 03), new DateTime(2016, 06, 03));

            lista.Add(periodoUm);
            lista.Add(periodoDois);
            lista.Add(periodoTres);

            var teste = Periodos.VerificaPeriodoUnico(lista);

            Assert.AreEqual(true, teste);
        }
    }
}
