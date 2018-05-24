namespace TreeViewExample.Business.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //OAR recepten moeten er nog bij welk type die heeft
    public partial class pru_Procedures
    {
        public pru_Procedures()
        {
            oar_OARcps = new ObservableCollection<oar_OARcps>();
            rot_Routes = new ObservableCollection<Route>();
        }

        public pru_Procedures(Route route)
        {
            //oar_OARcps = new HashSet<oar_OARcps>();
            rot_Routes = new ObservableCollection<Route>();
            rot_Routes.Add(route);

            this.pru_ProcedureId = route.ProcesCell.ProcesCellId + route.RouteId;
            this.pru_ProcedureNm = "Procedure " + pru_ProcedureId;
            this.pru_ProcedureTypeId = route.ProcesCell.ProcesCellTypeId.Replace("L", "");
        }

        [Key]
        [StringLength(50)]
        public string pru_ProcedureId { get; set; }

        [Required]
        [StringLength(50)]
        public string pru_ProcedureNm { get; set; }

        [Required]
        [StringLength(50)]
        public string pru_ProcedureTypeId { get; set; }


        public virtual ObservableCollection<oar_OARcps> oar_OARcps { get; set; }
        //public virtual prt_ProcedureTypes prt_ProcedureTypes { get; set; }

        public virtual ObservableCollection<Route> rot_Routes { get; set; }
    }
}
