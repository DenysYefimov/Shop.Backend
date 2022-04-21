using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Articles.Commands.CreateArticle;
using Shop.Application.Articles.Commands.DeleteArticle;
using Shop.Application.Articles.Commands.UpdateArticle;
using Shop.Application.Articles.Queries.GetArticleDetails;
using Shop.Application.Articles.Queries.GetArticleList;
using Shop.WebApi.Models.Articles;
using System;
using System.Threading.Tasks;

namespace Shop.WebApi.Controllers
{
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ArticleController : BaseController
    {
        private readonly IMapper _mapper;
        public ArticleController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of articles
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /article
        /// </remarks>
        /// <returns>Returns ArticleListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ArticleListVm>> GetAll()
        {
            var query = new GetArticleListQuery
            {
                CategoryId = CategoryId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the article by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /article/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Article id (guid)</param>
        /// <returns>Returns ArticleDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ArticleDetailsVm>> Get(Guid id)
        {
            var query = new GetArticleDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the article
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /article
        /// </remarks>
        /// <param name="createArticleDto">CreateArticleDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateArticleDto createArticleDto)
        {
            var command = _mapper.Map<CreateArticleCommand>(createArticleDto);
            var articleId = await Mediator.Send(command);
            return Ok(articleId);
        }

        /// <summary>
        /// Updates the article
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /article
        /// </remarks>
        /// <param name="updateArticleDto">UpdateArticleDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateArticleDto updateArticleDto)
        {
            var command = _mapper.Map<UpdateArticleCommand>(updateArticleDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the article by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /article/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the article (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteArticleCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
