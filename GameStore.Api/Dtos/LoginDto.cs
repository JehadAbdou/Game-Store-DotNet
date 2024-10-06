using System;

namespace GameStore.Api.Dtos;

    public record LoginDto(
        string Email,
        string Password
    );
    
