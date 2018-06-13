using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models;
using TreeViewExample.Dal.DatabaseConnection;
using TreeViewExample.Dal.EntityFramework;
using TreeViewExample.Business.Enums;
using System.Linq;
using System.Collections.Generic;
using TreeViewExample.Dal.Repository.BusinessGlueCode;
using TreeViewExample.Dal.Repository.SQLServerRepository;

namespace WPF_MVVM_TestProject
{
    [TestClass]
    public class ParameterDefinitionTest
    {

        //[TestMethod]
        //public void ChangeCheckFrameworkTest()
        //{
        //    using (var context = new UniContext())
        //    {
        //        try
        //        { 
        //            ParameterDefinition param = new ParameterDefinition("test", "de", 10, 10, IsEditable.Editable, true, true);
        //            param.AfterSep = 9;
        //            param.Type = ParameterType.Date;
        //            param.Alignm = Alignment.Left;

        //            var parameter = context.ParameterDefinitions.Find(param.ParName);
        //            context.Entry(parameter).CurrentValues.SetValues(param);

        //            context.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            context.Dispose();
        //        }
        //    }
        //}

        //[TestMethod]
        //public void InsertCheckFrameworkTest()
        //{
        //    using (var context = new UniContext())
        //    {
        //        try
        //        {
        //            ParameterDefinition param = new ParameterDefinition("test", "de", 10, 10, IsEditable.Editable, true, true);
        //            param.AfterSep = 9;
        //            param.Type = ParameterType.Date;
        //            param.Alignm = Alignment.Left;

        //            ParameterDefinition param2 = new ParameterDefinition("test90", "desc", 99, 99, IsEditable.Editable, true, true);
        //            param.AfterSep = 9;
        //            param.Type = ParameterType.Date;
        //            param.Alignm = Alignment.Left;

        //            context.ParameterDefinitions.Add(param);
        //            context.ParameterDefinitions.Add(param2);

        //            context.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            context.Dispose();
        //        }
        //    }
        //}

        [TestMethod]
        public void Ophaaltest()
        {
            ProcessCel cell = new ProcessCel(ProcesCellType.IL);

            ProcesCellBusiness db = new ProcesCellBusiness(new MSSQL_ProcesCellRepository());
            db.GetAddAbleStandardParameters(cell);
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
                    e.ToString();
                }
            }

        }

        [TestMethod]
        public void SelectCheckFrameworkTest2()
        {
            using (var context = new UniContext())
            {
                using (var dbcontext = context.Database.BeginTransaction())
                { 
                    try
                    {
                        var select = (from r in context.ParameterDefinitions select r);
                        List<ParameterDefinition> paramdefs = select.ToList();
                        Assert.IsNotNull(paramdefs);
                    }
                    catch (Exception)
                    {             
                        dbcontext.Rollback();
                        context.Dispose();
                    }
                }
            }

        }



        [TestMethod]
        public void SelectProcesCellTest()
        {
            List<ProcessCel> procescells = new List<ProcessCel>();
            using (var context = new UniContext())
            {
                try
                {
                    var select = (from r in context.ProcesCells select r);
                    procescells = select.ToList();
                    Assert.IsNotNull(procescells);

                }
                catch (Exception)
                {
                    context.Dispose();
                }

            }

        }
    }
}
