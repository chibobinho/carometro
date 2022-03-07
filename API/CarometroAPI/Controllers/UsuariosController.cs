﻿using CarometroAPI.Domains;
using CarometroAPI.Interfaces;
using CarometroAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Collections.Generic;

namespace CarometroAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos da interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os Usuários existentes
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um usuário pelo id
        /// </summary>
        /// <param name="idUsuario">id do usuário a ser buscado</param>
        /// <returns>Um usuário encontrado com status code - 200</returns>
        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(idUsuario);

            if (usuarioBuscado == null)
            {
                return NotFound("O Usuário informado não existe!");
            }
            return Ok(usuarioBuscado);
        }

        [HttpGet("email")]
        public IActionResult BuscarPorEmail(string Email)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmail(Email);

            if (usuarioBuscado == null)
            {
                return NotFound("O Usuário informado não existe!");
            }
            return Ok(usuarioBuscado);
        }

        /// <summary>
        /// Consulta a imagem do usuáro
        /// </summary>
        /// <returns>Retorna um base64 e a um status Code - OK</returns>
        [HttpGet("imagem")]
        public IActionResult consultarImagem()
        {
            try
            {

                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = _usuarioRepository.ConsultarImagem(idUsuario);

                return Ok(base64);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Consulta a foto de perfil de um usuário
        /// </summary>
        /// <returns>A foto em base64</returns>
        [HttpPost("imagem")]
        public IActionResult salvarImagem(IFormFile foto, int idUsuario)
        {
            try
            {
                //analisar o tamanho do arquivo
                if (foto.Length > 500000000) //5MB
                    return BadRequest(new { mensagem = "O tamanho máximo da imagem foi atingido." });

                //analise da extensao do arquivo
                //Split = retorna uma matriz de caracteres
                //Last = recupera a ultima posição da matriz.
                string extensao = foto.FileName.Split('.').Last();


                // if (extensao != "png")
                //  return BadRequest(new { mensagem = "Apenas arquivos .png são obrigatórios." });

                //recuperar id do usuario logado a partir do token.
                 idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _usuarioRepository.SalvarImagem(idUsuario, foto);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastra um Usuário
        /// </summary>
        /// <param name="novoUsuario">Usuario a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="usuarioAtualizado">Objeto com as novas informações do Usuário e o id do usuário a ser atualizado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpPut]
        public IActionResult Atualizar(Usuario usuarioAtualizado)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(usuarioAtualizado.IdUsuario);
                if (usuarioBuscado != null)
                {
                    if (usuarioAtualizado != null)
                        _usuarioRepository.Atualizar(usuarioAtualizado);
                }
                else
                {
                    return BadRequest(new { mensagem = "O usuário informado não existe" });
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="idUsuario">id do Usuário a ser deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            _usuarioRepository.Deletar(idUsuario);

            return StatusCode(204);
        }

        /// <summary>
        /// Consulta os dados de um único usuário
        /// </summary>
        /// <returns></returns>
        [HttpGet("uses")]
        public IActionResult ListarMeu()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_usuarioRepository.ListarMeu(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest( ex);
            }
        }
    }
}
