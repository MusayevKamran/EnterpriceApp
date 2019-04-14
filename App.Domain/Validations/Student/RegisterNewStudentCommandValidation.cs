using App.Domain.Commands.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Validations.Student
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
