using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeViewExample;
using TreeViewExample.Business.Models.DiagramModels;

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
    }
}
