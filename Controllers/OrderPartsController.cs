
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
using System.Net.Mail;
using System.Net;

namespace DatingApp.API.Controllers
{
    //[ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class OrderPartController : ControllerBase
    {
        private readonly IOrderPartRepository _repo;


        public OrderPartController(IOrderPartRepository repo)
        {
            this._repo = repo;
        }

        [HttpPost("neworderpart")]

        [HttpGet]
        [Route("GetParts2")]
        public async Task<IActionResult> GetParts2()
        {
            var users = await _repo.GetParts2();
            if (users != null)
                return Ok(users);
            else
                return BadRequest("API call to get users failed");
        }

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
        [AllowAnonymous]
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
            if (companyid != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
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

        [Route("SendEmail/{partid}")]
        public async Task<IActionResult> SendEmail(int partid)
        {
            string email = "allanrodkin@gmail.com";
            string password = "V1l0l5a4ayr";
            string emailserver = "smtp.gmail.com";
            int emailport = 587;
            int userid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            string companyname = await _repo.GetCompanyName(userid);
            OrderPart part = await _repo.GetOrderPart(partid);
            string partname = part.PartName;
            string message = String.Format("{0} ordered part {1} at {2}", companyname, partname, System.DateTime.Now.ToShortDateString());
            try
            {
                var client = new SmtpClient(emailserver, emailport)
                {
                     Credentials = new NetworkCredential(email,password),
                     EnableSsl = true
                };
                await client.SendMailAsync("allanrodkin@gmail.com", "arod.winnipeg@gmail.com", "Part Order", message);
                return new OkResult();
            }
            catch (Exception e)
            {
                return BadRequest("Email Not Sent");
            }
            
            
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