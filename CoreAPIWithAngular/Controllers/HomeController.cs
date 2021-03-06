﻿using KnowledgeSystemAPI.Handlers.Handlers.Home.GetUserRole;
using KnowledgeSystemAPI.Handlers.Handlers.Home.GetUserTechnologies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController: ControllerBase
    {
        private readonly IMediator _mediator;
        
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("getUserTechnologies")]
        [HttpGet]
        public async Task<ActionResult<List<GetUserTechnologiesModelResponse>>> GetUserTechnologies([FromQuery]GetUserTechnologiesModelRequest user)
        {
            var result = await _mediator.Send(user);
           
            if (result == null)
                return NotFound(user);

            return result;
        }

        [Route("getUserRole")]
        [HttpGet]
        public async Task<ActionResult<GetUserRoleModelResponse>> GetUserRole([FromQuery] GetUserRoleModelRequest user)
        {
            var result = await _mediator.Send(user);
            if (result == null)
                return NotFound(user);

            return result;
        }
    }
}