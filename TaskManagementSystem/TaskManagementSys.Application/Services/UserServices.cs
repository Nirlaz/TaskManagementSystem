

using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.TaskManagementSys.API.Dto;
using TaskManagementSystem.TaskManagementSys.Application.Interfeces;
using TaskManagementSystem.TaskManagementSys.Domain.Entites;
using TaskManagementSystem.TaskManagementSys.Domain.Interfaces;

namespace TaskManagementSystem.TaskManagementSys.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserServices(IUserRepository userRepository,IMapper mapper){
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<string> AddUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var existingUser = await _userRepository.GetUserById(user.UserId);
            Debug.WriteLine(user);
            Debug.WriteLine(existingUser);
            if (existingUser == null) {
                var check = await _userRepository.AddUser(user);
                return check == true ? "Data Added Successfully" : "Add Fail";
                
            }
            return "User exist";


        }

        public async Task<string> DeleteUserById(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            var existingUser = await _userRepository.GetUserById(user.UserId);
            if(existingUser != null)
            {
                return await _userRepository.DeleteUserById(user.UserId);
            }
            return "User Don't Exist";
        }

        public async Task<ICollection<UserDTO>> GetAllUser()
        {
             var user = await _userRepository.GetAllUser();
            return _mapper.Map<ICollection<UserDTO>>(user);
           
        }

        public async Task<UserDTO?> GetUserById(Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            return user != null ? _mapper.Map<UserDTO>(user):null;
        }
    }
}
