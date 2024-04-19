using System.Collections.Generic;
using System.Threading.Tasks;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Domain.Services.IServices;
using Dws.Note_one.Api.Domain.Repositories.IRepositories;

namespace Dws.Note_one.Api.Domain.Services.Communication
{
    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}