using App.Domain.Commands.Course.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Validations.Course.Student
{
    public class RegisterNewStudentCommandValidation : StudentValidation<RegisterNewStudentCommand>
    {
        public RegisterNewStudentCommandValidation()
        {
            ValidateName();
            ValidateEmail();
            ValidateBirthDate();
        }
    }
}
