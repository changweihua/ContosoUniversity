using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

       [Required(ErrorMessage = "First name is required.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstMidName { get; set; }

       [Required(ErrorMessage = "Enrollment date is required.")]
       [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
       [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true, NullDisplayText = "No grade")]
        public decimal? Grade { get; set; }
        public int CourseID { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }


    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Number of credits is required.")]
        [Range(0, 5, ErrorMessage = "Number of credits must be between 0 and 5.")]
        public int Credits { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }

    public class Instructor
    {
        public int InstructorID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Hire date is required.")]
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public virtual OfficeAssignment OfficeAssignment { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }

    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public virtual Instructor Instructor { get; set; }
    }

    public class Department
      {
          public int DepartmentID { get; set; }

          [DisplayFormat(DataFormatString = "{0:c}")]
          [Required(ErrorMessage = "Budget is required.")]
          [Column(TypeName = "money")]
          public decimal? Budget { get; set; }

         [Display(Name = "Administrator")]
          public int? InstructorID { get; set; }

          [Required(ErrorMessage = "Department name is required.")]
          [MaxLength(50)]
          public string Name { get; set; }

          [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
          [Required(ErrorMessage = "Start date is required.")]
          public DateTime StartDate { get; set; }

          public virtual ICollection<Course> Courses { get; set; }
          public virtual Instructor Administrator { get; set; }
      }
    

}