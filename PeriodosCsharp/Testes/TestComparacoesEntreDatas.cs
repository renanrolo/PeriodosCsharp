using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeriodosCsharp;
namespace Testes
{
    [TestClass]
    public class TestComparacoesEntreDatas
    {
        #region MaiorQue
        [TestMethod]
        public void Testar_data_MariorQue_sendo_maior()
        {
            DateTime dataUm = new DateTime(2015, 10, 01);

            DateTime dataDois = new DateTime(2015, 9, 01);

            Boolean retorno = dataUm.MaiorQue(dataDois);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void Testar_data_MariorQue_sendo_maior_em_segundos()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 6, 15, 10);

            DateTime dataDois = new DateTime(2015, 10, 01, 6, 15, 09);

            Boolean retorno = dataUm.MaiorQue(dataDois);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void Testar_data_MariorQue_sendo_igual()
        {
            DateTime dataUm = new DateTime(2015, 10, 01);

            DateTime dataDois = new DateTime(2015, 10, 01);

            Boolean retorno = dataUm.MaiorQue(dataDois);

            Assert.AreEqual(false, retorno);
        }

        [TestMethod]
        public void Testar_data_MariorQue_sendo_menor()
        {
            DateTime dataUm = new DateTime(2015, 10, 01);

            DateTime dataDois = new DateTime(2015, 10, 02);

            Boolean retorno = dataUm.MaiorQue(dataDois);

            Assert.AreEqual(false, retorno);
        }

        [TestMethod]
        public void Testar_data_MariorQue_sendo_menor_em_segundos()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 6, 15, 10);

            DateTime dataDois = new DateTime(2015, 10, 01, 6, 15, 11);

            Boolean retorno = dataUm.MaiorQue(dataDois);

            Assert.AreEqual(false, retorno);
        }
        #endregion

        #region MaiorOuIgualQue
        [TestMethod]
        public void Testar_data_MariorOuIgualQue_sendo_maior()
        {
            DateTime dataUm = new DateTime(2015, 10, 02);

            DateTime dataDois = new DateTime(2015, 10, 01);

            Boolean retorno = dataUm.MaiorOuIgualQue(dataDois);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void Testar_data_MariorOuIgualQue_sendo_menor()
        {
            DateTime dataUm = new DateTime(2015, 10, 01);

            DateTime dataDois = new DateTime(2015, 10, 02);

            Boolean retorno = dataUm.MaiorOuIgualQue(dataDois);

            Assert.AreEqual(false, retorno);
        }

        [TestMethod]
        public void Testar_data_MariorOuIgualQue_sendo_igual()
        {
            DateTime dataUm = new DateTime(2015, 10, 01);

            DateTime dataDois = new DateTime(2015, 10, 01);

            Boolean retorno = dataUm.MaiorOuIgualQue(dataDois);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void Testar_data_MariorOuIgualQue_sendo_maior_em_segundos()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 12, 30, 31);

            DateTime dataDois = new DateTime(2015, 10, 01, 12, 30, 30);

            Boolean retorno = dataUm.MaiorOuIgualQue(dataDois);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void Testar_data_MariorOuIgualQue_sendo_menor_em_segundos()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 12, 30, 30);

            DateTime dataDois = new DateTime(2015, 10, 01, 12, 30, 31);

            Boolean retorno = dataUm.MaiorOuIgualQue(dataDois);

            Assert.AreEqual(false, retorno);
        }

        [TestMethod]
        public void Testar_data_MariorOuIgualQue_sendo_iguais_em_segundos()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 0, 0, 0);

            DateTime dataDois = new DateTime(2015, 10, 01);

            Boolean retorno = dataUm.MaiorOuIgualQue(dataDois);

            Assert.AreEqual(true, retorno);
        }
        #endregion

        #region IgualQue
        [TestMethod]
        public void Testar_data_IgualQue_sendo_iguais()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 0, 0, 0);

            DateTime dataDois = new DateTime(2015, 10, 01);

            Boolean retorno = dataUm.IgualQue(dataDois);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void Testar_data_IgualQue_sendo_iguais_em_segundos()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 0, 0, 0);

            DateTime dataDois = new DateTime(2015, 10, 01);

            Boolean retorno = dataUm.IgualQue(dataDois);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void Testar_data_IgualQue_sendo_maior()
        {
            DateTime dataUm = new DateTime(2015, 10, 02);

            DateTime dataDois = new DateTime(2015, 10, 01);

            Boolean retorno = dataUm.IgualQue(dataDois);

            Assert.AreEqual(false, retorno);
        }

        [TestMethod]
        public void Testar_data_IgualQue_sendo_maior_em_segundos()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 0, 0, 30);

            DateTime dataDois = new DateTime(2015, 10, 01);

            Boolean retorno = dataUm.IgualQue(dataDois);

            Assert.AreEqual(false, retorno);
        }

        [TestMethod]
        public void Testar_data_IgualQue_sendo_menor()
        {
            DateTime dataUm = new DateTime(2015, 10, 01);

            DateTime dataDois = new DateTime(2015, 10, 02);

            Boolean retorno = dataUm.IgualQue(dataDois);

            Assert.AreEqual(false, retorno);
        }

        [TestMethod]
        public void Testar_data_IgualQue_sendo_menor_em_segundos()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 0, 0, 30);

            DateTime dataDois = new DateTime(2015, 10, 01, 0, 0, 45);

            Boolean retorno = dataUm.IgualQue(dataDois);

            Assert.AreEqual(false, retorno);
        }
        #endregion

        #region MenorQue
        [TestMethod]
        public void Testar_data_MenorQue_sendo_menor()
        {
            DateTime dataUm = new DateTime(2015, 10, 01);

            DateTime dataDois = new DateTime(2015, 10, 02);

            Boolean retorno = dataUm.MenorQue(dataDois);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void Testar_data_MenorQue_sendo_menor_em_segundos()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 0, 0, 30);

            DateTime dataDois = new DateTime(2015, 10, 01, 0, 0, 45);

            Boolean retorno = dataUm.MenorQue(dataDois);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void Testar_data_MenorQue_sendo_maior()
        {
            DateTime dataUm = new DateTime(2015, 10, 02);

            DateTime dataDois = new DateTime(2015, 10, 01);

            Boolean retorno = dataUm.MenorQue(dataDois);

            Assert.AreEqual(false, retorno);
        }

        [TestMethod]
        public void Testar_data_MenorQue_sendo_maior_em_segundos()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 0, 0, 45);

            DateTime dataDois = new DateTime(2015, 10, 01, 0, 0, 15);

            Boolean retorno = dataUm.MenorQue(dataDois);

            Assert.AreEqual(false, retorno);
        }

        [TestMethod]
        public void Testar_data_MenorQue_sendo_igual()
        {
            DateTime dataUm = new DateTime(2015, 10, 01);

            DateTime dataDois = new DateTime(2015, 10, 01);

            Boolean retorno = dataUm.MenorQue(dataDois);

            Assert.AreEqual(false, retorno);
        }
        #endregion

        #region MenorOuIgualQue
        [TestMethod]
        public void Testar_data_MenorOuIgualQue_sendo_maior()
        {
            DateTime dataUm = new DateTime(2015, 10, 02);

            DateTime dataDois = new DateTime(2015, 10, 01);

            Boolean retorno = dataUm.MenorOuIgualQue(dataDois);

            Assert.AreEqual(false, retorno);
        }

        [TestMethod]
        public void Testar_data_MenorOuIgualQue_sendo_maior_em_segundos()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 0, 0, 45);

            DateTime dataDois = new DateTime(2015, 10, 01, 0, 0, 15);

            Boolean retorno = dataUm.MenorOuIgualQue(dataDois);

            Assert.AreEqual(false, retorno);
        }

        [TestMethod]
        public void Testar_data_MenorOuIgualQue_sendo_igual()
        {
            DateTime dataUm = new DateTime(2015, 10, 01);

            DateTime dataDois = new DateTime(2015, 10, 01);

            Boolean retorno = dataUm.MenorOuIgualQue(dataDois);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void Testar_data_MenorOuIgualQue_sendo_igual_em_segundos()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 12, 30, 15);

            DateTime dataDois = new DateTime(2015, 10, 01, 12, 30, 15);

            Boolean retorno = dataUm.MenorOuIgualQue(dataDois);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void Testar_data_MenorOuIgualQue_sendo_menor()
        {
            DateTime dataUm = new DateTime(2015, 10, 01);

            DateTime dataDois = new DateTime(2015, 10, 02);

            Boolean retorno = dataUm.MenorOuIgualQue(dataDois);

            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void Testar_data_MenorOuIgualQue_sendo_menor_em_segundos()
        {
            DateTime dataUm = new DateTime(2015, 10, 01, 12, 30, 00);

            DateTime dataDois = new DateTime(2015, 10, 01, 12, 30, 15);

            Boolean retorno = dataUm.MenorOuIgualQue(dataDois);

            Assert.AreEqual(true, retorno);
        }
        #endregion
    }
}
