using Dev.WS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevWS.App.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotificador _notificador;

        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
    }
}
