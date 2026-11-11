using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlesCotas.Application.Classes;

namespace AlesCotas.Application.Interfaces.Servicos
{
    public interface IGabineteAppService
    {
      
        Task<GabineteDto> Atualizar(EditarGabineteDto model);
        Task<GabineteDto> Cadastrar(EditarGabineteDto produto);
        bool Deletar(int? id);
        ListaPaginada<GabineteDto> Listar(GabineteFiltroDto parametros);
        Task<GabineteDto> Recuperar(int id);
    }
}
