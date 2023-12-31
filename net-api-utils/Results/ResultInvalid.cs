﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace net_api_utils.Results
{
    public class ResultInvalid : Result
    {
        private const HttpStatusCode statusCode = HttpStatusCode.BadRequest;

        public ResultInvalid(string error)
            : base(new List<ResultMessage> { new ResultMessage(error) }, statusCode)
        {
        }

        public ResultInvalid(List<string> errors)
            : base(new List<ResultMessage>(errors.Select(t => new ResultMessage(t)).ToList()), statusCode)
        {
        }

        public ResultInvalid(ModelStateDictionary modelState)
            : base(modelState.Values.SelectMany(m => m.Errors).Select(e => new ResultMessage(e.ErrorMessage)).ToList(), statusCode)
        {
        }
    }
}
