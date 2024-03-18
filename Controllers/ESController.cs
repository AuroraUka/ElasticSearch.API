using ElasticSearch.API.Model;
using ElasticSearch.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ESController : ControllerBase
    {
        private readonly Services.IElasticSearchServices<MyDocument> _elasticSearchServices;

        public ESController(IElasticSearchServices<MyDocument> elasticSearchServices)
        {
            _elasticSearchServices = elasticSearchServices;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDocuments()
        {
            var response = await _elasticSearchServices.GetAllDocumentsAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] MyDocument document)
        {
            var result = await _elasticSearchServices.CreateDocumentAsync(document);
            return Ok(result);
        }

        [HttpGet]
        [Route("read/{id}")]
        public async Task<IActionResult> GetDocument(int id)
        {
            var document = await _elasticSearchServices.GetDocumentAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocument([FromBody] MyDocument document)
        {
            var result = await _elasticSearchServices.UpdateDocumentAsync(document);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var result = await _elasticSearchServices.DeleteDocumentAsync(id);
            return Ok(result);
        }
    }
}
