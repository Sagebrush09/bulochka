//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bulochka
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int IDStudent { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IDCurator { get; set; }
        public int IDSpecialization { get; set; }
        public int Course { get; set; }
        public int GroupNumber { get; set; }
    
        public virtual Curator Curator { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}
