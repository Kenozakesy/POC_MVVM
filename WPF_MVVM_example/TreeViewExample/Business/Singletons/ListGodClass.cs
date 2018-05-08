﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;

namespace TreeViewExample.Business.Singletons
{
    /// <summary>
    /// This class is used to keep the most important 3 lists in one place without having to request them another time during run time
    /// </summary>
    public class ListGodClass
    {
        private static ListGodClass _Instance;

        private ObservableCollection<ProcessCel> _ProcessCelList = new ObservableCollection<ProcessCel>();
        private ObservableCollection<Bin> _BinList = new ObservableCollection<Bin>();
        private ObservableCollection<ParameterDefinition> _CustomerParameterList = new ObservableCollection<ParameterDefinition>();

        private ListGodClass()
        {
            AddCustomerParameters();
        }

        public static ListGodClass Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ListGodClass();
                }
                return _Instance;
            }
        }

        #region Properties

        public ObservableCollection<ProcessCel> ProcessCelList
        {
            get { return _ProcessCelList; }
            set { _ProcessCelList = value; }
        }
        public ObservableCollection<Bin> BinList
        {
            get { return _BinList; }
            set { _BinList = value; }
        }
        public ObservableCollection<ParameterDefinition> CustomerParameterList
        {
            get { return _CustomerParameterList; }
            set { _CustomerParameterList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all Customer Parameters
        /// </summary>
        private void AddCustomerParameters()
        {
            ParameterDefinition paramDef = new ParameterDefinition();
            CustomerParameterList = paramDef.GetAllCustomerParameters();
        }

        #endregion
    }
}