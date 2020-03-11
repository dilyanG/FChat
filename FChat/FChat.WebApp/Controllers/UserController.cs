using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FChat.DataAccess;
using FChat.DataModel.Entities;
using FChat.DataService.Interfaces;
using FChat.DataService.ViewModels;
using AutoMapper;

namespace FChat.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;


        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        [Route("all")]
        public IEnumerable<UserViewModel> GetUsers()
        {
            return this.mapper.Map<IEnumerable<UserViewModel>>(this.userService.GetAll());
        }

        // GET: api/User/5
        [HttpGet]
        [Route("getUser/{name}")]
        public UserViewModel GetUser(string name)
        {
            var userEntity = userService.GetByName(name);

            return mapper.Map<UserViewModel>(userEntity);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public UserViewModel GetById(int id)
        {
            UserEntity userEntity = userService.GetById(id);

            return mapper.Map<UserViewModel>(userEntity);
        }


        // POST: api/User
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Route("enter")]
        public OkObjectResult EnterUser(UserViewModel userModel)
        {
            UserEntity entity = mapper.Map<UserEntity>(userModel);

            if (this.userService.GetByName(entity.Name) == null)
                this.userService.AddUser(entity);
            return new OkObjectResult(mapper.Map<UserViewModel>(this.userService.GetByName(userModel.Name)));
        }

        [HttpGet]
        [Route("checkUser/{name}")]
        public bool UserEntityExists(string name)
        {
            return userService.CheckUser(name);
        }
    }
}
