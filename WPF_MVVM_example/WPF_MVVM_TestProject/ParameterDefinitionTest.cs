using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeViewExample;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels.Parameters;

namespace WPF_MVVM_TestProject
{
    [TestClass]
    public class ParameterDefinitionTest
    {
        [TestMethod]
        public void CheckIsrequiredTest()
        {
            ParameterDefinition configParam = new ParameterDefinition("Parameter" + 1, "test parameter", 1.ToString(), "KG", true, true);
            Assert.AreEqual(configParam.UsedForBG, false);
        }

        [TestMethod]
        public void Listmapping()
        {
            ProcessCel processcel = new ProcessCel("name", 1);

            ProcessCelParameter PP = new ProcessCelParameter("Parameter" + 1, "test parameter", 1.ToString(), "KG", true, true, processcel);
            ProcessCelParameter PP2 = new ProcessCelParameter("Parameter" + 2, "test parameter", 2.ToString(), "KG", true, true, processcel);



        }
    }
}
