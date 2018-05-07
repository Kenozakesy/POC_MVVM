using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeViewExample;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Dal.DatabaseConnection;
using TreeViewExample.Dal.EntityFramework;
using TreeViewExample.Business.Enums;
using System.Linq;
using System.Collections.Generic;

namespace WPF_MVVM_TestProject
{
    [TestClass]
    public class ParameterDefinitionTest
    {

        [TestMethod]
        public void DatabaseConnectiontest()
        {
            Assert.IsTrue(DatabaseConnectionClass.OpenConnection());
        }

        [TestMethod]
        public void InsertCheckFrameworkTest()
        {
            using (var context = new UniContext())
            {
                try
                { 
                    ParameterDefinition param = new ParameterDefinition();
                    param.ParName = "test90";
                    param.Description = "test";
                    param.BeforeSep = 9;
                    param.AfterSep = 9;
                    param.Type = ParameterType.Date;
                    param.Alignm = Alignment.Left;
                    param.DisplayToUser = true;
                    param.IsEditable = IsEditable.Editable;

                    context.ParameterDefinitions.Add(param);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    context.Dispose();
                }
            }

        }

        [TestMethod]
        public void SelectCheckFrameworkTest()
        {
            using (var context = new UniContext())
            {
                try
                {
                    var select = (from r in context.ParameterDefinitions select r);
                    List<ParameterDefinition> paramdefs = select.ToList();
                    Assert.IsNotNull(paramdefs);
                }
                catch (Exception e)
                {
                    context.Dispose();
                }
            }

        }
    }
}
