using AutoMapper;
using Dataflow.Dtos;
using Dataflow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dataflow.Data;

namespace Dataflow.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataflowContext _context;
        private readonly IMapper _mapper;

        public UserService(DataflowContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            var userDTOs = _mapper.Map<List<GetUserDTO>>(users);

            var serviceResponse = new ServiceResponse<List<GetUserDTO>>();
            serviceResponse.Data = userDTOs;
            serviceResponse.Success = true;
            serviceResponse.Message = "All users retrieved.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                var userDTO = _mapper.Map<GetUserDTO>(user);

                var serviceResponse = new ServiceResponse<GetUserDTO>();
                serviceResponse.Data = userDTO;
                serviceResponse.Success = true;
                serviceResponse.Message = "User retrieved.";
                return serviceResponse;
            }
            else
            {
                var serviceResponse = new ServiceResponse<GetUserDTO>();
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found.";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetUserDTO>> AddUser(CreateUserDTO newUser)
        {
            var user = _mapper.Map<User>(newUser);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userDTO = _mapper.Map<GetUserDTO>(user);

            var serviceResponse = new ServiceResponse<GetUserDTO>();
            serviceResponse.Data = userDTO;
            serviceResponse.Success = true;
            serviceResponse.Message = "User added.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> DeleteUser(DeleteUserDTO deleteUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == deleteUser.Id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                var userDTO = _mapper.Map<GetUserDTO>(user);

                var serviceResponse = new ServiceResponse<GetUserDTO>();
                serviceResponse.Data = userDTO;
                serviceResponse.Success = true;
                serviceResponse.Message = "User deleted.";
                return serviceResponse;
            }
            else
            {
                var serviceResponse = new ServiceResponse<GetUserDTO>();
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found.";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetUserDTO>> PatchUser(int id, UpdateUserDTO updatedUser)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.Username = updatedUser.Username;
                existingUser.Password = updatedUser.Password;
                existingUser.FirstName = updatedUser.FirstName;
                existingUser.LastName = updatedUser.LastName;
                existingUser.Email = updatedUser.Email;

                await _context.SaveChangesAsync();

                var userDTO = _mapper.Map<GetUserDTO>(existingUser);

                var serviceResponse = new ServiceResponse<GetUserDTO>();
                serviceResponse.Data = userDTO;
                serviceResponse.Success = true;
                serviceResponse.Message = "User updated.";
                return serviceResponse;
            }
            else
            {
                var serviceResponse = new ServiceResponse<GetUserDTO>();
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found.";
                return serviceResponse;
            }
        }
    }
}
