using MediatR;
using System;

namespace SistemaCompra.Application.Produto.Command.SolicitacaoCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
    }
}
