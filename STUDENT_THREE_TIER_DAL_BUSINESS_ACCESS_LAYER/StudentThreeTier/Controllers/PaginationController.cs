using BusinessLogicLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StudentThreeTier.Controllers
{
    [Authorize(Roles ="Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaginationController : ControllerBase
    {
        private readonly IPaginationRepo _paginationRepo;
        private readonly IPaginationService _paginationService;

        public PaginationController(
            IPaginationRepo paginationRepo,
            IPaginationService paginationService


            )
        {
            _paginationRepo = paginationRepo;
            _paginationService = paginationService;
        }

        [HttpGet]
        [Route("GetStudentsData")]
        public async Task<IActionResult> GetStudents( string? SearchTerm, string? SortColumn, string? SortDirection, string? MultiNames, int Page = 1, int Limit = 5)
        {
            try
            {
                var result = await _paginationService.GetStudentsRecords(Page,Limit,SearchTerm,SortColumn,SortDirection,MultiNames);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new StatusModel
                {
                    StatusCode= 500,
                    Message = ex.Message,
                });
            }
            
        }
    }
}
