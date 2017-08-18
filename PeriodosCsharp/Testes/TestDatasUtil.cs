using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeriodosCsharp;

namespace Testes
{
    [TestClass]
    public class TestDatasUtil
    {
        #region UltimoDiaDoMes
        [TestMethod]
        public void Testar_retornar_ultimo_dia_do_mes()
        {
            DateTime dataQualquerEmJaneiro = new DateTime(2017, 01, 08);

            DateTime dataJaneiroUltimoDiaDoMes = dataQualquerEmJaneiro.UltimoDiaDoMes();

            Assert.AreEqual(new DateTime(2017, 01, 31), dataJaneiroUltimoDiaDoMes);
        }

        [TestMethod]
        public void Testar_retornar_ultimo_dia_do_mes_na_data_fim_dos_tempos()
        {
            DateTime proximoDoFimDosTempos = new DateTime(9999, 12, 12);

            DateTime dataFimDosTempos = proximoDoFimDosTempos.UltimoDiaDoMes();

            Assert.AreEqual(new DateTime(9999, 12, 31), dataFimDosTempos);
        }

        [TestMethod]
        public void Testar_retornar_ultimo_dia_do_mes_com_data_null()
        {
            DateTime? dataQualquerEmJaneiro = new DateTime(2017, 01, 08);
            dataQualquerEmJaneiro = null;

            DateTime? dataJaneiroUltimoDiaDoMes = dataQualquerEmJaneiro.UltimoDiaDoMes();

            Assert.AreEqual(null, dataJaneiroUltimoDiaDoMes);
        }
        #endregion

        #region PrimeiroDiaDoMes
        [TestMethod]
        public void Testar_retornar_primeiro_dia_do_mes()
        {
            DateTime meuAniversario = new DateTime(1987, 01, 08);

            DateTime dataPrimeiroDiaDeJaneiro = meuAniversario.PrimeiroDiaDoMes();

            Assert.AreEqual(new DateTime(1987, 01, 01), dataPrimeiroDiaDeJaneiro);
        }

        [TestMethod]
        public void Testar_retornar_primeiro_dia_do_mes_com_data_null()
        {
            DateTime? meuAniversario = new DateTime(1987, 01, 08);
            meuAniversario = null;

            DateTime? dataPrimeiroDiaDeJaneiro = meuAniversario.PrimeiroDiaDoMes();

            Assert.AreEqual(null, dataPrimeiroDiaDeJaneiro);
        }
        #endregion

        #region PrimeiroDiaDoMesSeguinte
        [TestMethod]
        public void Testar_retornar_data_primeiro_dia_do_mes_seguinte()
        {
            DateTime aniversarioEspecial = new DateTime(2016, 12, 12);

            DateTime mesSeguinteAoAniversario = aniversarioEspecial.PrimeiroDiaDoMesSeguinte();

            Assert.AreEqual(new DateTime(2017, 01,01), mesSeguinteAoAniversario);
        }

        [TestMethod]
        public void Testar_retornar_data_primeiro_dia_do_mes_seguinte_com_data_null()
        {
            DateTime? aniversarioEspecial = new DateTime(2016, 12, 12);
            aniversarioEspecial = null;

            DateTime? mesSeguinteAoAniversario = aniversarioEspecial.UltimoDiaDoMes();

            Assert.AreEqual(null, mesSeguinteAoAniversario);
        }

        [TestMethod]
        public void Testar_retornar_data_primeiro_dia_do_mes_seguinte_com_data_fim_dos_tempos()
        {
            DateTime? aniversarioEspecial = new DateTime(9999, 12, 12);

            DateTime? mesSeguinteAoAniversario = aniversarioEspecial.UltimoDiaDoMes();

            Assert.AreEqual(new DateTime(9999, 12, 31), mesSeguinteAoAniversario);
        }
        #endregion
    }
}
