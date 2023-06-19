using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{

    private UsuarioService _usuarioService;

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastroUsuario(CreateUsuarioDto dto)
    {
        await _usuarioService.Cadastro(dto);

        return Ok("Usuario Cadastrado");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDto dto)
    {
        var token = await _usuarioService.Login(dto);
        return Ok(token);
    }

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
}
