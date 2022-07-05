//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblEmployee()
        {
            this.TblProject = new HashSet<TblProject>();
        }
    
        public int IDEmployee { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public Nullable<int> IDDepartment { get; set; }
        public Nullable<int> IDJobPosition { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    
        public virtual TblDepartment TblDepartment { get; set; }
        public virtual TblJobPosition TblJobPosition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProject> TblProject { get; set; }
    }
}
