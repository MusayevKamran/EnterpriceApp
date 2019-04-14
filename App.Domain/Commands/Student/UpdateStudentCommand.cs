using App.Domain.Core.Commands;
using App.Domain.Validations.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Student
{
    public class UpdateStudentCommand : StudentCommand
    {
        public UpdateStudentCommand(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
