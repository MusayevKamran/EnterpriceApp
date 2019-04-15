using App.Domain.Commands.Course.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Validations.Course.Student
{
    public class RemoveStudentCommandValidation : StudentValidation<RemoveStudentCommand>
    {
        public RemoveStudentCommandValidation()
        {
            ValidateId();
        }
    }
}
