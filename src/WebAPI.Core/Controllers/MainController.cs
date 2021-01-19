using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Core.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValid())
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var err in validationResult.Errors)            
                AddError(err.ErrorMessage);
            
            return CustomResponse();
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(err => err.Errors);

            foreach (var err in errors)
                AddError(err.ErrorMessage);

            return CustomResponse();
        }

        protected void AddError(string errorMessage) => Errors.Add(errorMessage);        

        protected bool IsValid() => !Errors.Any();

        protected void ClearErrors() => Errors.Clear();


    }
}
