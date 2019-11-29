
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Helpers;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    //[ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderPartController : ControllerBase
    {
        private readonly IOrderPartRepository _repo;


        public OrderPartController(IOrderPartRepository repo)
        {
            this._repo = repo;
        }

        [HttpPost("neworderpart")]
        public async Task<IActionResult> Register(OrderPart orderPart)
        {
            
            if (await _repo.PartExists(orderPart.PartName))
                return BadRequest("Part name already exists");
            _repo.Add<OrderPart>(orderPart);
            await _repo.SaveAll();
            return new OkResult();
        }

        [HttpPost("newcompanypart")]
        public async Task<IActionResult> NewCompanyPart(CompanyPart companyPart)
        {
            if (await _repo.CompanyPartExists(companyPart.UserId, companyPart.OrderPartId))
                return BadRequest("Company already has been assigned this part");
            _repo.Add<CompanyPart>(companyPart);
            await _repo.SaveAll();
            return new OkResult();
        }


        [HttpGet]
        public async Task<IActionResult> GetOrderParts([FromQuery]UserParams userParams)
        {
            var orderParts = await _repo.GetOrderParts(userParams);
            Response.AddPagination(orderParts.CurrentPage, orderParts.PageSize,
            orderParts.TotalCount, orderParts.TotalPages);
            return Ok(orderParts);
        }

        [Route("GetCompanyOrderParts/{companyid}")]
        //[HttpGet("{companyid}", Name = "GetCompanyOrderParts")]
        public async Task<IActionResult> GetCompanyOrderParts(int companyid, [FromQuery]UserParams userParams)
        {
            var orderParts = await _repo.GetCompanyOrderParts(companyid, userParams);
            Response.AddPagination(orderParts.CurrentPage, orderParts.PageSize,
            orderParts.TotalCount, orderParts.TotalPages);
            return Ok(orderParts);
        }

        [Route("GetOrderPart/{id}")]
       
        public async Task<IActionResult> GetOrderPart(int id)
        {
            var orderPart = await _repo.GetOrderPart(id);
            return Ok(orderPart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderPart(int id, OrderPart UpdatedOrderPart)
        {
            //if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            var partFromRepo = await _repo.GetOrderPart(id);

            partFromRepo.inStock = UpdatedOrderPart.inStock;
            partFromRepo.isActive = UpdatedOrderPart.isActive;
            partFromRepo.PartName = UpdatedOrderPart.PartName;
            partFromRepo.PartDescription = UpdatedOrderPart.PartDescription;
            partFromRepo.PartUrl = UpdatedOrderPart.PartUrl;
            partFromRepo.SKU = UpdatedOrderPart.SKU;

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");
        }



    }
}