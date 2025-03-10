﻿using AutoMapper;
using Microsoft. AspNetCore. Http;
using Microsoft. AspNetCore. Mvc;
using TaskManagementSystem. TaskManagementSys. API. Dto;
using TaskManagementSystem. TaskManagementSys. Application. Interfeces;
using TaskManagementSystem. TaskManagementSys. Application. Services;

namespace TaskManagementSystem. TaskManagementSys. API. Controllers
{
    [Route ( "[controller]" )]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectServices _projectServices;

        public ProjectController ( IProjectServices projectServices )
        {
            _projectServices = projectServices;

        }
        [Route("AddProByUserId")]

        [HttpPost]
        public async Task<ActionResult<string>> AddProjectByUserId ( [FromBody] ProjectDTO projectDTO )
        {
            var result = await _projectServices.AddProject(projectDTO);
            return result. Contains ( "Successfully" ) ? Ok ( result ) : BadRequest ( result );
        }
        [Route("GetProByUserId")]
        [HttpPost]
        public async Task<ActionResult<ICollection<ProjectDTO?>>> GetProjectById ( [FromBody] ProjectDTO projectDTO )
        {
            var result = await _projectServices.GetProjectByUserId(projectDTO);
            return result != null ? Ok ( result ) : BadRequest ( result );
        }

        [Route("DelProById")]
        [HttpDelete]
        public async Task<ActionResult<string>> DeleteProjectById ( [FromBody] ProjectDTO projectDTO )
        {
            var result= await _projectServices. DeleteProjectById ( projectDTO );
            return result.Contains( "Successful" ) ?Ok(result ) : BadRequest ( result );
        }
        [Route ( "UpdateProById" )]
        [HttpPut]
        public async Task<ActionResult<string>> UpdateProById ( [FromBody] ProjectDTO projectDTO )
        {
            var result = await _projectServices.UpdateProById(projectDTO);
            return result. Contains ( "Succesfully" ) ? Ok ( result ) : BadRequest ( result );
        }
    }
}
