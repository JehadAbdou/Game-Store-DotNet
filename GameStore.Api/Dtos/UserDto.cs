using System;

namespace GameStore.Api.Dtos;

    public record UserDto(
        int id,
        string name,
        string email,
        string password
    );
    
