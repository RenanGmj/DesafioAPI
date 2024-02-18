
using DesafioAPI.Context;
using DesafioAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaContext _context;

        public TarefaController(TarefaContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }
        
        [HttpGet("{id}")]
        public IActionResult PegarPorId(int id)
        {
            var TarefaBanco = _context.AgendaDeTarefas.Find(id);

            if(TarefaBanco == null)
            {
                NotFound();
            }

            return Ok(TarefaBanco);


        }
        
        [HttpDelete("{id}")]
        public IActionResult DeletarPorId(int id)
        {
            var TarefaBanco = _context.AgendaDeTarefas.Find(id);

            if(TarefaBanco == null)
            {
                NotFound();
            }

            _context.AgendaDeTarefas.Remove(TarefaBanco);
            _context.SaveChanges();

            return  NoContent();
        }
        

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Tarefa tarefa)
        {
            var TarefaBanco = _context.AgendaDeTarefas.Find(id);

            if(TarefaBanco == null)
            {
                NotFound();
            }

            TarefaBanco.Titulo = tarefa.Titulo;
            TarefaBanco.Status = tarefa.Status;
            TarefaBanco.Data = tarefa.Data;

            _context.AgendaDeTarefas.Update(tarefa);
            _context.SaveChanges();
            return Ok(TarefaBanco);

        }
        
        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var TarefaBanco = _context.AgendaDeTarefas.Where(x => x.Titulo.Contains(titulo));

            return Ok(TarefaBanco);
        }
        
        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var TarefaBanco = _context.AgendaDeTarefas.Where(x => x.Status == status);

            return Ok(TarefaBanco);
        }
        
        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var TarefaBanco = _context.AgendaDeTarefas.ToList();
            return Ok(TarefaBanco);
        }
        

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var TarefaBanco = _context.AgendaDeTarefas.Where(x => x.Data == data);

            return Ok(TarefaBanco);
        }


    }
}