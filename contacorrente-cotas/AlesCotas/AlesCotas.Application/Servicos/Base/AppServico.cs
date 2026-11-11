using AlesCotas.Application.Interfaces.Servicos.Base;
using AlesCotas.Domain.Interfaces.UnitOfWork;
using AutoMapper;

namespace AlesCotas.Application.Servicos.Base
{
    public class AppServico : IAppServico
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public AppServico(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _unitOfWork = uow;
        }
    }
}
