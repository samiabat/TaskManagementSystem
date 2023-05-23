using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Application.Models.Email;
using TaskManagment.Application.Responses;

namespace TaskManagment.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<Result<Email>> sendEmail(Email email);
    }
}
