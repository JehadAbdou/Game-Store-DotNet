using System;

namespace GameStore.Api.Dtos;

    public record CreateUserDto(
      string UserName,
      string Email,
      string Password);
    
