using App.Domain.Commands.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Validations.Student
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
