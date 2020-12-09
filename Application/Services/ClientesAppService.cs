
using Application.Interfaces;
using Application.ViewModel;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientesAppService : ControllerBase, IDisposable, IClientesAppService
    {
        private readonly IClientesService _serviceBase;
        private readonly IMapper _mapper;

        public ClientesAppService(IClientesService serviceBase, IMapper mapper) 
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
        }

        public async Task<IActionResult> AddAsync(ClientesViewModel obj)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(MessagesStatics.EntityNotValid);
                }

                await _serviceBase.AddAsync(_mapper.Map<ClientesModel>(obj));
                return CreatedAtAction(nameof(AddAsync), MessagesStatics.SuccessAdd);

            } catch
            {
                return BadRequest(MessagesStatics.ErrorAdd);
            }
        }

        public async Task<IActionResult> AddRangeAsync(IEnumerable<ClientesViewModel> obj)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(MessagesStatics.EntityNotValid);
                }

                await _serviceBase.AddRangeAsync(_mapper.Map<IEnumerable<ClientesModel>>(obj));
                return CreatedAtAction(nameof(AddRangeAsync), MessagesStatics.SuccessAdd);

            }
            catch
            {
                return BadRequest(MessagesStatics.ErrorAdd);
            }
        }

        public async Task<bool> AnyAsync(ClientesViewModel obj)
        {
            return await _serviceBase.AnyAsync(_mapper.Map<ClientesModel>(obj));
        }

        public async Task<IActionResult> UpdateAsync(ClientesViewModel obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(MessagesStatics.EntityNotValid);
                }

                await _serviceBase.UpdateAsync(_mapper.Map<ClientesModel>(obj));
                return CreatedAtAction(nameof(UpdateAsync), MessagesStatics.SuccessUpdate);

            }
            catch
            {
                return BadRequest(MessagesStatics.ErrorUpdate);
            }
        }

        public async Task<IActionResult> UpdateRangeAsync(IEnumerable<ClientesViewModel> obj)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(MessagesStatics.EntityNotValid);
                }

                await _serviceBase.AddRangeAsync(_mapper.Map<IEnumerable<ClientesModel>>(obj));
                return CreatedAtAction(nameof(UpdateRangeAsync), MessagesStatics.SuccessUpdate);

            }
            catch
            {
                return BadRequest(MessagesStatics.ErrorUpdate);
            }

        }

        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
               var list = _mapper.Map<IEnumerable<ClientesViewModel>>(await _serviceBase.GetAllAsync());

                if( list == null)
                {
                    return NotFound(MessagesStatics.NotFoundList);
                }

                return CreatedAtAction(nameof(GetAllAsync), list);

            } catch
            {
                return BadRequest(MessagesStatics.ErrorSearch);
            }
            
        }

        public async Task<IActionResult> GetByIDAsync(Guid Id)
        {           

            try
            {
                var entity = _mapper.Map<ClientesViewModel>(await _serviceBase.GetByIDAsync(Id));

                if (entity == null)
                {
                    return NotFound(MessagesStatics.NotFoundRegister);
                }

                return CreatedAtAction(nameof(GetByIDAsync), entity);

            }
            catch
            {
                return BadRequest(MessagesStatics.ErrorSearch);
            }
        }

        public async Task<IActionResult> RemoveAsync(Guid Id)
        {
            try
            {
                if (Id != Guid.Empty)
                {
                    var entity = _mapper.Map<ClientesModel>(await _serviceBase.GetByIDAsync(Id));

                    if (entity == null)
                    {
                        return NotFound(MessagesStatics.NotFoundRegister);
                    }


                    await _serviceBase.RemoveAsync(entity);
                    return CreatedAtAction(nameof(RemoveAsync), MessagesStatics.SuccessDelete);
                }

                return NotFound(MessagesStatics.NotFoundRegister + $" {Id}");

            }
            catch
            {
                return BadRequest(MessagesStatics.ErrorDelete);
            }

        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
