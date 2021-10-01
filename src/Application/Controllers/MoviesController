using AutoWrapper.Wrappers;
using dbContext.Entities;
using dbContext.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using dbContext.DTO;

namespace projeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //creating imovierepository, IGenreRepository
        private readonly IMovieRepository IMovieRepository;
        private readonly IGenreRepository IGenreRepository;
        private readonly IMainCastRepository IMainCastRepository;
        private readonly IDirectorRepository IDirectorRepository;

        public MoviesController(IMovieRepository _IMovieRepository, IGenreRepository _IGenreRepository, IMainCastRepository _IMainCastRepository, IDirectorRepository _IDirectorRepository) //constructor method
        {
            this.IGenreRepository = _IGenreRepository;
            this.IMovieRepository = _IMovieRepository;
            this.IMainCastRepository = _IMainCastRepository;
            this.IDirectorRepository = _IDirectorRepository;
            
            #region linq
        [HttpGet("GetMovieListWithMaincast")]
        public ApiResponse GetMovieListWithMaincast()
        {
            ApiResponse ApiResponse = new ApiResponse();
            try
            {
                ApiResponse.IsError = false;
                ApiResponse.Result = IMainCastRepository.GetList().Join(
                    IMovieRepository.GetList(),
                    maincast => maincast.mov_id,
                    movie => movie.id,
                    (maincast, movie) =>
                    new MaincastAndMovieDto
                    {
                        movie = movie,
                        maincast = maincast
                    }).ToList();
            }
            catch (Exception ex)
            {
                ApiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                ApiResponse.Result = ex.Message;
            }
            return ApiResponse;
        }
        #endregion
        #region Movie
        [HttpPost("GetMovieList")]
        public ApiResponse GetMovieList(movie movie)
            {
            ApiResponse ApiResponse = new ApiResponse();
            try
            {
                ApiResponse.IsError = false;
                if (movie.id!=0)
                {
                    ApiResponse.Result = IMovieRepository.GetList(x => x.id == movie.id);
                }
                else
                {
                    ApiResponse.Result = IMovieRepository.GetList();
                }
                 //listeyi response olarak dödürüyor
            }
            catch (Exception ex)
            {
                ApiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                ApiResponse.Result = ex.Message;
            }
            return ApiResponse;
        }
        [HttpPost("AddMovie")]
        public ApiResponse AddMovie(movie movie)//moviereposirotye kayıt atıcan, .add deyip db'ye insert edeceksin
        {
            ApiResponse ApiResponse = new ApiResponse();
            try
            {
                ApiResponse.IsError = false;
                IMovieRepository.Add(movie);
            }
            catch (Exception ex)
            {
                ApiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                ApiResponse.Result = ex.Message;
            }
            return ApiResponse;
        }
        [HttpPost("UpdateMovie")]
        public ApiResponse UpdateMovie(movie movie) //zaten movie class'te tanımlı id vs. sadece adını çağırmak daha efektif //PARAMETRE ÇIKMAMDI? çünkü patch'in çalışma mantığı farklı
        {
            ApiResponse ApiResponse = new ApiResponse();
            {
                try
                {
                    ApiResponse.IsError = false;
                    var bulunanfilm = IMovieRepository.Get(x => x.id == movie.id);//LINQ Sorguları
                    if (bulunanfilm .id!=0)
                        IMovieRepository.Update(movie);
                }
                catch (Exception ex)
                {
                    ApiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    ApiResponse.Result = ex.Message;
                }
                return ApiResponse;
            }
        }
        
        [HttpDelete("DeleteMovie")]
        public ApiResponse DeleteMovie(movie movie) 
        {
            ApiResponse ApiResponse = new ApiResponse();
            try
            {
                ApiResponse.IsError = false;
                var bulunanfilm = IMovieRepository.Get(x => x.id == movie.id);//LINQ Sorguları
                if (bulunanfilm .id!=0)
                    IMovieRepository.Delete(movie);
            }
            catch (Exception ex)
            {
                ApiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                ApiResponse.Result = ex.Message;
            }
            return ApiResponse;
        }
        #endregion
        
        //HTTP methods were also used for other entities created: genre, director, maincast
