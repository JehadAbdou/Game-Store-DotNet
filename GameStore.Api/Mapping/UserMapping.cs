using System;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping
{
    public static class UserMapping
    {
        public static UserDto ToUserDto (this User user){
            return new UserDto (user.Id,user.Username, user.Email, user.Password);
        }
    }
}