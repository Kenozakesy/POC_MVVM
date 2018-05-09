using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.Models.DatabaseModels
{
    [Table("sri_SubRoutesInRoutes")]
    public class SubRoutesInRoutes : ViewModelBase
    {
        private string _ProcCellId;
        private string _RouteId;
        private string _SubrouteId;
        private int _SequenceNumber;

        public SubRoutesInRoutes()
        {

        }

        [ForeignKey("ProcCellId")]
        public virtual ProcessCel sri_ProcCellId { get; set; }

        [Key]
        [Column("sri_ProcCellId", Order = 0)]
        public string ProcCellId
        {
            get { return _ProcCellId; }
            set { SetProperty(ref _ProcCellId, value); }
        }

        [Key]
        [Column("sri_RouteId", Order = 1)]
        public string RouteId
        {
            get { return _RouteId; }
            set { SetProperty(ref _RouteId, value); }
        }

        [Key]
        [Column("sri_SubRouteId", Order = 2)]
        public string SubrouteId
        {
            get { return _SubrouteId; }
            set { SetProperty(ref _SubrouteId, value); }
        }

        [Column("sri_SeqNr")]
        public int SequenceNumber
        {
            get { return _SequenceNumber; }
            set { SetProperty(ref _SequenceNumber, value); }
        }
    }
}
