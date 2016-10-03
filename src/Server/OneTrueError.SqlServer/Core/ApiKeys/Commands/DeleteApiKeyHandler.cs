﻿using System;
using System.Threading.Tasks;
using DotNetCqs;
using Griffin.Container;
using Griffin.Data;
using Griffin.Data.Mapper;
using OneTrueError.Api.Core.ApiKeys.Commands;
using OneTrueError.App.Core.ApiKeys;

namespace OneTrueError.SqlServer.Core.ApiKeys.Commands
{
    [Component(RegisterAsSelf = true)]
    public class DeleteApiKeyHandler : ICommandHandler<DeleteApiKey>
    {
        private readonly IAdoNetUnitOfWork _unitOfWork;

        public DeleteApiKeyHandler(IAdoNetUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));
            _unitOfWork = unitOfWork;
        }

        public Task ExecuteAsync(DeleteApiKey command)
        {
            int id;
            if (!string.IsNullOrEmpty(command.ApiKey))
            {
                id = (int) _unitOfWork.ExecuteScalar("SELECT Id FROM ApiKeys WHERE GeneratedKey = @key", new { key=command.ApiKey});
            }
            else
            {
                id = command.Id;
            }

            _unitOfWork.ExecuteNonQuery("DELETE FROM [ApiKeyApplications] WHERE ApiKeyId = @id", new {id});
            _unitOfWork.ExecuteNonQuery("DELETE FROM [ApiKeys] WHERE Id = @id", new { id });
            return Task.FromResult<object>(null);
        }
    }
}