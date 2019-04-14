using App.Domain.Commands.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Validations.Student
{
    public class RemoveStudentCommandValidation : StudentValidation<RemoveStudentCommand>
    {
        public RemoveStudentCommandValidation()
        {
            ValidateId();
        }
    }
}
