using App.Domain.Validations.Course.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Course.Student
{
    public class RegisterNewStudentCommand : StudentCommand
    {
        public RegisterNewStudentCommand(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
