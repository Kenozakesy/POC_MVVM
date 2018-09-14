using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Business.Singletons;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.Repository.Interfaces;

namespace TreeViewExample.Dal.Repository.BusinessGlueCode
{
    public class RouteBusiness
    {
        IRouteRepository _Repository;

        public RouteBusiness(IRouteRepository repository)
        {
            _Repository = repository;
        }

        #region Methods

        public bool DatabaseDelete(object obj)
        {
            return _Repository.DatabaseDelete(obj);
        }

        public bool DatabaseInsert(object obj)
        {
            return _Repository.DatabaseInsert(obj);
        }

        public bool DatabaseUpdate(object obj)
        {
            return _Repository.DatabaseUpdate(obj);
        }

        public List<ParameterDefinition> GetAllRequiredParameterDefinition(Route route)
        {
            List<string> RequiredParameterNames = _Repository.GetAllRequiredParameterDefinitionNames(route);
            return ListGodClass.Instance.ParameterDefinitionList.Where(x => RequiredParameterNames.Any(y => y == x.paf_ParNm)).ToList();
        }


        public ObservableCollection<ParameterDefinition> GetAddAbleStandardParameters(Route route)
        {
            List<string> paramDefNames = _Repository.GetAllParameterDefinitionNames(route);
            List<ParameterDefinition> paramDef = ListGodClass.Instance.ParameterDefinitionList.Where(x => paramDefNames.Any(y => y == x.paf_ParNm)).ToList();

            List<ParameterDefinition> addAbleParametersList = paramDef.Where(x => !route.rop_RoutePars.Any(y => y.ParameterDefinition == x)).ToList();

            ObservableCollection<ParameterDefinition> addAbleParameters = new ObservableCollection<ParameterDefinition>(addAbleParametersList);

            return addAbleParameters;
        }

        #endregion
    }
}
