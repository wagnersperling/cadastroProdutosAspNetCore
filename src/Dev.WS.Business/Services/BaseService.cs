using Dev.WS.Business.Interfaces;
using Dev.WS.Business.Models;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.WS.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }
        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notifications.Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<VT, TE>(VT validacao, TE entidade) where VT : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid)
                return true;

            Notificar(validator);
            return false;
        }
    }
}
