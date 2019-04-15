using App.Domain.Commands.Course.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Validations.Course.Student
{
    public class UpdateStudentCommandValidation : StudentValidation<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateEmail();
            ValidateBirthDate();
        }
    }
}
