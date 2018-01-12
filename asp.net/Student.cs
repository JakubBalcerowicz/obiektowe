
namespace Zaliczenie.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Zaliczenie.Helpers;
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.Zapisy = new HashSet<Zapisy>();
        }
    
        public int StudentID { get; set; }
        [StringLength(20,MinimumLength=3)]
        [OnlyLetters]
        
        [Capitalized]
        [Display(Name = "Imie")]
        public string StudentName { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [OnlyLetters]
        [Multi(nameof(StudentName), ErrorMessage = "nie pasuje")]
        [Capitalized]
        [Display(Name = "Nazwisko")]
        public string StudentSurname { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zapisy> Zapisy { get; set; }
    }
}

