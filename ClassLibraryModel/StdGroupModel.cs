using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class StdGroupModel
    {
        public int SgID { get; set; }
        public string? SgName { get; set; }
        public int StdID { get; set; }
        public bool? SgIsActive { get; set; }

        public string? StdFirstName { get; set; }
        public string? StdLastName { get; set; }
    }
}
